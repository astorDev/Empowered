using Empowered.ApplicationConfiguration;
using Empowered.ApplicationConfiguration.Ninjecting;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Empowered.ApplicationConfiguration.Ninject
{
	[TestClass]
	public class ServiceProvider_FromApplicationBuilder_WithNinject_Should : ServiceProvider_FromApplicationBuilder_Tests
	{
		[TestMethod]
		public void GetDependencyFromNextSubprovider_IfNinjectHaventGotIt()
		{
			A.CallTo(() => this.testSubprovider1.GetService(typeof(ITestService))).Returns(this.fakeImplementation1);

			var provider = new ApplicationBuilder()
				.StartNinjecting()
				//not registering anything in ninject
				.AddServiceProvider(this.testSubprovider1)
				.CreateServiceProvider();

			var implementation = provider.Get<ITestService>();

			Assert.AreEqual(this.fakeImplementation1, implementation);
		}

		public class TestNinjectModule : NinjectModule
		{
			public readonly ITestService ConstantImplementation;

			public TestNinjectModule(ITestService constantImplementation)
			{
				this.ConstantImplementation = constantImplementation;
			}

			public override void Load()
			{
				this.Bind<ITestService>().ToConstant(this.ConstantImplementation);
			}
		}

		[TestMethod]
		public void GetDependencyFromNinject_WhenItFirstInChain()
		{
			A.CallTo(() => this.testSubprovider1.GetService(typeof(ITestService))).Returns(this.fakeImplementation1);

			var provider = new ApplicationBuilder()
				.StartNinjecting()
				.Add(new TestNinjectModule(this.fakeImplementation2))
				.AddServiceProvider(this.testSubprovider1)
				.CreateServiceProvider();

			var implementation = provider.Get<ITestService>();

			Assert.AreEqual(implementation, this.fakeImplementation2);
		}
	}
}
