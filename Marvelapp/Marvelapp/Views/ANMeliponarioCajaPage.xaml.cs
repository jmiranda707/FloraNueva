using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Marvelapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ANMeliponarioCajaPage : ContentPage
    {
        public ANMeliponarioCajaPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Datepicker.Date = DateTime.Now;
        }
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            MessagingCenter.Send<ANMeliponarioCajaPage>(this, "preset");
        }
    }
}