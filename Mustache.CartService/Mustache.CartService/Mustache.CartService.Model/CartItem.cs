using System;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace CartService
{
	public class CartItem : IStatelessResource, IIdentifiable<Guid>
	{
		public Guid Id { get; set; }
		public int ProductId { get; set; }
		public string Description { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		
	}
}