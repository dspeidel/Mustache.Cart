using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CartService;
using IQ.Platform.Framework.WebApi.Services.Security;
using Mustache.CartService.ApiServices.Security;
using Mustache.CartService.Model;
using IQ.Platform.Framework.WebApi;

namespace Mustache.CartService.ApiServices
{
	public class CartApiService : IApiApplicationService<Cart, Guid>
	{
		private readonly ICartRepository _cartRepository;

		public CartApiService(ICartRepository cartRepository)
		{
			_cartRepository = cartRepository;
		}

		public ResourceCreationResult<Cart, Guid> Create(Cart resource, IRequestContext context)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Cart> GetMany(IRequestContext context)
		{
			throw new NotImplementedException();
		}

		public Cart Get(Guid id, IRequestContext context)
		{
			throw new NotImplementedException();
		}

		public Cart Update(Cart resource, IRequestContext context)
		{
			throw new NotImplementedException();
		}

		public void Delete(Guid id, IRequestContext context)
		{
			throw new NotImplementedException();
		}
	}
}
