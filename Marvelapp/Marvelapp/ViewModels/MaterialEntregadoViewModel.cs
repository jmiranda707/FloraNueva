using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class MaterialEntregadoViewModel:BaseViewModel
    {

        #region Properties
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
        public DateTime FechaEntrega
        {
            get
            {
                return fechaEntrega;
            }
            set
            {
                SetValue(ref fechaEntrega, value);
            }
        }
        public int NumBoleta
        {
            get
            {
                return numBoleta;
            }
            set
            {
                SetValue(ref numBoleta, value);
            }
        }
        public string MaterialEntregado
        {
            get
            {
                return materialEntregado;
            }
            set
            {
                SetValue(ref materialEntregado, value);
            }
        }
        public int Cantidad
        {
            get
            {
                return cantidad;
            }
            set
            {
                SetValue(ref cantidad, value);
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
        private int cantidad;
        private string comentario;
        private string materialEntregado;
        private int numBoleta;
        private bool isEnabled;
        private DateTime fechaEntrega;
        #endregion

        #region ApiServices

        #endregion

        #region constructors
        public MaterialEntregadoViewModel()
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
        public ICommand TapAgregarCommand
        {
            get
            {
                return new RelayCommand(TapAgregar);
            }
        }
        public ICommand TapEliminarCommand
        {
            get
            {
                return new RelayCommand(TapEliminar);
            }
        }
        #endregion

        #region Methods
        private async void Guardar()
        {
            /*
            #region Validaciones  
            if (string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty())
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Por Favor Llene los Campos Obligatorios", "Aceptar");
                return;
            }
            #endregion
            */
            await Application.Current.MainPage.DisplayAlert("Guardar", "El dia "+FechaEntrega+ " Entregaste: "+ materialEntregado+ ".", "Excelente");
        }
        private async void Volver()
        {

            await Application.Current.MainPage.Navigation.PopAsync();
        }
        private async void TapAgregar()
        {

            await Application.Current.MainPage.DisplayAlert("Agregar", "Has Agregado una Nueva Fila", "Excelente");
        }
        private async void TapEliminar()
        {

            await Application.Current.MainPage.DisplayAlert("Borrar", "Has Eliminado una Nueva Fila", "Excelente");
        }
        #endregion
    }
}
