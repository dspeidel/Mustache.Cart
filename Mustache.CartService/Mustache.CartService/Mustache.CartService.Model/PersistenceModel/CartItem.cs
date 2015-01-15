using System;

namespace Mustache.CartService.Model.PersistenceModel
{
	public class CartItem 
	{
		public Guid Id { get; set; }
		public int ProductId { get; set; }
		public string Description { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public Guid CartId { get; set; }
		
	}
}