using Empowered.ApplicationConfiguration;
using Empowered.ApplicationConfiguration.Ninjecting;
using Empowered.ApplicationConfiguration.Ninjecting.XForms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Tests.Empowered.ApplicationConfiguration.Ninjecting.XForms
{
	[TestClass]
	public class ApplicationBuilder_StartXamarinFormsApp_Should : ApplicationBuilder_WithXForms_Tests
	{
		[TestMethod]
		public void AddCreatedServiceProviderToResources()
		{
			new ApplicationBuilder()
				.StartNinjecting()
				.AddXamarinFormsServices(this.configuration)
				.StartXFormAppFrom<TestStartingViewModel>();

			Assert.IsNotNull(Application.Current.Resources["ServiceProvider"]);
		}
	}
}
