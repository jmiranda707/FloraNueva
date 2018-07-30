using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Marvelapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DatosPersonalesPage : ContentPage
	{
		public DatosPersonalesPage ()
		{
			InitializeComponent ();
            Datepicker.Date = DateTime.Now;

        }
    }
}