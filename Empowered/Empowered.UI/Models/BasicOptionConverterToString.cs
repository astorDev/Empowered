using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.UI.Models
{
	/// <summary>
	/// Basic converter from option to string - just returns <see cref="Option{TKey}.DisplayValue"/> 
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	public class BasicOptionConverterToString<TKey> : IConverterToString<Option<TKey>>
	{
		/// <summary>
		/// Returns <see cref="Option{TKey}.DisplayValue"/> of passed source
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public string GetStringFrom(Option<TKey> source)
		{
			return source.DisplayValue;
		}
	}
}
