using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SS1POS.Data;
using SS1POS.DTO;
using SS1POS.Models;

namespace SS1POS.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHost;
        public ProductController(AppDbContext context,
            IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }
        // GET: Product
        public async Task<ActionResult> Index()
        {
            var product = await (from p in _context.Product
                           join c in _context.Category
                           on p.CategoryId equals c.CategoryId
                           select new Product
                           {
                              CategoryId= p.CategoryId,
                              Image= p.Image,
                              Price= p.Price,
                              ProductId= p.ProductId,
                              ProductName= p.ProductName,
                              Qty= p.Qty
                           }).ToListAsync();
            return View(product);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                var prod = new Product
                {
                    Price=product.Price,
                    Qty=product.Qty,
                    ProductName=product.ProductName,
                    ProductId= Guid.NewGuid(),
                    CategoryId=product.CategoryId,
                    Image= UploadImage(product)
                };
                _context.Product.Add(prod);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName",product.CategoryId);
            return View(product);
        }
        private string UploadImage(ProductDTO product)
        {
            string imagePath = "";
            if(product.Image != null)
            {
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "uploads");
                imagePath = Guid.NewGuid().ToString() + "_" + product.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, imagePath);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    product.Image.CopyTo(fileStream);
                }
            }
            return imagePath;
        }
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}