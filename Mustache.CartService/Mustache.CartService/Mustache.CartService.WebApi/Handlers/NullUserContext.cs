using System;

namespace Mustache.CartService.WebApi.Handlers
{
	public class NullUserContext : IDisposable
	{
		public void Dispose() { }
	}
}