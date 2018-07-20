﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Marvelapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BuscarMeliponario : ContentPage
	{
		public BuscarMeliponario ()
		{
			InitializeComponent ();
            FechaDesde.Date = DateTime.Now;
            FechaHasta.Date = DateTime.Now;
		}
	}
}