using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Empowered.ApplicationConfiguration.Tests
{
	[TestClass]
	public class ServiceProvider_CreatedBy_ApplicationBuilder_WithSimpleChaining_Should
	{
		public interface ITestService
		{
			void DoNothing();
		}

		private readonly IServiceProvider testSubprovider1 = A.Fake<IServiceProvider>();
		private readonly IServiceProvider testSubprovider2 = A.Fake<IServiceProvider>();
		private readonly IServiceProvider testSubprovider3 = A.Fake<IServiceProvider>();

		private readonly ITestService fakeImplementation1 = A.Fake<ITestService>();
		private readonly ITestService fakeImplementation2 = A.Fake<ITestService>();
		private readonly ITestService fakeImplementation3 = A.Fake<ITestService>();

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

			var service = this.serviceProviderFromApplicationBuilder.GetService(typeof(ITestService));

			Assert.AreEqual(fakeImplementation1, service);
		}

		[TestMethod]
		public void ReturnServiceFromLastProvider_WhenOnlyLastSubproviderCreatesSpecifiedService()
		{
			A.CallTo(() => this.testSubprovider1.GetService(typeof(ITestService))).Returns(null);
			A.CallTo(() => this.testSubprovider2.GetService(typeof(ITestService))).Returns(null);
			A.CallTo(() => this.testSubprovider3.GetService(typeof(ITestService))).Returns(fakeImplementation3);

			var service = this.serviceProviderFromApplicationBuilder.GetService(typeof(ITestService));

			Assert.AreEqual(fakeImplementation3, service);
		}
	}
}
