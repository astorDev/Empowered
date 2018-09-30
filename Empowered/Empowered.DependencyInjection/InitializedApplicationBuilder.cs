 using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.ApplicationConfiguration
{
	/// <summary>
	/// <see cref="ApplicationBuilder"/> implementation
	/// ready for <see cref="IServiceProvider"/> creation
	/// </summary>
	/// <typeparam name="TMyProvider"></typeparam>
	public class InitializedApplicationBuilder<TMyProvider> : ApplicationBuilder where TMyProvider : IServiceProvider
	{
		/// <summary>
		/// provider for dependency injection
		/// </summary>
		protected readonly TMyProvider Provider;

		/// <summary>
		/// Creates <see cref="InitializedApplicationBuilder{TMyProvider}"/>
		/// from previous <see cref="ApplicationBuilder"/> passing turn with required <see cref="IServiceProvider"/>
		/// <para></para>
		/// Note: that method should only be used within 
		/// <see cref="ApplicationBuilder.UseSubcontractor{TBuilder, TProvider}(TProvider, System.Func{ApplicationBuilder, TBuilder})"/>
		/// factory method
		/// </summary>
		/// <param name="builder"></param>
		internal protected InitializedApplicationBuilder(ApplicationBuilder builder)
		{
			this.chainedServiceProvider = builder.chainedServiceProvider;
			this.Provider = (TMyProvider)builder.nextProvider;
		}

		/// <summary>
		/// Returns built service provider.
		/// Essentially returns passed through <see cref="ChainedServiceProvider"/>
		/// </summary>
		/// <returns></returns>
		public IServiceProvider CreateServiceProvider()
		{
			return this.chainedServiceProvider;
		}

		internal sealed override void addProviderToChain(IServiceProvider serviceProvider)
		{
			this.chainedServiceProvider.Add(serviceProvider);
		}
	}
}
