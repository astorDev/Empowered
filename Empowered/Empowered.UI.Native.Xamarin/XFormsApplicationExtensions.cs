using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Empowered.UI.Native.XForms
{
	public static class XFormsApplicationExtensions
	{
		public static IServiceProvider GetServiceProvider(this Application xamarinApp)
		{
			return (IServiceProvider)xamarinApp.Resources["ServiceProvider"];
		}
	}
}
