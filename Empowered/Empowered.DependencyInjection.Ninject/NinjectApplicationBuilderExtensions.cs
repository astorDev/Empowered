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
		/// Passed application building to <see cref="NinjectedApplicationBuilder"/> 
		/// </summary>
		/// <param name="builder"></param>
		/// <returns></returns>
		public static NinjectedApplicationBuilder StartNinjecting(this ApplicationBuilder builder)
		{
			var wrappedKernel = new KernelServiceProviderWrapper(new StandardKernel());

			return builder.UseSubcontractor(wrappedKernel, turn => new NinjectedApplicationBuilder(turn)); 
		}
	}
}
