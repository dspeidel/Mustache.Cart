using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace Mustache.CartService.ApiServices.Security
{

	public class CartServiceApiUser : ApiUser<UserAuthData>
	{
		public CartServiceApiUser(string name, Option<UserAuthData> authData)
			: base(authData)
		{
			Name = name;
		}

		public string Name { get; private set; }

	}

	public class CartServiceUserFactory : ApiUserFactory<CartServiceApiUser, UserAuthData>
	{
		public CartServiceUserFactory() :
			base(new HttpRequestDataStore<UserAuthData>())
		{
		}

		protected override CartServiceApiUser CreateUser(Option<UserAuthData> auth)
		{
			return new CartServiceApiUser("CartService user", auth);
		}
	}

}
