using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.UI
{
	/// <summary>
	/// Generic interface for object that can can convert
	/// object of type <see cref="T"/> to string
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IConverterToString<T>
	{
		/// <summary>
		/// Returns string representation of an object
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		string GetStringFrom(T source);
	}
}
