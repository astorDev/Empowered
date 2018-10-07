using Empowered.UI.Native;
using Empowered.UI.Native.XForms.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

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
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <returns></returns>
		public IServiceProvider StartXFormAppFrom<TViewModel>()
			where TViewModel : IViewModel
		{
			var provider = this.CreateServiceProvider();
			var navigator = provider.Get<Navigator>();
			navigator.StartWithNavigationPageFor<TViewModel>();

			return provider;
		}
	}
}
