using System;
using System.Collections.Generic;
using CartService;

namespace Mustache.CartService.Model.PersistenceModel
{
	public class Cart	
	{
		public Cart()
		{
			Items = new List<PersistenceModel.CartItem>();
			Payment = new Payment();
		}
		
		public Guid Id { get; set; }
		public IEnumerable<CartItem> Items { get; set; }
		public Address Address { get; set; }
		//public CartState State { get; set; }
		public DateTimeOffset LastModified { get; set; }
		public Payment Payment { get; set; }
		
	}
}