using Empowered.UI.Native.Abstractions;
using Empowered.UI.Native.XForms.Navigation;
using Ninject.Modules;

namespace Empowered.UI.Native.XForms
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
		public INavigationBindings NavigationBindings;

		/// <summary>
		/// Creates xamarin services ninject module
		/// with use of app specific configuration-like objects
		/// passed as constructor arguments
		/// </summary>
		/// <param name="navigationBindings">App-specific implementation of <see cref="INavigationBindings"/></param>
		public XFormsServicesNinjectModule(INavigationBindings navigationBindings)
		{
			this.NavigationBindings = navigationBindings;
		}

		/// <summary>
		/// Associates all ui services abstractions
		/// from Empowered.UI.Native.Abstractions 
		/// with implementations from Empowered.UI.Native.XForms
		/// </summary>
		public override void Load()
		{
			this.Bind<INavigator>().To<Navigator>().InSingletonScope();
			this.Bind<INavigationBindings>().ToConstant(this.NavigationBindings);
		}
	}


}
