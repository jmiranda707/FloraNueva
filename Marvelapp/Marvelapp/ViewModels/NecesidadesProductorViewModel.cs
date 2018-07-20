using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class NecesidadesProductorViewModel: BaseViewModel
    {

        #region Properties
        public string MejorariaCalidadVida
        {
            get
            {
                return mejorariaCalidadVida;
            }
            set
            {
                SetValue(ref mejorariaCalidadVida, value);
            }
        }
        public string FrenosCalidadVida
        {
            get
            {
                return frenosCalidadVida;
            }
            set
            {
                SetValue(ref frenosCalidadVida, value);
            }
        }
        public string MejorariaActividadAgricola
        {
            get
            {
                return mejorariaActividadAgricola;
            }
            set
            {
                SetValue(ref mejorariaActividadAgricola, value);
            }
        }
        public string FrenosActividadAgricola
        {
            get
            {
                return frenosActividadAgricola;
            }
            set
            {
                SetValue(ref frenosActividadAgricola, value);
            }
        }
        public string GustariaACFNapoye
        {
            get
            {
                return gustariaACFNapoye;
            }
            set
            {
                SetValue(ref gustariaACFNapoye, value);
            }
        }
        public string FortalezaComunidad
        {
            get
            {
                return fortalezaComunidad;
            }
            set
            {
                SetValue(ref fortalezaComunidad, value);
            }
        }
        public string ProblemasComunidad
        {
            get
            {
                return problemasComunidad;
            }
            set
            {
                SetValue(ref problemasComunidad, value);
            }
        }
        public string SolucionesComunidad
        {
            get
            {
                return solucionesComunidad;
            }
            set
            {
                SetValue(ref solucionesComunidad, value);
            }
        }
        public string FrenosSoluciones
        {
            get
            {
                return frenosSoluciones;
            }
            set
            {
                SetValue(ref frenosSoluciones, value);
            }
        }
        #endregion

        #region Attributes
        private string mejorariaCalidadVida;
        private string frenosCalidadVida;
        private string mejorariaActividadAgricola;
        private string frenosActividadAgricola;
        private string gustariaACFNapoye;
        private string fortalezaComunidad;
        private string problemasComunidad;
        private string solucionesComunidad;
        private string frenosSoluciones;

        #endregion

        #region ApiServices

        #endregion

        #region constructors
        public NecesidadesProductorViewModel()
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
            if (string.IsNullOrEmpty(MejorariaCalidadVida) ||
                string.IsNullOrEmpty(FrenosCalidadVida) ||
                string.IsNullOrEmpty(MejorariaActividadAgricola) ||
                string.IsNullOrEmpty(FrenosActividadAgricola) ||
                string.IsNullOrEmpty(GustariaACFNapoye) ||
                string.IsNullOrEmpty(FortalezaComunidad) ||
                string.IsNullOrEmpty(ProblemasComunidad) ||
                string.IsNullOrEmpty(SolucionesComunidad) ||
                string.IsNullOrEmpty(FrenosSoluciones))
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Por Favor Llene los Campos Obligatorios", "Aceptar");
                return;
            }
            #endregion
            else
            {
                await Application.Current.MainPage.DisplayAlert("Guardado", "FRENOS CALIDAD DE VIDA : " + FrenosCalidadVida, "Excelente");
                MejorariaCalidadVida = string.Empty;
                FrenosCalidadVida = string.Empty;
                MejorariaActividadAgricola = string.Empty;
                FrenosActividadAgricola = string.Empty;
                GustariaACFNapoye = string.Empty;
                FortalezaComunidad = string.Empty;
                ProblemasComunidad = string.Empty;
                SolucionesComunidad = string.Empty;
                FrenosSoluciones = string.Empty;
            }
        }
        private async void Volver()
        {

            await Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
