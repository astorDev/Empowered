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
		/// associated with specified viewmodel.
		/// Also adds <see cref="IServiceProvider"/> to application resources
		/// by key "ServiceProvider"
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		void StartFrom<TViewModel>() where TViewModel : IViewModel;
	}
}
