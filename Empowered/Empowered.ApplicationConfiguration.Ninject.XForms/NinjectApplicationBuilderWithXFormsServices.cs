using Empowered.UI.Native;
using Empowered.UI.Native.XForms.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Empowered.ApplicationConfiguration.Ninjecting.XForms
{
	public class NinjectApplicationBuilderWithXFormsServices : NinjectedApplicationBuilder<NinjectApplicationBuilderWithXFormsServices>
	{
		protected override NinjectApplicationBuilderWithXFormsServices Self => this;

		protected internal NinjectApplicationBuilderWithXFormsServices(ApplicationBuildingTurn<KernelServiceProviderWrapper> turn) 
			: base(turn)
		{
		}

		/// <summary>
		/// Starts Xamarin Forms App from navigation page
		/// for page associated with specified view model
		/// and adds ServiceProvider to app resources
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <returns></returns>
		public IServiceProvider StartXFormAppFrom<TViewModel>()
			where TViewModel : IViewModel
		{
			var provider = this.CreateServiceProvider();
			Application.Current.Resources.Add("ServiceProvider", provider);
			var navigator = provider.Get<Navigator>();
			navigator.StartWithNavigationPageFor<TViewModel>();
			
			return provider;
		}
	}
}
