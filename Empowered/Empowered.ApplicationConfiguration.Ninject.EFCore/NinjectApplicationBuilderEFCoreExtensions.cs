using Empowered.ApplicationConfiguration.Ninjecting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.ApplicationConfiguration.Ninject.EFCore
{
	public static class NinjectApplicationBuilderEFCoreExtensions
	{
		public static NinjectedApplicationBuilder<TBuilder> UseAndMigrate<TDbContext, TBuilder>(NinjectedApplicationBuilder<TBuilder> builder, Func<DbContextOptionsBuilder<TDbContext>, DbContextOptionsBuilder<TDbContext>> optionsConfiguration)
			where TBuilder : NinjectedApplicationBuilder<TBuilder>
			where TDbContext : DbContext
		{
			var options = optionsConfiguration(new DbContextOptionsBuilder<TDbContext>()).Options;

			builder.Kernel.Bind<TDbContext>().ToSelf().WithConstructorArgument(options);
			builder.Kernel.Get<TDbContext>().Database.Migrate();

			return builder;
		}
	}
}
