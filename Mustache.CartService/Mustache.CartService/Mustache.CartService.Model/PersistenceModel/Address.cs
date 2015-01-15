using System;

namespace Mustache.CartService.Model.PersistenceModel
{
	public class Address	
	{
		public string Name { get; set; }
		public string StreetAddress { get; set; }
		public string City { get; set; }
		public string Province { get; set; }
		public string Country { get; set; }
		public string PostalCode { get; set; }
		public Guid CartId { get; set; }
	}
}