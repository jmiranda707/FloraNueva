using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.Models
{
    public class Meliponario
    {
        public string NameProductor { set; get; }
        public int IdMeliponario { set; get; }
        public string FechaCreacion { set; get; }
        public string FotoProductor { set; get; }

        #region Exception
        #region Command
        public ICommand SelectMeliponarioCommand
        {
            get
            {
                return new RelayCommand(SelectMeliponario);
            }
        }
        #endregion

        #region Methods
        private async void SelectMeliponario()
        {
            ///si no instancio la viewmodel relacionada a la page, no me va a funcionar la navegacion.
            ///por eso siempre
            //debo usar el singleton
            // MainViewModel.GetInstance().Landlist = new LandViewModel(this);///antes de llamar a cualquier nueva 
            ///pagina debo usar mi singleton. para pasar a la nueva pagina mi pais actual seleccionado, le coloco al constructor THIS
            /// y el pasa mi clase actual.
            //await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());
            await Application.Current.MainPage.DisplayAlert("Mensaje", "Usted a Seleccionado el Productor: " + this.NameProductor, "Excelente");
        }
        #endregion 
        #endregion
    }
}
