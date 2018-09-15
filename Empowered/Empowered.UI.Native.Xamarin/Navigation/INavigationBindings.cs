using Xamarin.Forms;

namespace Empowered.UI.Native.XForms.Navigation
{
	/// <summary>
	/// Viewmodel-page associatons required
	/// for <see cref="Navigator"/> to open correct pages.
	/// This interface is app-specific. 
	/// Typicall realization is class inheiriting from <see cref="NavigationBindings"/>
	/// </summary>
	public interface INavigationBindings
	{
		/// <summary>
		/// Returns page associated with passed viewmodel
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <returns></returns>
		Page GetPageFor<TViewModel>() where TViewModel : IViewModel;
	}
}
