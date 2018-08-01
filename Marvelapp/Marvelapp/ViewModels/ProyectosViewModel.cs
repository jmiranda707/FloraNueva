using Marvelapp.Models;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System;

namespace Marvelapp.ViewModels
{
    public class ProyectosViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Attributes
        int i;
        int Elementos;
        string nombreproyecto;
        string estatusintegracion;
        string fechaintegracion;
        string fechasalida;
        string razonsalida;
        private ObservableCollection<Proyecto> proyecto;
        private Double heighList;
        private bool isRefreshing;
        private bool isEnabled;
        private string codigoFlora;
        string _productores;
        /*private DateTime fechaIntegracion;
        private string estatusIntegracion;
        private string nombreProyecto;
        private DateTime fechaSalida;
        private string razonSalida;*/
        #endregion

        #region Properties
        public bool IsRefreshing //para refrescar el listview
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                if (isRefreshing != value)
                {
                    isRefreshing = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(IsRefreshing)));
                }
            }
        }
        public Double HeighListView
        {
            get
            {
                return heighList;
            }
            set
            {
                if (heighList != value)
                {
                    heighList = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(HeighListView)));
                }
            }
        }
        public string Productores
        {
            get { return _productores; }
            set
            {
                _productores = value;
                OnPropertyChanged("Productores");
            }
        }
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }
        public string CodigoFlora
        {
            get { return codigoFlora; }
            set
            {
                codigoFlora = value;
                OnPropertyChanged("CodigoFlora");
            }
        }
        public ObservableCollection<Proyecto> Proyects
        {
            get { return proyecto; }
            set
            {
                proyecto = value;
                OnPropertyChanged("Proyects");
            }
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

        #region ApiServices

        #endregion

        #region constructors
        public ProyectosViewModel()
        {
            this.IsEnabled = true;
            instance = this;
            string productores; //esto es provisional, debe eliminarse la condicion
            if (Application.Current.Properties.ContainsKey("Productores"))
            {
                productores = Application.Current.Properties["Productores"] as string;
            }
            else { productores = "Alejandro Navarro"; }

            this.Productores = productores;
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
        public ICommand EditToolCommand
        {
            get
            {
                return new RelayCommand(EditTool);
            }
        }
        public ICommand SaveToolCommand
        {
            get
            {
                return new RelayCommand(SaveTool);
            }
        }
        #endregion

        #region Methods
        async void LoadProyectos()
        {
            if (Application.Current.Properties.ContainsKey("ContadorProyectos")) //contador de la cantidad de elementos en la lista
            {
                Elementos = int.Parse((Application.Current.Properties["ContadorProyectos"]) as string);
            }
            else { Elementos = 0; }

            IsRefreshing = true;

            for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("NombreProyecto" + j))
                {
                    nombreproyecto = (Application.Current.Properties["NombreProyecto" + j]) as string;
                }
                else { nombreproyecto = ""; }
                if (Application.Current.Properties.ContainsKey("FechaIntegracion" + j))
                {
                    fechaintegracion = (Application.Current.Properties["FechaIntegracion" + j] as string);
                }
                else { fechaintegracion = ""; }
                if (Application.Current.Properties.ContainsKey("FechaSalida" + j))
                {
                    fechasalida = (Application.Current.Properties["FechaSalida" + j] as string);
                }
                else { fechasalida = ""; }
                if (Application.Current.Properties.ContainsKey("RazonSalida" + j))
                {
                    razonsalida = (Application.Current.Properties["RazonSalida" + j] as string);
                }
                else { razonsalida = ""; }
                if (Application.Current.Properties.ContainsKey("EstatusIntegracion" + j))
                {
                    estatusintegracion = (Application.Current.Properties["EstatusIntegracion" + j] as string);
                }
                else { estatusintegracion = ""; }

                Proyects.Add(new Proyecto() //agrega a mi lista todos los elementos existentes en persistencia
                {
                   EstatusIntegracion= estatusintegracion,
                   FechaIntegracion= fechaintegracion,
                   FechaSalida= fechasalida,
                   NombreProyecto= nombreproyecto,
                   RazonSalida= razonsalida,
                });
            }

            IsRefreshing = false;

            HeighListView = 47 * Proyects.Count; //cantidad de filas en mi lista, multiplicado por 44 que es el alto maximo de cada fila
        }
        private async void Guardar()
        {
            IsEnabled = false;
            #region Descomentar todo esto
            /*
             #region Validaciones  
            if (string.IsNullOrEmpty(CodigoFlora) ||
                (CodigoFlora == "0"))
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Por Favor Llene los Campos Obligatorios", "Aceptar");
                        IsEnabled = true;
                        return;
            }
            #endregion
            else
            {
                await Application.Current.MainPage.DisplayAlert("Guardado", "Codigo de Flora Nueva: " + CodigoFlora.ToString(), "Excelente");
                IsEnabled = true;

            }
             */
            #endregion

            #region Miranda: Guardar Tabla

            #region Limpiar Cache //borrar los datos existentes en persistencia

            if (Application.Current.Properties.ContainsKey("ContadorProyectos"))
            {
                Elementos = int.Parse((Application.Current.Properties["ContadorProyectos"]) as string);
            }
            else { Elementos = 0; }
            for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("NombreProyecto" + j))
                {
                    Application.Current.Properties.Remove("NombreProyecto" + j);
                }
                if (Application.Current.Properties.ContainsKey("FechaIntegracion" + j))
                {
                    Application.Current.Properties.Remove("FechaIntegracion" + j);
                }
                if (Application.Current.Properties.ContainsKey("FechaSalida"))
                {
                    Application.Current.Properties.Remove("FechaSalida");  
                }
                if (Application.Current.Properties.ContainsKey("RazonSalida" + j))
                {
                    Application.Current.Properties.Remove("RazonSalida" + j);
                }
                if (Application.Current.Properties.ContainsKey("EstatusIntegracion" + j))
                {
                    Application.Current.Properties.Remove("EstatusIntegracion" + j);
                }
            }

            #endregion

            #region Ciclo para Guardar en Persistencia
            i = 0; //inicio el contador de mis elementos o filas en (0)
            foreach (var proyecto in Proyects)
            {
                Application.Current.Properties["NombreProyecto" + i] = proyecto.NombreProyecto.ToString();
                Application.Current.Properties["FechaSalida" + i] = proyecto.FechaSalida.ToString();
                Application.Current.Properties["RazonSalida" + i] = proyecto.RazonSalida.ToString();
                Application.Current.Properties["EstatusIntegracion" + i] = proyecto.EstatusIntegracion.ToString();
                Application.Current.Properties["FechaIntegracion" + i] = proyecto.FechaIntegracion.ToString();

                i++;
                Application.Current.Properties["ContadorProyectos"] = i.ToString();
                await Application.Current.SavePropertiesAsync();
            }

            #endregion

            int filas;
            HeighListView = 47 * i;
            if (Application.Current.Properties.ContainsKey("ContadorProyectos"))
            {
                filas = int.Parse(Application.Current.Properties["ContadorProyectos"] as string);
            }
            else { filas = 0; }
            await Application.Current.MainPage.DisplayAlert("Notificación", "El Numero de Filas Guardadas es: " + filas.ToString(), "Excelente");
            IsEnabled = true;

            #endregion
        }
        async void AgregarProyecto()
        {
            IsRefreshing = true;
            Proyects.Add(new Proyecto()
            {
                EstatusIntegracion = "",
                FechaIntegracion = DateTime.Now.ToString(),
                FechaSalida= DateTime.Now.ToString(),
                NombreProyecto= "",
                RazonSalida="",
            });

            HeighListView = HeighListView + 47;
            IsRefreshing = false;
        }
        async void Volver()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        void SaveTool()
        {
            Guardar();
        }
        async void EditTool()
        {
            await Application.Current.MainPage.DisplayAlert(
                "Hola",
                "EditTool",
                "Aceptar");
        }
        #endregion

        #region Singleton 
        private static ProyectosViewModel instance;
        public static ProyectosViewModel GetInstance()
        {
            if (instance == null)
            {
                return new ProyectosViewModel();
            }
            return instance;
        }
        #endregion
    }
}
