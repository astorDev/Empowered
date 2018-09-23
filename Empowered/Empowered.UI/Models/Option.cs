using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.UI.Models
{
	/// <summary>
	/// ViewModel for the option that can be selected
	/// from drop-down-like controls
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	public class Option<TKey>
	{
		/// <summary>
		/// Converter that will be used in ToString method
		/// </summary>
		public readonly IConverterToString<Option<TKey>> ConverterToString;

		/// <summary>
		/// Displayed value of an option
		/// </summary>
		public string DisplayValue { get; set; }

		/// <summary>
		/// Key of options
		/// </summary>
		public TKey Key { get; set; }

		/// <summary>
		/// Create new option using <see cref="BasicOptionConverterToString{TKey}"/>
		/// for <see cref="ToString"/>
		/// </summary>
		public Option() : this(new BasicOptionConverterToString<TKey>())
		{
		}

		/// <summary>
		/// Creates new option using passed implementation of <see cref="IConverterToString{T}"/>
		/// that will be used in <see cref="ToString"/>
		/// </summary>
		/// <param name="converterToString"></param>
		public Option(IConverterToString<Option<TKey>> converterToString) 
		{
			this.ConverterToString = converterToString;
		}

		/// <summary>
		/// return the result of <see cref="IConverterToString{T}.GetStringFrom(T)"/> for the option
		/// if custom converter was not passed in constructor <see cref="BasicOptionConverterToString{TKey}"/> is used
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this.ConverterToString.GetStringFrom(this);
		}
	}

	/// <summary>
	/// Standard version of <see cref="Option{TKey}"/>.
	/// Uses <see cref="Int32"/> as <see cref="{TKey}"/>
	/// </summary>
	public class Option : Option<int>
	{
		public Option()
		{
		}

		public Option(IConverterToString<Option<int>> converterToString) : base(converterToString)
		{
		}
	}
}
