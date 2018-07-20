using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class InventarioEspeciesViewModel: BaseViewModel
    {
        
        #region Properties
        public string Especie
        {
            get
            {
                return especie;
            }
            set
            {
                SetValue(ref especie, value);
            }
        }
        public int CantidadEnTronco
        {
            get
            {
                return cantidadEnTronco;
            }
            set
            {
                SetValue(ref cantidadEnTronco, value);
            }
        }
        public int CantidadNidoArtificial
        {
            get
            {
                return cantidadNidoArtificial;
            }
            set
            {
                SetValue(ref cantidadNidoArtificial, value);
            }
        }
        public int CantidadCajaRustica
        {
            get
            {
                return cantidadCajaRustica;
            }
            set
            {
                SetValue(ref cantidadCajaRustica, value);
            }
        }
        public int CantidadCajaTecnificada
        {
            get
            {
                return cantidadCajaTecnificada;
            }
            set
            {
                SetValue(ref cantidadCajaTecnificada, value);
            }
        }
        #endregion

        #region Attributes
        private int cantidadCajaTecnificada;
        private int cantidadCajaRustica;
        private int cantidadNidoArtificial;
        private int cantidadEnTronco;
        private string especie;
        #endregion

        #region ApiServices

        #endregion

        #region constructors
        public InventarioEspeciesViewModel()
        {

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
            
            #region Validaciones  
            if ((CantidadEnTronco == 0) || string.IsNullOrEmpty(CantidadEnTronco.ToString()) ||
                (CantidadNidoArtificial == 0) || string.IsNullOrEmpty(CantidadNidoArtificial.ToString()) ||
                (CantidadCajaRustica == 0) || string.IsNullOrEmpty(CantidadCajaRustica.ToString()) ||
                (CantidadCajaTecnificada == 0) || string.IsNullOrEmpty(CantidadCajaTecnificada.ToString()) ||
                string.IsNullOrEmpty(Especie))
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Por Favor Llene los Campos Obligatorios", "Aceptar");
                return;
            }
            #endregion
            else
            {
                await Application.Current.MainPage.DisplayAlert("Guardado", CantidadCajaTecnificada.ToString(), "Excelente");
                Especie = string.Empty;
                CantidadEnTronco = 0;
                CantidadCajaRustica = 0;
                CantidadCajaTecnificada = 0;
                CantidadNidoArtificial = 0;
            }
        }
        private async void Volver()
        {

            await Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
