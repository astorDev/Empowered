using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Empowered.UI.Native.XForms.Navigation
{
	/// <summary>
	/// Provides basic abstract implementation of <see cref="INavigationBindings"/>.
	/// Base class should override <see cref="Register"/> with use of <see cref="Bind{TViewModel, TPage}"/> protected method
	/// to register all viewmodel-page associations required for an app. 
	/// </summary>
	public abstract class NavigationBindings : INavigationBindings
	{
		private Dictionary<Type, Type> viewModelPages = new Dictionary<Type, Type>();
		private bool isRegistered;

		/// <summary>
		/// This method should be overriden in base class in order to register
		/// all reguired ViewModel-Page associations
		/// </summary>
		protected abstract void Register();

		/// <summary>
		/// Executed <see cref="Register"/> if it wasnt executed and
		/// creates of instance of Page associated with passed viewmodel type
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <returns></returns>
		public Page GetPageFor<TViewModel>() where TViewModel : IViewModel
		{
			if (!this.isRegistered)
			{
				this.Register();
				this.isRegistered = true;
			}

			return (Page)Activator.CreateInstance(viewModelPages[typeof(TViewModel)]);
		}

		/// <summary>
		/// Associates passed viewmodel type to passed page type
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <typeparam name="TPage"></typeparam>
		protected void Bind<TViewModel, TPage>()
			where TViewModel : IViewModel
			where TPage : Page
		{
			viewModelPages.Add(typeof(TViewModel), typeof(TPage));
		}
	}
}
