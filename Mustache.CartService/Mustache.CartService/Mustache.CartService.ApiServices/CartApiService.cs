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
			resource.Id = Guid.NewGuid();
			var cart = new Model.PersistenceModel.Cart { Id = resource.Id, LastModified = resource.LastModified };
			_cartRepository.CreateCart(cart);

			return new ResourceCreationResult<Cart, Guid>(resource);
		}

		public IEnumerable<Cart> GetMany(IRequestContext context)
		{
			return _cartRepository.GetCarts().Select(c => new Cart{Id = c.Id, LastModified = c.LastModified, State = GetState(c)});
		}

		public Cart Get(Guid id, IRequestContext context)
		{
			var fromDb = _cartRepository.GetCartById(id);
			return new Cart {Id = fromDb.Id, LastModified = fromDb.LastModified, State = GetState(fromDb)};
		}

		private CartState GetState(Model.PersistenceModel.Cart fromDb)
		{
			if(fromDb.Items.Any() && fromDb.Payment.Id != Guid.Empty)
				return CartState.Paying;
			if(fromDb.Items.Any() && fromDb.Payment.Id == Guid.Empty)
				return CartState.InProgress;
			if(!string.IsNullOrEmpty(fromDb.Payment.AuthCode))
				return CartState.Complete;

			return CartState.New;
		}

		public Cart Update(Cart resource, IRequestContext context)
		{
			throw new NotImplementedException();
		}

		public void Delete(Guid id, IRequestContext context)
		{
			_cartRepository.DeleteCart(id);
		}
	}
}
