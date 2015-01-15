using System;
using System.Collections.Generic;
using System.Linq;
using CartService;

namespace Mustache.CartService.ApiServices
{
	public class InMemoryCartRepository : ICartRepository
	{
		readonly IDictionary<Guid, Cart> _carts; 

		public InMemoryCartRepository()
		{
			_carts = new Dictionary<Guid, Cart>();
			AddDefaultCart();
		}

		private void AddDefaultCart()
		{
			var cart = new Cart
				{
					Id = Guid.NewGuid(),
					Address = new Address {Name = "Homer Simpson", City = "Springfield", PostalCode = "A8A8A8"},
					Items =
						new List<CartItem>
							{
								new CartItem {ProductId = 1, Description = "some product", Quantity = 2, Price = 2.99m},
								new CartItem {ProductId = 2, Description = "some product2", Quantity = 3, Price = 19.99m}
							},
					LastModified = DateTimeOffset.UtcNow,
					State = CartState.InProgress
				};
			_carts[cart.Id] = cart;
		}

		public void ResetCartsList()
		{
			_carts.Clear();
			AddDefaultCart();
		}

		public Cart GetCartById(Guid id)
		{
			Cart c = null;
			_carts.TryGetValue(id, out c);
			return c;
		}

		public Cart CreateCart(Cart cart)
		{
			//Validations and such
			cart.Id = Guid.NewGuid();
			_carts[cart.Id] = cart;
			return cart;
		}

		public CartItem AddItem(Guid cartId, CartItem item)
		{
			var cart = _carts[cartId];
			var items = cart.Items.ToList();
			items.Add(item);
			cart.Items = items;

			return item;
		}

		public CartItem UpdateItem(Guid cartId, CartItem item)
		{
			var cart = _carts[cartId];
			cart.Items.First(i => i.ProductId == item.ProductId).Quantity = item.Quantity;
			return item;
		}

		public IEnumerable<Cart> GetCarts()
		{
			return _carts.Values;
		}


        public CartItem DeleteItem(Guid cartId, int itemId)
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