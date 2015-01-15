using System;
using System.Collections.Generic;
using System.Linq;
using CartService;
using CartItem = Mustache.CartService.Model.PersistenceModel.CartItem;

namespace Mustache.CartService.ApiServices
{
	public class InMemoryCartRepository : ICartRepository
	{
		readonly IDictionary<Guid, Model.PersistenceModel.Cart> _carts; 

		public InMemoryCartRepository()
		{
			_carts = new Dictionary<Guid, Model.PersistenceModel.Cart>();
			AddDefaultCart();
		}

		private void AddDefaultCart()
		{
			var cart = new Model.PersistenceModel.Cart
				{
					Id = Guid.NewGuid(),
					Address = new Model.PersistenceModel.Address { Name = "Homer Simpson", City = "Springfield", PostalCode = "A8A8A8" },
					Items =
						new List<Model.PersistenceModel.CartItem>
							{
								new Model.PersistenceModel.CartItem {ProductId = 1, Description = "some product", Quantity = 2, Price = 2.99m},
								new Model.PersistenceModel.CartItem {ProductId = 2, Description = "some product2", Quantity = 3, Price = 19.99m}
							},
					LastModified = DateTimeOffset.UtcNow,
					
				};
			_carts[cart.Id] = cart;
		}

		public void ResetCartsList()
		{
			_carts.Clear();
			AddDefaultCart();
		}

		public void DeleteCart(Guid cartId)
		{
			_carts.Remove(cartId);
		}

		public IEnumerable<CartItem> GetItemsByCartId(Guid cartId)
		{
			var cart = GetCartById(cartId);
			return cart.Items;
		}

		public Model.PersistenceModel.Cart GetCartById(Guid id)
		{
			Model.PersistenceModel.Cart c = null;
			_carts.TryGetValue(id, out c);
			return c;
		}

		public Model.PersistenceModel.Cart CreateCart(Model.PersistenceModel.Cart cart)
		{
			//Validations and such
			cart.Id = Guid.NewGuid();
			_carts[cart.Id] = cart;
			return cart;
		}

		public Model.PersistenceModel.CartItem AddItem(Guid cartId, Model.PersistenceModel.CartItem item)
		{
			var cart = _carts[cartId];
			var items = cart.Items.ToList();
			items.Add(item);
			cart.Items = items;

			return item;
		}

		public Model.PersistenceModel.CartItem UpdateItem(Guid cartId, Model.PersistenceModel.CartItem item)
		{
			var cart = _carts[cartId];
			cart.Items.First(i => i.ProductId == item.ProductId).Quantity = item.Quantity;
			return item;
		}

		public IEnumerable<Model.PersistenceModel.Cart> GetCarts()
		{
			return _carts.Values;
		}


		public Model.PersistenceModel.CartItem DeleteItem(Guid cartId, int itemId)
        {
	        var cart = _carts[cartId];
            var item = cart.Items.First(i => i.ProductId == itemId);
            var list = cart.Items.ToList();
            list.Remove(item);
            cart.Items = list;
            return item;
        }
    }
}