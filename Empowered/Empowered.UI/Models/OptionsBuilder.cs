using Empowered.Packs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empowered.UI.Models
{
	/// <summary>
	/// Builder that could be used for constructing
	/// <see cref="ObservableCollection{Option{TKey}}"/> 
	/// </summary>
	public class OptionsBuilder<TKey>
	{
		protected List<OptionPrototype<TKey>> prototypes = new List<OptionPrototype<TKey>>();
		protected IConverterToString<Option<TKey>> customConverter;

		/// <summary>
		/// Adds key-displayValue pair for future addition to <see cref="ObservableCollection{Option{TKey}}"/>
		/// in <see cref="CreateOptions"/>
		/// </summary>
		/// <param name="key"></param>
		/// <param name="displayValue"></param>
		/// <returns></returns>
		public OptionsBuilder<TKey> UsePair(TKey key, string displayValue)
		{
			this.prototypes.Add(new OptionPrototype<TKey> { Key = key, DisplayValue = displayValue });

			return this;
		}

		/// <summary>
		/// Uses converter for all created options
		/// <para />
		/// technically by passing it to constructor in <see cref="CreateOptions"/>
		/// </summary>
		/// <param name="converter"></param>
		/// <returns></returns>
		public OptionsBuilder<TKey> UseCustomConverter(IConverterToString<Option<TKey>> converter)
		{
			this.customConverter = converter;

			return this;
		}


		/// <summary>
		/// Creates options configured previously
		/// </summary>
		/// <returns></returns>
		public ObservableCollection<Option<TKey>> CreateOptions()
		{
			return this.customConverter == null ?
				this.prototypes.ConvertToObservable(p => p.ToOption())
				: this.prototypes.ConvertToObservable(p => p.ToOption(customConverter));
		}

		protected class OptionPrototype<T>
		{
			public string DisplayValue { get; set; }
			public T Key { get; set; }

			public Option<T> ToOption(IConverterToString<Option<T>> converterToString)
			{
				return new Option<T>(converterToString);
			}

			public Option<T> ToOption()
			{
				return new Option<T>();
			}
		}
	}
}
