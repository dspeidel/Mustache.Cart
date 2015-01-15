using System;
using CartService;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using Mustache.CartService.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;

namespace Mustache.CartService.WebApi.Hypermedia
{
	public class CartSpec : ResourceSpec<Cart, CartState, Guid>
	{

		public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Carts({id})");

		public override string EntrypointRelation
		{
			get { return LinkRelations.CartResource; }
		}


		// IResourceStateSpec is not required but can be overridden to define custom operations and links.
		// See example below...
		
		//public override IResourceStateSpec<SampleResource, NullState, string> StateSpec
		//{
		//	get
		//	{
		//		return
		//			new SingleStateSpec<SampleResource, string>
		//			{
		//				Links =
		//				{
		//					CreateLinkTemplate(LinkRelations.SampleResource2, OrganizationSpec2.Uri, r => r.Id),
		//				},

		//				Operations = new StateSpecOperationsSource<SampleResource, string>
		//				{
		//					Get = ServiceOperations.Get,
		//					InitialPost = ServiceOperations.Create,
		//					Post = ServiceOperations.Update,
		//					Delete = ServiceOperations.Delete,
		//				},
		//			};
		//	}
		//}


		protected override System.Collections.Generic.IEnumerable<IResourceStateSpec<Cart, CartState, Guid>> GetStateSpecs()
		{
			yield return new ResourceStateSpec<Cart, CartState, Guid>(CartState.New)
				{
					Links =
						{
							CreateLinkTemplate(LinkRelations.Items, ItemSpec.UriByCart.Many, c => c.id),
						}
				};

			yield return new ResourceStateSpec<Cart, CartState, Guid>(CartState.InProgress)
				{
					
				};

			yield return new ResourceStateSpec<Cart, CartState, Guid>(CartState.Paying)
				{
					g
				};

			yield return new ResourceStateSpec<Cart, CartState, Guid>(CartState.Complete)
				{
					
				};

			throw new NotImplementedException();
		}
	}
}