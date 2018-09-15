using Empowered.UI.Native.Abstractions;
using System;
using Xamarin.Forms;

namespace Empowered.UI.Native.XForms.Navigation
{
	/// <summary>
	/// Xamarin forms based implementation of <see cref="INavigator"/>
	/// used for mvvm-based navigation
	/// </summary>
	public class Navigator : INavigator
	{
		private INavigation Navigation => Application.Current.MainPage.Navigation;

		/// <summary>
		/// Viewmodel-page asssociations for navigator
		/// </summary>
		public readonly INavigationBindings Bindings;

		/// <summary>
		/// Creates Xamarin forms navigator that
		/// gets page associated from passed viewmodel
		/// from passed bindings
		/// </summary>
		/// <param name="bindings"></param>
		public Navigator(INavigationBindings bindings)
		{
			this.Bindings = bindings;
		}

		/// <summary>
		/// Synchroniously executes <see cref="INavigation.PopModalAsync"/>
		/// </summary>
		public void GoBackFromActionable()
		{
			this.Navigation.PopModalAsync().GetAwaiter().GetResult();
		}

		/// <summary>
		/// Syncroniously executes <see cref="INavigation.PushModalAsync(Page)"/>
		/// on <see cref="T:Page"/> associated with passed viewmodel type in this <see cref="INavigationBindings"/>
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		public void GoToActionable<TViewModel>() where TViewModel : IViewModel
		{
			var pageForAction = this.Bindings.GetPageFor<TViewModel>();
			this.Navigation.PushModalAsync(pageForAction).GetAwaiter().GetResult();
		}

		/// <summary>
		/// Sets main page of xamarin app to page associated with passed view model
		/// Note that this method considered to be xamarin-specific so it should only be used in xamarin forms app
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		public void StartWithNavigationPageFor<TViewModel>() where TViewModel : IViewModel
		{
			Application.Current.MainPage = new NavigationPage(this.Bindings.GetPageFor<TViewModel>());
		}
	}
}
