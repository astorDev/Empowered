using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.UI
{
	/// <summary>
	/// The most primitive implementation of <see cref="IConverterToString{T}"/> interfaces
	/// which simply uses <see cref="object.ToString"/> method for conversion
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class SimplestConverterToString<T> : IConverterToString<T>
	{
		/// <summary>
		/// Retuns value return by <see cref="object.ToString"/> method
		/// of passed <paramref name="source"/>
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public string GetStringFrom(T source)
		{
			return source.ToString();
		}
	}
}
