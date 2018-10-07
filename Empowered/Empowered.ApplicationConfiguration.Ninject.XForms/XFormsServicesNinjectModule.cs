using Empowered.UI.Native.Abstractions;
using Empowered.UI.Native.XForms.Navigation;
using Ninject.Modules;

namespace Empowered.ApplicationConfiguration.Ninjecting.XForms
{
	/// <summary>
	/// Ninject module that associates all ui services abstractions
	/// from Empowered.UI.Native.Abstractions 
	/// with implementations from Empowered.UI.Native.XForms
	/// </summary>
	public class XFormsServicesNinjectModule : NinjectModule
	{
		/// <summary>
		/// App-specific association of pages and viewmodels
		/// </summary>
		public IXFormsServicesConfiguration Configuration;

		/// <summary>
		/// Creates xamarin services ninject module
		/// with use of app specific configuration-like objects
		/// passed as constructor arguments
		/// </summary>
		/// <param name="navigationBindings">App-specific implementation of <see cref="INavigationBindings"/></param>
		public XFormsServicesNinjectModule(IXFormsServicesConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		/// <summary>
		/// Associates all ui services abstractions
		/// from Empowered.UI.Native.Abstractions 
		/// with implementations from Empowered.UI.Native.XForms
		/// </summary>
		public override void Load()
		{
			this.Bind<Navigator>().ToSelf().InSingletonScope();
			this.Bind<INavigator>().To<Navigator>().InSingletonScope();
			this.Bind<INavigationBindings>().ToConstant(this.Configuration.NavigationBindings);
		}
	}


}
