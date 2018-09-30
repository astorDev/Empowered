﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.ApplicationConfiguration.Ninjecting
{
	/// <summary>
	/// Wrapper over <see cref="IKernel"/>
	/// eliminating exceptions in <see cref="GetService(Type)"/>
	/// by returning null when kernel cannot resolve type
	/// </summary>
	public class KernelServiceProviderWrapper : IServiceProvider
	{
		/// <summary>
		/// Underlying <see cref="IKernel"/>
		/// </summary>
		public readonly IKernel Kernel;

		/// <summary>
		/// Wraps kernel for safe <see cref="GetService(Type)"/>
		/// </summary>
		/// <param name="kernel"></param>
		public KernelServiceProviderWrapper(IKernel kernel)
		{
			this.Kernel = kernel;
		}

		/// <summary>
		/// Checks <see cref="IKernel.CanResolve"/> returning null if cannot
		/// then calls <see cref="IServiceProvider.GetService(Type)"/> on kernel
		/// </summary>
		/// <param name="serviceType"></param>
		/// <returns></returns>
		public object GetService(Type serviceType)
		{
			if (!this.Kernel.CanResolve(serviceType)) return null;

			return this.Kernel.GetService(serviceType);
		}
	}
}
