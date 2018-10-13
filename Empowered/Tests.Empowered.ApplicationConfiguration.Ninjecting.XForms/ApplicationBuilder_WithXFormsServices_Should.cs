using Empowered.ApplicationConfiguration;
using Empowered.ApplicationConfiguration.Ninjecting;
using Empowered.ApplicationConfiguration.Ninjecting.XForms;
using Empowered.UI.Native.Abstractions;
using Empowered.UI.Native.XForms.Navigation;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace Tests.Empowered.ApplicationConfiguration.Ninjecting.XForms
{
	[TestClass]
	public class ApplicationBuilder_WithXFormsServices_Should : ApplicationBuilder_WithXForms_Tests
	{


		[TestMethod]
		public void SetCorrectMainPage_OnStartApp()
		{
			var startingPage = new TestStartingPage();

			A.CallTo(() => this.bindings.GetPageFor<TestStartingViewModel>()).Returns(startingPage);
			A.CallTo(() => this.configuration.NavigationBindings).Returns(bindings);


			new ApplicationBuilder()
				.StartNinjecting()
				.AddXamarinFormsServices(this.configuration)
				.StartXFormAppFrom<TestStartingViewModel>();

			Assert.AreEqual(startingPage, ((NavigationPage)Application.Current.MainPage).RootPage);
		}

		[TestMethod]
		public void CreateProvider_ThatCanGetNavigator()
		{
			var provider = new ApplicationBuilder()
				.StartNinjecting()
				.AddXamarinFormsServices(configuration)
				.CreateServiceProvider();

			var navigator = provider.Get<Navigator>();

			Assert.IsNotNull(navigator);
			Assert.IsInstanceOfType(navigator, typeof(Navigator));
		}

		[TestMethod]
		public void CreateProvider_ThatCanGetINavigator()
		{
			var provider = new ApplicationBuilder()
				.StartNinjecting()
				.AddXamarinFormsServices(configuration)
				.CreateServiceProvider();

			var navigator = provider.Get<INavigator>();

			Assert.IsNotNull(navigator);
			Assert.IsInstanceOfType(navigator, typeof(Navigator));
		}
	}
}
