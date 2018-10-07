using Empowered.UI.Native.XForms.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.ApplicationConfiguration.Ninjecting.XForms
{
	/// <summary>
	/// Set of configuration objects
	/// required for registering Xamarin forms services
	/// </summary>
	public interface IXFormsServicesConfiguration
	{
		/// <summary>
		/// App-specific navigation bindings
		/// </summary>
		INavigationBindings NavigationBindings { get; }
	}
}
