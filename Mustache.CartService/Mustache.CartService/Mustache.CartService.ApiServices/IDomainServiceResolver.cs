using System;
using Mustache.CartService.Services;

namespace Mustache.CartService.ApiServices
{
	public interface IDomainServiceResolver
	{
		IDomainService Resolve(Type requestedServiceType);

		TService Resolve<TService>()
			where TService : IDomainService;
	}
}

namespace Mustache.CartService.Services
{
	/// <summary> 
	/// Represents a specific domain service / repository used in IApiApplicationService implementations 
	/// </summary> 
	public interface IDomainService
	{
	}
}
