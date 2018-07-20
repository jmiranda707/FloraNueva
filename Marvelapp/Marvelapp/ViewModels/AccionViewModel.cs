using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class AccionViewModel :BaseViewModel
    {
        #region Properties
        public string TipoAccion
        {
            get
            {
                return tipoAccion;
            }
            set
            {
                SetValue(ref tipoAccion, value);
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
        public string OrigenColonia
        {
            get
            {
                return origenColonia;
            }
            set
            {
                SetValue(ref origenColonia, value);
            }
        }
        public string ResponsableAccion
        {
            get
            {
                return responsableAccion;
            }
            set
            {
                SetValue(ref responsableAccion, value);
            }
        }
        public DateTime FechaAccion
        {
            get
            {
                return fechaAccion;
            }
            set
            {
                SetValue(ref fechaAccion, value);
            }
        }
        public string Comentario
        {
            get
            {
                return comentario;
            }
            set
            {
                SetValue(ref comentario, value);
            }
        }
        #endregion

        #region Attributes
        private string comentario;
        private DateTime fechaAccion;
        private string responsableAccion;
        private string origenColonia;
        private bool isEnabled;
        private string tipoAccion;
        #endregion

        #region ApiServices

        #endregion

        #region constructors
        public AccionViewModel()
        {
            this.IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand GuardarCommand
        {
            get
            {
                return new RelayCommand(Guardar);
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
        private async void Guardar()
        {
            /*
            #region Validaciones  
            if (string.IsNullOrEmpty(TipoAccion) ||
                string.IsNullOrEmpty(OrigenColonia) ||
                string.IsNullOrEmpty(ResponsableAccion) ||
                string.IsNullOrEmpty(Comentario))
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Por Favor Llene los Campos Obligatorios", "Aceptar");
                return;
            }
            #endregion
            */
                await Application.Current.MainPage.DisplayAlert("Guardado", "Fecha: "+FechaAccion, "Excelente");
               /* TipoAccion = string.Empty;
                OrigenColonia = string.Empty;
                ResponsableAccion = string.Empty;
                Comentario = string.Empty; */
        }
        private async void Volver()
        {

            await Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
