using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Empowered.ApplicationConfiguration.Ninjecting.EFCore
{
	public class TestDbContextFactory : IDesignTimeDbContextFactory<TestDbContext>
	{
		public TestDbContext CreateDbContext(string[] args)
		{
			var options = new DbContextOptionsBuilder<TestDbContext>()
				.UseSqlite("this is just fake connection string")
				.Options;

			return new TestDbContext(options);
		}
	}
}
