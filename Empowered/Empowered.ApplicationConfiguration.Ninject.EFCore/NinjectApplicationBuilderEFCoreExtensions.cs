using Empowered.ApplicationConfiguration.Ninjecting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.ApplicationConfiguration.Ninject.EFCore
{
	public static class NinjectApplicationBuilderEFCoreExtensions
	{
		/// <summary>
		/// Calls <see cref="Use{TDbContext, TBuilder}(NinjectedApplicationBuilder{TBuilder}, Func{DbContextOptionsBuilder{TDbContext}, DbContextOptionsBuilder{TDbContext}})"/>
		/// And than migrated resolved context
		/// </summary>
		/// <typeparam name="TDbContext"></typeparam>
		/// <typeparam name="TBuilder"></typeparam>
		/// <param name="builder"></param>
		/// <param name="optionsConfiguration"></param>
		/// <returns></returns>
		public static NinjectedApplicationBuilder<TBuilder> UseAndMigrate<TDbContext, TBuilder>
			(this NinjectedApplicationBuilder<TBuilder> builder
			, Func<DbContextOptionsBuilder<TDbContext>, DbContextOptionsBuilder<TDbContext>> optionsConfiguration)
			where TBuilder : NinjectedApplicationBuilder<TBuilder>
			where TDbContext : DbContext
		{
			builder = Use(builder, optionsConfiguration);
			builder.Kernel.Get<TDbContext>().Database.Migrate();

			return builder;
		}

		/// <summary>
		/// Injects specified <see cref="DbContext"/> with configured <see cref="DbContextOptions"/>
		/// </summary>
		/// <typeparam name="TDbContext"></typeparam>
		/// <typeparam name="TBuilder"></typeparam>
		/// <param name="builder"></param>
		/// <param name="optionsConfiguration"></param>
		/// <returns></returns>
		public static NinjectedApplicationBuilder<TBuilder> Use<TDbContext, TBuilder>
			(this NinjectedApplicationBuilder<TBuilder> builder
			, Func<DbContextOptionsBuilder<TDbContext>, DbContextOptionsBuilder<TDbContext>> optionsConfiguration)
			where TBuilder : NinjectedApplicationBuilder<TBuilder>
			where TDbContext : DbContext
		{
			var options = optionsConfiguration(new DbContextOptionsBuilder<TDbContext>()).Options;

			builder.Kernel.Bind<TDbContext>().ToSelf().WithConstructorArgument(options);

			return builder;
		}
	}
}
