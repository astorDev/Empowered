using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.ApplicationConfiguration
{
	/// <summary>
	/// Extensions for <see cref="IServiceProvider"/>
	/// </summary>
	public static class IServiceProviderExtensions
	{
		/// <summary>
		/// Retuns strongly-typed result of <see cref="IServiceProvider.GetService(Type)"/>
		/// with null check
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="serviceProvider"></param>
		/// <returns></returns>
		public static T Get<T>(this IServiceProvider serviceProvider)
		{
			var serviceObject = serviceProvider.GetService(typeof(T));
			if (serviceObject == null) throw new TypeLoadException("GetService method returned null");

			return (T)serviceObject;
		}
	}
}
