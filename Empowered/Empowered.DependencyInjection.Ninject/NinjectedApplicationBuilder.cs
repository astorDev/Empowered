namespace Empowered.ApplicationConfiguration.Ninjecting
{
	/// <summary>
	/// Base implementation of <see cref="NinjectedApplicationBuilder{TBuilder}"/>
	/// that should be used for ninject-based dependency injection
	/// </summary>
	public class NinjectedApplicationBuilder : NinjectedApplicationBuilder<NinjectedApplicationBuilder>
	{
		internal NinjectedApplicationBuilder(ApplicationBuildingTurn<KernelServiceProviderWrapper> turn) : base(turn)
		{
		}

		/// <summary>
		/// Returns this
		/// </summary>
		protected override NinjectedApplicationBuilder Self => this;
	}
}
