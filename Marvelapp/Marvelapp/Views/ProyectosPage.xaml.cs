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
    public partial class ProyectosPage : ContentPage
    {
        public ProyectosPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            MessagingCenter.Send<ProyectosPage>(this, "preset");
        }
    }
}