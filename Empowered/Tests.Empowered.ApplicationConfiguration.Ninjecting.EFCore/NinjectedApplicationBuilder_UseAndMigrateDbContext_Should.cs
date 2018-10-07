using Empowered.ApplicationConfiguration;
using Empowered.ApplicationConfiguration.Ninjecting;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Empowered.ApplicationConfiguration.Ninject.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Tests.Empowered.ApplicationConfiguration.Ninjecting.EFCore
{
	[TestClass]
	public class NinjectedApplicationBuilder_UseAndMigrateDbContext_Should
	{
		[TestInitialize]
		public void EnsureDatabaseNotExists()
		{
			var options = new DbContextOptionsBuilder<TestDbContext>().UseSqlite("Filename=mytest.db").Options;

			using (var context = new TestDbContext(options))
			{
				context.Database.EnsureDeleted();
			}
		}

		[TestMethod]
		public void MigrateDb_AddItToDependencyInjectionContainer_AccordingToOptionsConfiguration_WhenDbContextHaveSingleOptionsArgument()
		{
			var provider = new ApplicationBuilder()
				.StartNinjecting()
				.UseAndMigrate<TestDbContext, NinjectedApplicationBuilder>(options => options.UseSqlite("Filename=mytest.db"))
				.CreateServiceProvider();


			using (var context = provider.Get<TestDbContext>())
			{
				context.Add(new TestTable()
				{
					Id = 1,
					Name = "test",
					SomeDate = new DateTime(2018, 5, 5)
				});

				context.SaveChanges();
			}

			using (var context = provider.Get<TestDbContext>())
			{
				Assert.AreEqual(1, context.Records.Count());
			}
		}
	}
}
