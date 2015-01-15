using System;
using CartService;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using Mustache.CartService.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;

namespace Mustache.CartService.WebApi.Hypermedia
{
	public class ItemSpec : SingleStateResourceSpec<CartItem, Guid>
	{

		public static ResourceUriTemplate UriByCart = ResourceUriTemplate.Create("Carts({cartId})/Items({id})");

		public override string EntrypointRelation
		{
			get { return LinkRelations.SampleResource; }
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
							CreateLinkTemplate(LinkRelations.CartResource, CartSpec.Uri, c => c.Id),
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