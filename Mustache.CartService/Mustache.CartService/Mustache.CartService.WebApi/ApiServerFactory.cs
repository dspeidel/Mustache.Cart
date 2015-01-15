using System.Web.Http;
using Mustache.CartService.WebApi.Infrastructure;

namespace Mustache.CartService.WebApi
{

	public class HttpServerFactory
	{
		public HttpServer Create()
		{
			return new HttpServer(GetHttpConfiguration());
		}

		private static HttpConfiguration GetHttpConfiguration()
		{
			var config = new HttpConfiguration();
			BootStrapper.Initialize(config);
			return config;
		}
	}
}