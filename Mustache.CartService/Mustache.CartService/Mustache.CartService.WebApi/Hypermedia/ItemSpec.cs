using System;
using System.Collections;
using System.Collections.Generic;
using CartService;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using Mustache.CartService.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;

namespace Mustache.CartService.WebApi.Hypermedia
{
	public class ItemSpec : SingleStateResourceSpec<CartItem, Guid>
	{

		public static ResourceUriTemplate UriByCart = ResourceUriTemplate.Create("Carts({cartId})/Items");
		public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Items({id})");

		protected override IEnumerable<ResourceLinkTemplate<CartItem>> Links()
		{
			yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.Id);
		}

		public override IResourceStateSpec<CartItem, NullState, Guid> StateSpec
		{
		    get
		    {
		        return
		            new SingleStateSpec<CartItem, Guid>
		            {
		                Links =
		                {
							CreateLinkTemplate(LinkRelations.CartResource, CartSpec.Uri, c => c.CartId),
		                },

		                Operations = new StateSpecOperationsSource<CartItem, Guid>
		                {
		                    Get = ServiceOperations.Get,
		                    InitialPost = ServiceOperations.Create,
		                    Post = ServiceOperations.Update,
		                    Delete = ServiceOperations.Delete,
		                },
		            };
		    }
		}

	}
}