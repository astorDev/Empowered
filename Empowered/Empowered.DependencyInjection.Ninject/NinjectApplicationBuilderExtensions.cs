using Empowered.ApplicationConfiguration;
using Ninject;
using System;

namespace Empowered.DependencyInjection.Ninject
{
	public static class NinjectApplicationBuilderExtensions
	{
		/// <summary>
		/// Adds <see cref="IKernel"/> to service providers chain
		/// and returns <see cref="NinjectedApplicationBuilder"/>
		/// for ninject-based dependency injection. 
		/// </summary>
		/// <param name="builder"></param>
		/// <returns></returns>
		public static NinjectedApplicationBuilder StartNinjecting(this ApplicationBuilder builder)
		{
			IKernel kernel = new StandardKernel();

			return builder.UseSubcontractor(kernel, b => new NinjectedApplicationBuilder(b)); 
		}
	}
}
