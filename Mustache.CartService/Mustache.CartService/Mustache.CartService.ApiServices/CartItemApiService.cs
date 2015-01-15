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
			Guid cartId = context.UriParameters.GetByName<Guid>("cartId").Value;

			var item = new Model.PersistenceModel.CartItem
				{
					CartId = cartId,
					Id = Guid.NewGuid(),
					ProductId = resource.ProductId,
					Quantity = resource.Quantity
				};

			_cartRepository.AddItem(cartId, item);
			resource.Id = item.Id;

			return new ResourceCreationResult<CartItem, Guid>(resource);
		}

		public IEnumerable<CartItem> GetMany(IRequestContext context)
		{
			Guid cartId = context.UriParameters.GetByName<Guid>("cartId").Value;
			return _cartRepository.GetItemsByCartId(cartId)
			               .Select(i => new CartItem {CartId = cartId, ProductId = i.ProductId, Quantity = i.Quantity});

		}

		public CartItem Get(Guid id, IRequestContext context)
		{
			Guid cartId = context.UriParameters.GetByName<Guid>("cartId").Value;
			var item = _cartRepository.GetItemsByCartId(cartId).FirstOrDefault(i => i.Id == id);
			return new CartItem {CartId = cartId, ProductId = item.ProductId, Quantity = item.Quantity };
		}

		public CartItem Update(CartItem resource, IRequestContext context)
		{
			Guid cartId = context.UriParameters.GetByName<Guid>("cartId").Value;
			Guid itemId = context.UriParameters.GetByName<Guid>("id").Value;
			var item = _cartRepository.GetItemsByCartId(cartId).FirstOrDefault(i => i.Id == itemId);
			item.Quantity = resource.Quantity;
			_cartRepository.UpdateItem(cartId, item);
			return resource;
		}

		public void Delete(Guid id, IRequestContext context)
		{
			Guid cartId = context.UriParameters.GetByName<Guid>("cartId").Value;
			var item = _cartRepository.GetItemsByCartId(cartId).FirstOrDefault(i => i.Id == id);
			_cartRepository.DeleteItem(cartId, item.ProductId);
		}
	}
}
