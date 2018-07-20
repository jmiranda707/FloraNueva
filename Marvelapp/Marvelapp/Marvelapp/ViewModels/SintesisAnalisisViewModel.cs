using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class SintesisAnalisisViewModel: BaseViewModel
    {
        #region Properties
        public string Fortalezas
        {
            get
            {
                return fortalezas;
            }
            set
            {
                SetValue(ref fortalezas, value);
            }
        }
        public string Oportunidades
        {
            get
            {
                return oportunidades;
            }
            set
            {
                SetValue(ref oportunidades, value);
            }
        }
        public string Debilidades
        {
            get
            {
                return debilidades;
            }
            set
            {
                SetValue(ref debilidades, value);
            }
        }
        public string Amenazas
        {
            get
            {
                return amenazas;
            }
            set
            {
                SetValue(ref amenazas, value);
            }
        }
        
        public string ComentarioGeneral
        {
            get
            {
                return comentarioGeneral;
            }
            set
            {
                SetValue(ref comentarioGeneral, value);
            }
        }
        public string ProyectosPotenciales
        {
            get
            {
                return proyectosPotenciales;
            }
            set
            {
                SetValue(ref proyectosPotenciales, value);
            }
        }
        #endregion

        #region Attributes
        private string fortalezas;
        private string debilidades;
        private string oportunidades;
        private string amenazas;
        private string proyectosPotenciales;
        private string comentarioGeneral;

        #endregion

        #region ApiServices

        #endregion

        #region constructors

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
            if (string.IsNullOrEmpty(Fortalezas) ||
                string.IsNullOrEmpty(Debilidades) ||
                string.IsNullOrEmpty(Oportunidades) ||
                string.IsNullOrEmpty(Amenazas) ||
                string.IsNullOrEmpty(ProyectosPotenciales))
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Por Favor Llene los Campos Obligatorios", "Aceptar");
                return;
            }
            #endregion
            else
            {
                await Application.Current.MainPage.DisplayAlert("Guardado", "Amenazas: " + Amenazas, "Excelente");
                Fortalezas = string.Empty;
                Debilidades = string.Empty;
                Oportunidades = string.Empty;
                Amenazas = string.Empty;
                ProyectosPotenciales = string.Empty;
            }
        }
        private async void Volver()
        {

            await Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
