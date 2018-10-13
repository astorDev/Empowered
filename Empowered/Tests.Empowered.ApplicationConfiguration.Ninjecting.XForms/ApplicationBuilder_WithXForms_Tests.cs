using Empowered.ApplicationConfiguration.Ninjecting.XForms;
using Empowered.UI.Native.XForms.Navigation;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace Tests.Empowered.ApplicationConfiguration.Ninjecting.XForms
{
	public class ApplicationBuilder_WithXForms_Tests
	{
		protected readonly INavigationBindings bindings = A.Fake<INavigationBindings>();
		protected readonly IXFormsServicesConfiguration configuration = A.Fake<IXFormsServicesConfiguration>();

		[TestInitialize]
		public void StartApp()
		{
			MockForms.Init();
			Application.Current = new App();
		}

	}
}
