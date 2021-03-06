﻿using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.ApplicationConfiguration.Tests
{
	public interface ITestService
	{
		void DoNothing();
	}

	public class ServiceProvider_FromApplicationBuilder_Tests
	{
		protected readonly IServiceProvider testSubprovider1 = A.Fake<IServiceProvider>();
		protected readonly IServiceProvider testSubprovider2 = A.Fake<IServiceProvider>();
		protected readonly IServiceProvider testSubprovider3 = A.Fake<IServiceProvider>();

		protected readonly ITestService fakeImplementation1 = A.Fake<ITestService>();
		protected readonly ITestService fakeImplementation2 = A.Fake<ITestService>();
		protected readonly ITestService fakeImplementation3 = A.Fake<ITestService>();
	}
}
