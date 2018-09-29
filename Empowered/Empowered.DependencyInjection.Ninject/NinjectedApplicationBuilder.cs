using Empowered.ApplicationConfiguration;
using Ninject;
using Ninject.Modules;

namespace Empowered.DependencyInjection.Ninject
{
	/// <summary>
	/// Base generic <see cref="InitializedApplicationBuilder{TMyProvider}"/>
	/// which supports use of ninject.
	/// </summary>
	public abstract class NinjectedApplicationBuilder<TBuilder> : InitializedApplicationBuilder<IKernel> where TBuilder : NinjectedApplicationBuilder<TBuilder>
	{
		/// <summary>
		/// <see cref="IKernel"/> being configured
		/// </summary>
		public IKernel Kernel => this.Provider;

		/// <summary>
		/// Should be overriden to return <see cref="this"/>
		/// </summary>
		protected abstract TBuilder Self { get; }

		public NinjectedApplicationBuilder(ApplicationBuilder builder) : base(builder)
		{
		}

		/// <summary>
		/// Loads specified module to manipulated <see cref="IKernel"/>
		/// </summary>
		/// <param name="module"></param>
		/// <returns></returns>
		public NinjectedApplicationBuilder<TBuilder> Add(INinjectModule module)
		{
			this.Provider.Load(module);

			return this.Self;
		}
	}

	/// <summary>
	/// Base implementation of <see cref="NinjectedApplicationBuilder{TBuilder}"/>
	/// that should be used for ninject-based dependency injection
	/// </summary>
	public class NinjectedApplicationBuilder : NinjectedApplicationBuilder<NinjectedApplicationBuilder>
	{
		protected override NinjectedApplicationBuilder Self => this;

		internal NinjectedApplicationBuilder(ApplicationBuilder builder) : base(builder)
		{
		}

	}
}
