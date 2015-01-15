using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CartService;
using IQ.Platform.Framework.WebApi.Services.Security;
using Mustache.CartService.ApiServices.Security;
using Mustache.CartService.Model;
using IQ.Platform.Framework.WebApi;

namespace Mustache.CartService.ApiServices
{
	public class PaymentApiService : IApiApplicationService<Payment, Guid>
	{
		private readonly ICartRepository _cartRepository;

		public PaymentApiService(ICartRepository cartRepository)
		{
			_cartRepository = cartRepository;
		}

		public ResourceCreationResult<Payment, Guid> Create(Payment resource, IRequestContext context)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Payment> GetMany(IRequestContext context)
		{
			throw new NotImplementedException();
		}

		public Payment Get(Guid id, IRequestContext context)
		{
			throw new NotImplementedException();
		}

		public Payment Update(Payment resource, IRequestContext context)
		{
			throw new NotImplementedException();
		}

		public void Delete(Guid id, IRequestContext context)
		{
			throw new NotImplementedException();
		}
	}
}
