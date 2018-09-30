using Empowered.ApplicationConfiguration;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Empowered.ApplicationConfiguration
{
	[TestClass]
	public class ServiceProvider_CreatedBy_ApplicationBuilder_WithSimpleChaining_Should : ServiceProvider_FromApplicationBuilder_Tests
	{
		private IServiceProvider serviceProviderFromApplicationBuilder => new ApplicationBuilder()
			.AddServiceProvider(this.testSubprovider1)
			.AddServiceProvider(this.testSubprovider2)
			.AddServiceProvider(this.testSubprovider3)
			.CreateServiceProvider();

		[TestMethod]
		public void ReturnNull_WhenNoSubproviderCreatesSpecifiedService()
		{
			A.CallTo(() => this.testSubprovider1.GetService(typeof(ITestService))).Returns(null);
			A.CallTo(() => this.testSubprovider2.GetService(typeof(ITestService))).Returns(null);
			A.CallTo(() => this.testSubprovider3.GetService(typeof(ITestService))).Returns(null);

			var service = this.serviceProviderFromApplicationBuilder.GetService(typeof(ITestService));

			Assert.IsNull(service);
		}

		[TestMethod]
		public void ReturnServiceFromFirstProvider_WhenAllSubprovidersCreatesSpecifiedService()
		{
			A.CallTo(() => this.testSubprovider1.GetService(typeof(ITestService))).Returns(fakeImplementation1);
			A.CallTo(() => this.testSubprovider2.GetService(typeof(ITestService))).Returns(fakeImplementation2);
			A.CallTo(() => this.testSubprovider3.GetService(typeof(ITestService))).Returns(fakeImplementation3);

			var service = this.serviceProviderFromApplicationBuilder.Get<ITestService>();

			Assert.AreEqual(fakeImplementation1, service);
		}

		[TestMethod]
		public void ReturnServiceFromLastProvider_WhenOnlyLastSubproviderCreatesSpecifiedService()
		{
			A.CallTo(() => this.testSubprovider1.GetService(typeof(ITestService))).Returns(null);
			A.CallTo(() => this.testSubprovider2.GetService(typeof(ITestService))).Returns(null);
			A.CallTo(() => this.testSubprovider3.GetService(typeof(ITestService))).Returns(fakeImplementation3);

			var service = this.serviceProviderFromApplicationBuilder.Get<ITestService>();

			Assert.AreEqual(fakeImplementation3, service);
		}
	}
}
