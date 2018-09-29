using System;
using Empowered.DependencyInjection;
using Empowered.DependencyInjection.Ninject;
using Empowered.UI.Native;
using Empowered.UI.Native.XForms;
using Empowered.UI.Native.XForms.Navigation;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmpoweredXamarinForms.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var navBindings = A.Fake<INavigationBindings>();

			new DependencyInjectionBuilder()
				.StartNinjecting()
				.UseXFormsServices(navBindings)
				.StartXFormsAppFrom<IViewModel>();
		}

	}
}
