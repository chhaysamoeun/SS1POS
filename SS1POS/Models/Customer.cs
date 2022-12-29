using System;
using System.ComponentModel.DataAnnotations;

namespace SS1POS.Models
{
	public class Customer
	{
		[Key]
		public Guid CustomerId { get; set; }
		[Required]
		[MaxLength(50)]
		[Display(Name ="Customer Name")]
		public string CustomerName { get; set; }
		[MaxLength(20)]
		[Phone]
		public string Phone { get; set; }
		[MaxLength(100)]
		[DataType(DataType.MultilineText)]
		public string Address { get; set; }
		[MaxLength(50)]
		[EmailAddress]
		public string Email { get; set; }
	}
}

