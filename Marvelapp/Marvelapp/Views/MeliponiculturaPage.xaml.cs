using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Marvelapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeliponiculturaPage : ContentPage
    {
        public MeliponiculturaPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            MessagingCenter.Send<MeliponiculturaPage>(this, "preset");
        }
    }
}