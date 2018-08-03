using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Marvelapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ANMeliponarioPage : ContentPage
    {
        private double width = 0;
        private double height = 0;

        public ANMeliponarioPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Dateselected.Date = DateTime.Now;
            Dateselected.MaximumDate = DateTime.Now;
        }
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            MessagingCenter.Send<ANMeliponarioPage>(this, "preset");
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    //outerStack.Orientation = StackOrientation.Horizontal;
                    //BarraNavegacion.HeightRequest = 50;
                    Hamb.IsVisible = false;
                }
                else
                {
                    //outerStack.Orientation = StackOrientation.Vertical;
                    //BarraNavegacion.HeightRequest = 70;
                    Hamb.IsVisible = true;
                }
            }
        }
    }
}