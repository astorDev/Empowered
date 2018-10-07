using System;
using System.Collections.Generic;
using System.Text;

namespace Empowered.ApplicationConfiguration
{
	/// <summary>
	/// Contains objects which should be passed when
	/// passing application building to next builder.
	/// </summary>
	/// <typeparam name="TProvider"></typeparam>
	public class ApplicationBuildingTurn<TProvider>
		where TProvider : IServiceProvider
	{
		internal readonly ChainedServiceProvider ChainedProvider;

		internal TProvider TurnProvider { get; set; }

		internal ApplicationBuildingTurn(ChainedServiceProvider chainedProvider, TProvider turnProvider)
		{
			this.ChainedProvider = chainedProvider;
			this.TurnProvider = turnProvider;
		}
	}
}
