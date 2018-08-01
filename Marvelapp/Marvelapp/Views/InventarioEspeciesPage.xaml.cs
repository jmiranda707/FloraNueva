using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Marvelapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventarioEspeciesPage : ContentPage
    {
        public InventarioEspeciesPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            MessagingCenter.Send<InventarioEspeciesPage>(this, "preset");
        }
    }
}