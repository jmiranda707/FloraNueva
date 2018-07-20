using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class BuscarVisitasGrupalesViewModel :BaseViewModel
    {

        #region Properties
        public string NombreProductor
        {
            get
            {
                return nombreProductor;
            }
            set
            {
                SetValue(ref nombreProductor, value);
            }
        }
        public string NombreGrupo
        {
            get
            {
                return nombreGrupo;
            }
            set
            {
                SetValue(ref nombreGrupo, value);
            }
        }
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                SetValue(ref isEnabled, value);
            }
        }
        public DateTime FechaDesde
        {
            get
            {
                return fechaDesde;
            }
            set
            {
                SetValue(ref fechaDesde, value);
            }
        }
        public DateTime FechaHasta
        {
            get
            {
                return fechaHasta;
            }
            set
            {
                SetValue(ref fechaHasta, value);
            }
        }
        #endregion

        #region Attributes
        private string nombreProductor;
        private string nombreGrupo;
        private bool isEnabled;
        private DateTime fechaDesde;
        private DateTime fechaHasta;

        #endregion

        #region ApiServices

        #endregion

        #region constructors
        public BuscarVisitasGrupalesViewModel()
        {
            this.IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand BuscarCommand
        {
            get
            {
                return new RelayCommand(Buscar);
            }
        }
        public ICommand VolverCommand
        {
            get
            {
                return new RelayCommand(Volver);
            }
        }
        #endregion

        #region Methods
        private async void Buscar()
        {
           /* 
            #region Validaciones  
            if (string.IsNullOrEmpty(NombreProductor) ||
                string.IsNullOrEmpty(NombreGrupo))
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Por Favor Llene los Campos Obligatorios", "Aceptar");
                return;
            }
            #endregion
            */
            await Application.Current.MainPage.DisplayAlert("Buscar", "Nombre del Productor: "+ NombreProductor, "Excelente");
           /* NombreGrupo = string.Empty;
            NombreProductor = string.Empty; */
        }
        private async void Volver()
        {

            await Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
