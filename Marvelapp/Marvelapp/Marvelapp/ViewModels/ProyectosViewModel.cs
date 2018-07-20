using GalaSoft.MvvmLight.Command;
using Marvelapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class ProyectosViewModel: BaseViewModel
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
        public string CodigoFlora
        {
            get
            {
                return codigoFlora;
            }
            set
            {
                SetValue(ref codigoFlora, value);
            }
        }
        public ObservableCollection<Proyecto> Proyects
        {
            get { return proyecto; }
            set { SetValue(ref proyecto, value); }
        }
        public bool IsRefreshing //para refrescar el listview
        {
            get { return isRefreshing; }
            set { SetValue(ref isRefreshing, value); }
        }
        /*
        public string NombreProyecto
        {
            get
            {
                return nombreProyecto;
            }
            set
            {
                SetValue(ref nombreProyecto, value);
            }
        }
        public string EstatusIntegracion
        {
            get
            {
                return estatusIntegracion;
            }
            set
            {
                SetValue(ref estatusIntegracion, value);
            }
        }
        public DateTime FechaIntegracion
        {
            get
            {
                return fechaIntegracion;
            }
            set
            {
                SetValue(ref fechaIntegracion, value);
            }
        }
        public DateTime FechaSalida
        {
            get
            {
                return fechaSalida;
            }
            set
            {
                SetValue(ref fechaSalida, value);
            }
        }
        public string RazonSalida
        {
            get
            {
                return razonSalida;
            }
            set
            {
                SetValue(ref razonSalida, value);
            }
        }*/
        #endregion

        #region Attributes
        private ObservableCollection<Proyecto> proyecto;
        private bool isRefreshing;
        private bool isEnabled;
        private string codigoFlora;
        /*private DateTime fechaIntegracion;
        private string estatusIntegracion;
        private string nombreProyecto;
        private DateTime fechaSalida;
        private string razonSalida;*/
        #endregion

        #region ApiServices

        #endregion

        #region constructors
        public ProyectosViewModel()
        {
            this.IsEnabled = true;
            Proyects = new ObservableCollection<Proyecto>();
            LoadProyectos(); //cargo el listado de proyectos
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
        public ICommand AgregarProyectoCommand
        {
            get
            {
                return new RelayCommand(AgregarProyecto);
            }
        }
        #endregion

        #region Methods
        private void LoadProyectos()
        {
            Proyects.Add(new Proyecto()
            {
                NombreProyecto="",
                EstatusIntegracion="",
                RazonSalida="",
            });
            IsRefreshing = false;
        }
        private async void Guardar()
        {
            
            #region Validaciones  
            if (string.IsNullOrEmpty(CodigoFlora) ||
                (CodigoFlora=="0"))    
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Por Favor Llene los Campos Obligatorios", "Aceptar");
                return;
            }
            #endregion
            else
            {
                await Application.Current.MainPage.DisplayAlert("Guardado", "Codigo de Flora Nueva: " + CodigoFlora.ToString(), "Excelente");

            }
        }
        private async void Volver()
        {

            await Application.Current.MainPage.Navigation.PopAsync();
        }
        private async void AgregarProyecto()
        {
            int contador = 0;
            IsRefreshing = true;
            proyecto.Add(new Proyecto()
            {
                NombreProyecto =(contador+1).ToString(), //solo para probar, este contador no va
                EstatusIntegracion = "",
                RazonSalida = "",
            });
            IsRefreshing = false;
            //await Application.Current.MainPage.DisplayAlert("Guardado", "Acabas de Agregar otra Fila", "Excelente");
        }

        #endregion
    }
}
