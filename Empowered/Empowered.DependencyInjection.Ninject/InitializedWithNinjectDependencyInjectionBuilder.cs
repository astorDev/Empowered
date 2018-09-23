using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.DependencyInjection.Ninject
{
	public class InitializedWithNinjectDependencyInjectionBuilder : InitializedDependencyInjectionBuilder
	{
		private readonly IKernel kernel;

		public InitializedWithNinjectDependencyInjectionBuilder(ChainedServiceProvider chainedServiceProvider, IKernel kernel) : base(chainedServiceProvider)
		{
			this.kernel = kernel;
		}

		public InitializedWithNinjectDependencyInjectionBuilder Add(INinjectModule module)
		{
			this.kernel.Load(module);

			return this;
		}
	}
}
