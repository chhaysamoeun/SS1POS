using System;
using SS1POS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace SS1POS.DTO
{
	public class ProductDTO
	{
        [Key]
        public Guid ProductId { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }
        public IFormFile Image { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        [Required]
        [MaxLength(20)]
        public string Barcode { get; set; }

        public Category Category { get; set; }
    }
}

