using System;

namespace Empowered.ApplicationConfiguration
{
	/// <summary>
	/// Builder of dependency-injection based application. 
	/// </summary>
	public class ApplicationBuilder
	{
		internal ChainedServiceProvider chainedServiceProvider;

		/// <summary>
		/// Creates new <see cref="ApplicationBuilder"/>. Which is starting point of app building.
		/// </summary>
		public ApplicationBuilder()
		{
		}

		/// <summary>
		/// Starts dependency injection building
		/// with initial <see cref="IServiceProvider"/>
		/// </summary>
		/// <param name="serviceProvider"></param>
		/// <returns></returns>
		public virtual InitializedApplicationBuilder<TProvider> AddServiceProvider<TProvider>(TProvider serviceProvider)
			where TProvider : IServiceProvider
		{
			return this.UseSubcontractor(serviceProvider, (turn) => new InitializedApplicationBuilder<TProvider>(turn));
		}

		/// <summary>
		/// Passes application building to specified <see cref="InitializedApplicationBuilder{TProvider}"/>
		/// adding specified <paramref name="provider"/> to providers chain
		/// </summary>
		/// <typeparam name="TBuilder"></typeparam>
		/// <typeparam name="TProvider"></typeparam>
		/// <param name="provider"></param>
		/// <param name="factoryMethod"></param>
		/// <returns></returns>
		public TBuilder UseSubcontractor<TBuilder, TProvider>(TProvider provider, Func<ApplicationBuildingTurn<TProvider>, TBuilder> factoryMethod) 
			where TProvider : IServiceProvider
			where TBuilder : InitializedApplicationBuilder<TProvider>
		{
			this.AddProviderToChain(provider);
			return factoryMethod(new ApplicationBuildingTurn<TProvider>(this.chainedServiceProvider, provider));
		}

		internal virtual void AddProviderToChain(IServiceProvider serviceProvider)
		{
			this.chainedServiceProvider = new ChainedServiceProvider(serviceProvider);
		}
	}


}
