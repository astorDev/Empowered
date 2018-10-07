using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.ApplicationConfiguration.Ninjecting.XForms
{
	public static class XFormsServicesNinjectedApplicationBuilderExtensions
	{
		/// <summary>
		/// Adds xamarin forms services with specified
		/// app-specific configuration and returns <see cref="NinjectApplicationBuilderWithXFormsServices"/>
		/// which is capable of starting xamarin forms application
		/// </summary>
		/// <typeparam name="TBuilder"></typeparam>
		/// <param name="builder"></param>
		/// <param name="servicesConfiguration"></param>
		/// <returns></returns>
		public static NinjectApplicationBuilderWithXFormsServices AddXamarinFormsServices<TBuilder>
			(this NinjectedApplicationBuilder<TBuilder> builder,
			IXFormsServicesConfiguration servicesConfiguration)
			where TBuilder : NinjectedApplicationBuilder<TBuilder>
		{
			builder.Add(new XFormsServicesNinjectModule(servicesConfiguration));
			return builder.UseSubcontractor(turn => new NinjectApplicationBuilderWithXFormsServices(turn));
		}
	}
}
