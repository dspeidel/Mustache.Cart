using System;
using CartService;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using Mustache.CartService.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;

namespace Mustache.CartService.WebApi.Hypermedia
{
	public class PaymentSpec : SingleStateResourceSpec<Payment, Guid>
	{

		public static ResourceUriTemplate UriByCart = ResourceUriTemplate.Create("Carts({cartId})/Payment({id})");
		
		public override IResourceStateSpec<Payment, NullState, Guid> StateSpec
		{
		    get
		    {
		        return
		            new SingleStateSpec<Payment, Guid>
		            {
		                Links =
		                {
							CreateLinkTemplate(LinkRelations.CartResource, CartSpec.Uri, c => c.Id),
		                },

		                Operations = new StateSpecOperationsSource<Payment, Guid>
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