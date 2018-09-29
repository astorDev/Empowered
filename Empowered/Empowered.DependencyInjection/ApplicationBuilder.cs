using System;

namespace Empowered.ApplicationConfiguration
{
	/// <summary>
	/// Builds dependency injection 
	/// with help of <see cref="ChainedServiceProvider"/>
	/// </summary>
	public class ApplicationBuilder
	{
		internal ChainedServiceProvider chainedServiceProvider;
		internal object nextProvider;

		/// <summary>
		/// Creates new <see cref="ApplicationBuilder"/>
		/// which should be used as starting point for dependency injection based app configuration
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
			return this.UseSubcontractor(serviceProvider, (builder) => new InitializedApplicationBuilder<TProvider>(builder));
		}

		/// <summary>
		/// Passes application building to specified <typeparamref name="TBuilder"/>
		/// created by <paramref name="factoryMethod"/> utilizing specified <typeparamref name="TProvider"/>
		/// </summary>
		/// <typeparam name="TBuilder"></typeparam>
		/// <typeparam name="TProvider"></typeparam>
		/// <param name="provider"></param>
		/// <param name="factoryMethod"></param>
		/// <returns></returns>
		public virtual TBuilder UseSubcontractor<TBuilder, TProvider>(TProvider provider, Func<ApplicationBuilder, TBuilder> factoryMethod) 
			where TProvider : IServiceProvider
			where TBuilder : InitializedApplicationBuilder<TProvider>
		{
			this.addProviderToChain(provider);
			this.nextProvider = provider;
			return factoryMethod(this);
		}

		internal virtual void addProviderToChain(IServiceProvider serviceProvider)
		{
			this.chainedServiceProvider = new ChainedServiceProvider(serviceProvider);
		}
	}


}
