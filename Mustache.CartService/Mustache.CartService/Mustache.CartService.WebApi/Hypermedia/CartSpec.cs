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
		//		


		protected override System.Collections.Generic.IEnumerable<IResourceStateSpec<Cart, CartState, Guid>> GetStateSpecs()
		{
			yield return new ResourceStateSpec<Cart, CartState, Guid>(CartState.New)
				{
					Links =
						{
							CreateLinkTemplate(LinkRelations.AddItemsResource, ItemSpec.UriByCart.Many, c => c.Id),
						}
				};

			yield return new ResourceStateSpec<Cart, CartState, Guid>(CartState.InProgress)
				{
					Links =
						{
							CreateLinkTemplate(LinkRelations.ItemsResource, ItemSpec.UriByCart.Many, c => c.Id),
							CreateLinkTemplate(LinkRelations.AddItemsResource, ItemSpec.UriByCart.Many, c => c.Id),
							CreateLinkTemplate(LinkRelations.StartPaymentResource, PaymentSpec.UriByCart, c => c.Id)
						}
				};

			yield return new ResourceStateSpec<Cart, CartState, Guid>(CartState.Paying)
				{
					Links =
						{
							CreateLinkTemplate(LinkRelations.ItemsResource, ItemSpec.UriByCart.Many, c => c.Id),
							CreateLinkTemplate(LinkRelations.CompletePaymentResource, PaymentSpec.UriByCart, c => c.Id)
						}
				};

			yield return new ResourceStateSpec<Cart, CartState, Guid>(CartState.Complete)
				{
					Links =
						{
							CreateLinkTemplate(LinkRelations.ItemsResource, ItemSpec.UriByCart.Many, c => c.Id),
							CreateLinkTemplate(LinkRelations.PaymentResource, PaymentSpec.UriByCart, c => c.Id)
						}
				};

			throw new NotImplementedException();
		}
	}
}