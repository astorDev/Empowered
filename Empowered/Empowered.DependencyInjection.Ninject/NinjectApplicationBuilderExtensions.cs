using Empowered.ApplicationConfiguration;
using Ninject;
using System;

namespace Empowered.ApplicationConfiguration.Ninjecting
{
	/// <summary>
	/// Extensions for fluent ninject interaction
	/// </summary>
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
			var wrappedKernel = new KernelServiceProviderWrapper(new StandardKernel());

			return builder.UseSubcontractor(wrappedKernel, b => new NinjectedApplicationBuilder(b)); 
		}
	}
}
