using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.AspNet.Handlers;
using IQ.Platform.Framework.WebApi.Services.Security;
using Mustache.CartService.ApiServices.Security;

namespace Mustache.CartService.WebApi.Handlers
{
	public class PutYourApiSafeNameUserContextProvidingHandler
			: ApiSecurityContextProvidingHandler<CartServiceApiUser, NullUserContext>
	{

		public PutYourApiSafeNameUserContextProvidingHandler(
			IStoreDataInHttpRequest<CartServiceApiUser> apiUserInRequestStore)
			: base(new CartServiceUserFactory(), CreateContextProvider(), apiUserInRequestStore)
		{
		}

		static ApiUserContextProvider<CartServiceApiUser, NullUserContext> CreateContextProvider()
		{
			return
				new ApiUserContextProvider<CartServiceApiUser, NullUserContext>(_ => new NullUserContext());
		}
	}
}