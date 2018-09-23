using Empowered.DependencyInjection.Ninject;
using Empowered.UI.Native.XForms.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.UI.Native.XForms
{
	public static class XFormsDependencyInjectionBuilderExtension
	{
		public static IXFormsAppBootstrapper UseXFormsServices(this InitializedWithNinjectDependencyInjectionBuilder diBuilder, INavigationBindings navigationBindings)
		{
			var serviceProvider = diBuilder.Add(new XFormsServicesNinjectModule(navigationBindings)).CreateServiceProvider();

			return new XFormsAppBootstrapper(serviceProvider);
		}

		private class XFormsAppBootstrapper : IXFormsAppBootstrapper
		{
			private IServiceProvider serviceProvider;

			public XFormsAppBootstrapper(IServiceProvider serviceProvider)
			{
				this.serviceProvider = serviceProvider;
			}

			public void StartXFormsAppFrom<TViewModel>() where TViewModel : IViewModel
			{
				var navigator = (Navigator)this.serviceProvider.GetService(typeof(Navigator));
				navigator.StartWithNavigationPageFor<TViewModel>();
			}
		}
	}
}
