using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.Models
{
    public class VisitaGrupalProductor
    {
        public string NameGrupo { set; get; }
        public string FechaDesde { set; get; }
        public string FechaHasta { set; get; }
        public string FotoVisita { set; get; }

        #region Exception
        #region Command
        public ICommand SelectVisitaGrupalCommand
        {
            get
            {
                return new RelayCommand(SelectVisita);
            }
        }
        #endregion

        #region Methods
        private async void SelectVisita()
        {
            ///si no instancio la viewmodel relacionada a la page, no me va a funcionar la navegacion.
            ///por eso siempre
            //debo usar el singleton
            // MainViewModel.GetInstance().Landlist = new LandViewModel(this);///antes de llamar a cualquier nueva 
            ///pagina debo usar mi singleton. para pasar a la nueva pagina mi pais actual seleccionado, le coloco al constructor THIS
            /// y el pasa mi clase actual.
            //await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());
            await Application.Current.MainPage.DisplayAlert("Mensaje", "Usted a Seleccionado el Grupo: " + this.NameGrupo, "Excelente");
        }
        #endregion 
        #endregion
    }
}
