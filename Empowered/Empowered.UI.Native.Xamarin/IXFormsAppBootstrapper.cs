using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.UI.Native.XForms
{
	/// <summary>
	/// Starts xamarin forms application
	/// in mvvm fashion
	/// </summary>
	public interface IXFormsAppBootstrapper
	{
		/// <summary>
		/// Starts xamarin forms application from page
		/// associated with specified viewmodel
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		void StartXFormsAppFrom<TViewModel>() where TViewModel : IViewModel;
	}
}
