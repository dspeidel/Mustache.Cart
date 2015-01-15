using System;

namespace Mustache.CartService.Model.PersistenceModel
{
	public class Payment
	{
		public Guid Id { get; set; }
		public Guid CartId { get; set; }
		public string AuthCode { get; set; }
	}
}