using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS1POS.Models
{
	public class Product
	{
		[Key]
		public Guid ProductId { get; set; }
		[ForeignKey("Category")]
		public Guid CategoryId { get; set; }
		[Required]
		[MaxLength(50)]
		public string ProductName { get; set; }
		public string Image { get; set; }
		public double Price { get; set; }
		public int Qty { get; set; }
		[Required]
		[MaxLength(20)]
		public string Barcode { get; set; }

		public Category Category { get; set; }
	}
}

