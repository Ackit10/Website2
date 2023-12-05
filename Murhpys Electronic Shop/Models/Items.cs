using System;
namespace Murhpys_Electronic_Shop.Models
{
	public class Items
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string? PhotoPath { get; set; }
		public int? Section { get; set; }
		public decimal Price { get; set; }
	}
    public class Emails
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
    }
}

