using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Empowered.ApplicationConfiguration.Ninjecting.EFCore
{
	public class TestDbContext : DbContext
	{
		public TestDbContext(DbContextOptions<TestDbContext> wronglyNamedOptions) : base(wronglyNamedOptions)
		{
		}

		public DbSet<TestTable> Records { get; set; }
	}
}
