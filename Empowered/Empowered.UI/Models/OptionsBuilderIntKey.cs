using Empowered.Packs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Empowered.UI.Models
{
	/// <summary>
	/// Standard non-generic version of <see cref="OptionsBuilder{TKey}"/>
	/// that uses <see cref="Int32"/> as key type
	/// </summary>
	public class OptionsBuilder : OptionsBuilder<int>
	{
		/// <summary>
		/// Uses all possible values when constructing options
		/// using for enum to string conversion <see cref="SimplestConverterToString{T}"/>
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="optionsBuilder"></param>
		/// <returns></returns>
		public OptionsBuilder UseAllPossibleValuesOf<TEnum>()
		{
			return this.UseAllPossibleValuesOf(new SimplestConverterToString<TEnum>());
		}

		/// <summary>
		/// Uses all possible values when constructing options
		/// with help of provided <paramref name="converterToString"/>
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="optionsBuilder"></param>
		/// <param name="converterToString"></param>
		/// <returns></returns>
		public OptionsBuilder UseAllPossibleValuesOf<TEnum>(IConverterToString<TEnum> converterToString)
		{
			foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
			{
				this.UsePair(Convert.ToInt32(value), converterToString.GetStringFrom(value));
			}

			return this;
		}

		public ObservableCollection<Option> CreateNonGenericOptions()
		{
			return this.customConverter == null ?
				this.prototypes.ConvertToObservable(p => new Option { Key = p.Key, DisplayValue = p.DisplayValue })
				: this.prototypes.ConvertToObservable(p => new Option(customConverter) { Key = p.Key, DisplayValue = p.DisplayValue });
		}

	}
}
