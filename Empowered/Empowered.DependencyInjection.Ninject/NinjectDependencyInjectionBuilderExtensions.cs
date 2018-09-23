using Ninject;
using System;

namespace Empowered.DependencyInjection.Ninject
{
	public static class NinjectDependencyInjectionBuilderExtensions
	{
		public static InitializedWithNinjectDependencyInjectionBuilder StartNinjecting(this DependencyInjectionBuilder builder)
		{
			var kernel = new StandardKernel();

			var chainedServiceProvider = builder.AddServiceProvider(kernel);

			return new InitializedWithNinjectDependencyInjectionBuilder(chainedServiceProvider, kernel);
		}
	}
}
