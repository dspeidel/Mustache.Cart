using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.Logging;
using Mustache.CartService.ApiServices;
using Mustache.CartService.Services;

namespace Mustache.CartService.WebApi.Infrastructure.Installers
{

	/// <summary>
	/// Registers domain specific services using a service resolver if provided, otherwise register all services from provided assembly.
	/// </summary>
	public class DomainServicesInstaller : IWindsorInstaller
	{
		readonly IDomainServiceResolver _customDomainServiceResolver;
		readonly Assembly _apiDomainServicesAssembly;
		readonly Assembly _apiDomainServiceInterfacesAssembly;

		public DomainServicesInstaller(IDomainServiceResolver customDomainServiceResolver, Assembly apiDomainServicesAssembly,
									   Assembly apiDomainServiceInterfacesAssembly)
		{
			if (apiDomainServicesAssembly == null)
				throw new ArgumentNullException("apiDomainServicesAssembly");
			if (apiDomainServiceInterfacesAssembly == null)
				throw new ArgumentNullException("apiDomainServiceInterfacesAssembly");

			_customDomainServiceResolver = customDomainServiceResolver;
			_apiDomainServicesAssembly = apiDomainServicesAssembly;
			_apiDomainServiceInterfacesAssembly = apiDomainServiceInterfacesAssembly;
		}


		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
				RegisterUsingContainer(container);
		}

		void RegisterUsingContainer(IWindsorContainer container)
		{

			container
				.Register(Classes.FromAssembly(_apiDomainServicesAssembly).BasedOn<IDomainService>()
				 .Configure(
									cr =>
									{
										var x =
											cr.Interceptors(InterceptorReference.ForKey(LoggingConstants.DomainServiceLogger)).Anywhere;
									})
				.WithServiceFromInterface());
			container.Register(
				Component.For<ICartRepository>().UsingFactoryMethod(() => new InMemoryCartRepository()).LifestyleSingleton());

		}

		IEnumerable<Type> DomainServiceInterfaces
		{
			get
			{
				return
					_apiDomainServiceInterfacesAssembly
						.GetTypes()
						.Where(t => t.IsInterface && typeof(IDomainService).IsAssignableFrom(t));
			}
		}
	}
}
