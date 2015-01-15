using System;
using System.Collections.Generic;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace CartService
{
	public class Cart	: IStatefulResource<CartState>, IIdentifiable<Guid>
	{
	
		public Guid Id { get; set; }
		public CartState State { get; set; }
		public DateTimeOffset LastModified { get; set; }
		
	}
}