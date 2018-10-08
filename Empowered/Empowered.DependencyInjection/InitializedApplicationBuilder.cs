 using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.ApplicationConfiguration
{
	/// <summary>
	/// <see cref="ApplicationBuilder"/> implementation
	/// ready for <see cref="IServiceProvider"/> creation
	/// </summary>
	/// <typeparam name="TProvider"></typeparam>
	public class InitializedApplicationBuilder<TProvider> : ApplicationBuilder where TProvider : IServiceProvider
	{
		/// <summary>
		/// provider for dependency injection
		/// </summary>
		protected readonly TProvider Provider;

		/// <summary>
		/// Creates <see cref="InitializedApplicationBuilder{TMyProvider}"/>
		/// inside of <see cref="ApplicationBuilder.UseSubcontractor{TBuilder, TProvider}(TProvider, Func{ApplicationBuildingTurn{TProvider}, TBuilder})"/> factoryMethod
		/// </summary>
		/// <param name="myTurn"></param>
		public InitializedApplicationBuilder(ApplicationBuildingTurn<TProvider> myTurn)
		{
			this.chainedServiceProvider = myTurn.ChainedProvider;
			this.Provider = myTurn.TurnProvider;
		}

		/// <summary>
		/// Passes application building to next <see cref="InitializedApplicationBuilder{TMyProvider}"/>
		/// which uses same provider as this builder
		/// </summary>
		/// <typeparam name="TBuilder"></typeparam>
		/// <param name="factoryMethod"></param>
		/// <returns></returns>
		public TBuilder UseSubcontractor<TBuilder>(Func<ApplicationBuildingTurn<TProvider>, TBuilder> factoryMethod)
			where TBuilder : InitializedApplicationBuilder<TProvider>
		{
			return factoryMethod(new ApplicationBuildingTurn<TProvider>(this.chainedServiceProvider, this.Provider));
		}

		/// <summary>
		/// Returns service provider chaining all configured inner providers
		/// </summary>
		/// <returns></returns>
		public IServiceProvider CreateServiceProvider()
		{
			return this.chainedServiceProvider;
		}

		internal sealed override void AddProviderToChain(IServiceProvider serviceProvider)
		{
			this.chainedServiceProvider.Add(serviceProvider);
		}
	}
}
