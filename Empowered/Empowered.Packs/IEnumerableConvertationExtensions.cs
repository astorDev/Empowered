using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empowered.Packs
{
	/// <summary>
	/// Extensions for converting from ienumerable
	/// </summary>
	public static class IEnumerableConvertationExtensions
	{
		/// <summary>
		/// Converts source <see cref="IEnumerable{}"/> to <see cref="ObservableCollection{TTarget}"/>
		/// <para />
		/// This method uses constructor of <see cref="ObservableCollection{TTarget}"/> accepting <see cref="IEnumerable{TTarget}"/>
		/// which is received by means of <see cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, int, TResult})"/>
		/// extension method that uses passed <paramref name="convertation"/>
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="TTarget"></typeparam>
		/// <param name="source"></param>
		/// <param name="convertation"></param>
		/// <returns></returns>
		public static ObservableCollection<TTarget> ConvertToObservable<TSource, TTarget>(this IEnumerable<TSource> source, Func<TSource, TTarget> convertation)
		{
			return new ObservableCollection<TTarget>(source.Select(i => convertation(i)));
		}
	}
}
