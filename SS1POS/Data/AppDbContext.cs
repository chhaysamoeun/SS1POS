using System;
using Microsoft.EntityFrameworkCore;
using SS1POS.Models;

namespace SS1POS.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			:base(options)
		{
		}
		public DbSet<Category> Category { get; set; }
		public DbSet<Customer> Customer { get; set; }
		public DbSet<Product> Product { get; set; }
		public DbSet<Sale> Sale { get; set; }
		public DbSet<SaleDetail> SaleDetail { get; set; }
	}
}

