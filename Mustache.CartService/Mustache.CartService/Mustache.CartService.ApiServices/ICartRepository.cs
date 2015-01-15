using System;
using System.Collections.Generic;
using CartService;

namespace Mustache.CartService.ApiServices
{
	public interface ICartRepository
	{
		Model.PersistenceModel.Cart GetCartById(Guid id);
		Model.PersistenceModel.Cart CreateCart(Model.PersistenceModel.Cart cart);
		Model.PersistenceModel.CartItem AddItem(Guid cartId, Model.PersistenceModel.CartItem item);
		Model.PersistenceModel.CartItem UpdateItem(Guid cartId, Model.PersistenceModel.CartItem item);
		Model.PersistenceModel.CartItem DeleteItem(Guid cartId, int itemId);

		IEnumerable<Model.PersistenceModel.Cart> GetCarts();

		void ResetCartsList();
		void DeleteCart(Guid cartId);

		IEnumerable<Model.PersistenceModel.CartItem> GetItemsByCartId(Guid cartId);
	}
}