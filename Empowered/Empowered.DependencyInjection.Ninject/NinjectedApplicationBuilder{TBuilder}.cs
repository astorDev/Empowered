using Empowered.ApplicationConfiguration;
using Empowered.ApplicationConfiguration.Ninjecting;
using Ninject;
using Ninject.Modules;

namespace Empowered.ApplicationConfiguration.Ninjecting
{
	/// <summary>
	/// <see cref="InitializedApplicationBuilder{TMyProvider}"/> supporting ninject.
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
		/// </summary>
		/// <param name="builder"></param>
		internal protected NinjectedApplicationBuilder(ApplicationBuildingTurn<KernelServiceProviderWrapper> turn) : base(turn)
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
}
