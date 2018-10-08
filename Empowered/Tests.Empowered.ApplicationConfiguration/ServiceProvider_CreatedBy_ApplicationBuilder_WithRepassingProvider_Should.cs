using Empowered.ApplicationConfiguration;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Empowered.ApplicationConfiguration
{
	[TestClass]
	public class ServiceProvider_CreatedBy_ApplicationBuilder_WithRepassingProvider_Should : ServiceProvider_FromApplicationBuilder_Tests
	{
		[TestMethod]
		public void UseServiceProvider_FromBuilder_WhichRepassedIt_Normally()
		{
			A.CallTo(() => this.testSubprovider1.GetService(typeof(ITestService))).Returns(this.fakeImplementation1);

			var provider = new ApplicationBuilder()
				.UseSubcontractor(this.testSubprovider1, t => new InitializedApplicationBuilder<IServiceProvider>(t))
				.UseSubcontractor(t => new InitializedApplicationBuilder<IServiceProvider>(t))
				.CreateServiceProvider();

			var service = provider.Get<ITestService>();

			Assert.AreEqual(this.fakeImplementation1, service);
		}
	}
}
