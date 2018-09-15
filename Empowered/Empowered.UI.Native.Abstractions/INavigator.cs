using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.UI.Native.Abstractions
{
	/// <summary>
	/// Handles navigation in MVVM-based application. 
	/// Makes navigation platform-independent 
	/// by using viewmodels as navigation targets instead of platform-specific pages. 
	/// </summary>
	public interface INavigator
	{
		/// <summary>
		/// Opens view associated with viewmodel that is single-action by nature
		/// </summary>
		/// <typeparam name="T">Type of viewmodel which associated view is to be shown</typeparam>
		void GoToActionable<T>() where T : IViewModel;

		/// <summary>
		/// This method should only be executed after <see cref="GoToActionable{T}"/>
		/// so that it closes view that was shown by that method and goes back to previous view
		/// </summary>
		void GoBackFromActionable();
	}
}
