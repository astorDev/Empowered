using Empowered.ApplicationConfiguration;
using Empowered.ApplicationConfiguration.Ninjecting;
using Ninject;
using Ninject.Modules;

namespace Empowered.ApplicationConfiguration.Ninjecting
{
	/// <summary>
	/// Base generic <see cref="InitializedApplicationBuilder{TMyProvider}"/>
	/// which supports use of ninject.
	/// </summary>
	public abstract class NinjectedApplicationBuilder<TBuilder> : InitializedApplicationBuilder<KernelServiceProviderWrapper> where TBuilder : NinjectedApplicationBuilder<TBuilder>
	{
		/// <summary>
		/// <see cref="IKernel"/> being configured
		/// </summary>
		public IKernel Kernel => this.Provider.Kernel;

		/// <summary>
		/// Should be overriden to return this
		/// </summary>
		protected abstract TBuilder Self { get; }

		/// <summary>
		/// Creates new <see cref="NinjectedApplicationBuilder{TBuilder}"/>
		/// <para></para>
		/// Note: that method should only be used within 
		/// <see cref="ApplicationBuilder.UseSubcontractor{TBuilder, TProvider}(TProvider, System.Func{ApplicationBuilder, TBuilder})"/>
		/// factory method
		/// </summary>
		/// <param name="builder"></param>
		internal protected NinjectedApplicationBuilder(ApplicationBuilder builder) : base(builder)
		{
		}

		/// <summary>
		/// Loads specified module to manipulated <see cref="IKernel"/>
		/// </summary>
		/// <param name="module"></param>
		/// <returns></returns>
		public NinjectedApplicationBuilder<TBuilder> Add(INinjectModule module)
		{
			this.Kernel.Load(module);

			return this.Self;
		}
	}

	/// <summary>
	/// Base implementation of <see cref="NinjectedApplicationBuilder{TBuilder}"/>
	/// that should be used for ninject-based dependency injection
	/// </summary>
	public class NinjectedApplicationBuilder : NinjectedApplicationBuilder<NinjectedApplicationBuilder>
	{
		/// <summary>
		/// Returns this
		/// </summary>
		protected override NinjectedApplicationBuilder Self => this;

		internal NinjectedApplicationBuilder(ApplicationBuilder builder) : base(builder)
		{
		}

	}
}
