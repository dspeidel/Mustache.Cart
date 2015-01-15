using System;
using CartService;
using IQ.Platform.Framework.WebApi;

namespace Mustache.CartService.ApiServices
{
	public interface ICartApiService : IGetAResource<Cart,Guid>,ICreateAResource<Cart,Guid>, IDeleteResource<Cart,Guid>,IUpdateAResource<Cart,Guid>
	{
		
	}
}