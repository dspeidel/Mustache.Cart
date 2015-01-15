using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CartService;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Hypermedia;

namespace Mustache.CartService.WebApi.Hypermedia
{
	public class CartStateProvider : ResourceStateProviderBase<Cart, CartState>
	{
		public override CartState GetFor(Cart resource)
		{
			return resource.State;
		}

		protected override IDictionary<CartState, IEnumerable<CartState>> GetTransitions()
		{
			return new Dictionary<CartState, IEnumerable<CartState>>
				{
					// from, to 
					{
						CartState.New, new[]
							{
								CartState.InProgress
							}
					},

					{
						CartState.InProgress, new[]
							{
								//CartState.New,
								CartState.Paying,
							}
					},
					{
						CartState.Paying, new[]
							{
								CartState.Complete,
							}
					}
				};
		}

		public override IEnumerable<CartState> All
		{
			get { return EnumEx.GetValuesFor<CartState>(); }
		}
	}
}