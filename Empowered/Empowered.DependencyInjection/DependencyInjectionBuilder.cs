using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.DependencyInjection
{
	public class DependencyInjectionBuilder
	{
		public virtual ChainedServiceProvider AddServiceProvider(IServiceProvider serviceProvider)
		{
			return new ChainedServiceProvider(serviceProvider);
		}
	}

	public class InitializedDependencyInjectionBuilder : DependencyInjectionBuilder
	{
		private readonly ChainedServiceProvider chainedServiceProvider;

		public InitializedDependencyInjectionBuilder(ChainedServiceProvider chainedServiceProvider)
		{
			this.chainedServiceProvider = chainedServiceProvider;
		}

		public override ChainedServiceProvider AddServiceProvider(IServiceProvider serviceProvider)
		{
			this.chainedServiceProvider.Add(serviceProvider);

			return chainedServiceProvider;
		}

		public IServiceProvider CreateServiceProvider()
		{
			return this.chainedServiceProvider;
		}
	}
}
