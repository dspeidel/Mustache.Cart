using System;
using System.Collections.Generic;
using CartService;

namespace Mustache.CartService.ApiServices
{
	public interface ICartRepository
	{
		Cart GetCartById(Guid id);
		Cart CreateCart(Cart cart);
		CartItem AddItem(Guid cartId, CartItem item);
		CartItem UpdateItem(Guid cartId, CartItem item);
	    CartItem DeleteItem(Guid cartId, int itemId);

		IEnumerable<Cart> GetCarts();

		void ResetCartsList();
	}
}