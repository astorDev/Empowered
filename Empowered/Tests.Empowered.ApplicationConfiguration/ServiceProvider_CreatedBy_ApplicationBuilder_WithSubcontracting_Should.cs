using Empowered.ApplicationConfiguration;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Empowered.ApplicationConfiguration
{
	[TestClass]
	public class ServiceProvider_CreatedBy_ApplicationBuilder_WithSubcontracting_Should : ServiceProvider_FromApplicationBuilder_Tests
	{
		[TestMethod]
		public void UseSubprovider_FromSubcontractor()
		{
			A.CallTo(() => this.testSubprovider1.GetService(typeof(ITestService))).Returns(this.fakeImplementation1);

			var chainedProvider = new ApplicationBuilder()
									.UseSubcontractor(this.testSubprovider1, b => new InitializedApplicationBuilder<IServiceProvider>(b))
									.CreateServiceProvider();

			var service = chainedProvider.Get<ITestService>();

			Assert.AreEqual(this.fakeImplementation1, service);
		}
	}
}
