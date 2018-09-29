using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Empowered.ApplicationConfiguration
{
	/// <summary>
	/// Implementation of <see cref="IServiceProvider"/> 
	/// that is collection of inner service providers.
	/// <para>On <see cref="GetService(Type)"/> sequentially tries to recieve service from inner providers.</para>
	/// </summary>
	internal class ChainedServiceProvider : Collection<IServiceProvider>, IServiceProvider
	{
		/// <summary>
		/// Constructs <see cref="ChainedServiceProvider"/>
		/// with initial <see cref="IServiceProvider"/>
		/// </summary>
		/// <param name="firstServiceProvider"></param>
		internal ChainedServiceProvider(IServiceProvider firstServiceProvider)
		{
			this.Add(firstServiceProvider);
		}

		/// <summary>
		/// Seeks GetService from providers in inner array
		/// untill array is over or service is received.
		/// </summary>
		/// <param name="serviceType"></param>
		/// <returns>
		/// Service instance from first inner providers that can provide it
		/// or null if no inner service can.
		/// </returns>
		public object GetService(Type serviceType)
		{
			object service = null;
			var innerProviderIndex = 0;

			while(innerProviderIndex < this.Count && service == null)
			{
				service = this[innerProviderIndex].GetService(serviceType);
				innerProviderIndex++;
			}
			 
			return service;
		}
	}
}
