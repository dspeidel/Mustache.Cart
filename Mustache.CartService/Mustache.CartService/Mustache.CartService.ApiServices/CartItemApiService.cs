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
	public class CartItemApiService : IApiApplicationService<CartItem, Guid>
	{
		private readonly ICartRepository _cartRepository;

		public CartItemApiService(ICartRepository cartRepository)
		{
			_cartRepository = cartRepository;
		}

		public ResourceCreationResult<CartItem, Guid> Create(CartItem resource, IRequestContext context)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<CartItem> GetMany(IRequestContext context)
		{
			throw new NotImplementedException();
		}

		public CartItem Get(Guid id, IRequestContext context)
		{
			throw new NotImplementedException();
		}

		public CartItem Update(CartItem resource, IRequestContext context)
		{
			throw new NotImplementedException();
		}

		public void Delete(Guid id, IRequestContext context)
		{
			throw new NotImplementedException();
		}
	}
}
