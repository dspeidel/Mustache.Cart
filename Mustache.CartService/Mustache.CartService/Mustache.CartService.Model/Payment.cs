using System;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace Mustache.CartService.Model
{
	public class Payment : IStatelessResource, IIdentifiable<Guid>
	{
		public Guid Id { get; set; }
		public string AuthCode { get; set; }
	}
}