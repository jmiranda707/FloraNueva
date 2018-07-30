using GalaSoft.MvvmLight.Command;
using Marvelapp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class DatosPersonalesViewModel : INotifyPropertyChanged
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

        private int Elementos;

        private string tipo;

        private string nombrecontacto;

        private string detalle;

        int i;

        private ObservableCollection<Contacto> contacto;

        private Double heighList;

        private bool isRefreshing;

        private bool isEnabled;

        string _apellidoUno;

        string _apellidoDos;

        string _nombres;

        string _codigoFloraNueva;

        bool _sexo;

        string _cedula;

        DateTime _dateSelected;

        string _edad;

        string _estadoCivil;

        string _grupoEtnico;

        #endregion

        #region Properties
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
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(IsEnabled)));
                }
            }
        }
        public ObservableCollection<Contacto> Contactos
        {
            get
            {
                return contacto;
            }
            set
            {
                if (contacto != value)
                {
                    contacto = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(Contactos)));
                }
            }
        }
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
        public string GrupoEtnico
        {
            get { return _grupoEtnico; }
            set
            {
                _grupoEtnico = value;
                OnPropertyChanged("GrupoEtnico");
            }
        }
        public string EstadoCivil
        {
            get { return _estadoCivil; }
            set
            {
                _estadoCivil = value;
                OnPropertyChanged("EstadoCivil");
            }
        }
        public string Edad
        {
            get { return _edad; }
            set
            {
                _edad = value;
                OnPropertyChanged("Edad");
            }
        }
        public DateTime DateSelected
        {
            get { return _dateSelected; }
            set
            {
                _dateSelected = value;
                OnPropertyChanged("DateSelected");
            }
        }
        public string Cedula
        {
            get { return _cedula; }
            set
            {
                _cedula = value;
                OnPropertyChanged("Cedula");
            }
        }
        public bool Sexo
        {
            get { return _sexo; }
            set
            {
                _sexo = value;
                OnPropertyChanged("Sexo");
            }
        }
        public string CodigoFloraNueva
        {
            get { return _codigoFloraNueva; }
            set
            {
                _codigoFloraNueva = value;
                OnPropertyChanged("CodigoFloraNueva");
            }
        }
        public string Nombres
        {
            get { return _nombres; }
            set
            {
                _nombres = value;
                OnPropertyChanged("Nombres");
            }
        }
        public string ApellidoDos
        {
            get { return _apellidoDos; }
            set
            {
                _apellidoDos = value;
                OnPropertyChanged("ApellidoDos");
            }
        }
        public string ApellidoUno
        {
            get { return _apellidoUno; }
            set
            {
                _apellidoUno = value;
                OnPropertyChanged("ApellidoUno");
            }
        }
        #endregion

        #region Constructors
        public DatosPersonalesViewModel()
        {
            IsEnabled = true;
            instance = this;
            Contactos = new ObservableCollection<Contacto>();
            LoadContactos(); //carga el listado de contactos
        }


        #endregion

        #region Commands
        public ICommand TapAgregarCommand
        {
            get
            {
                return new RelayCommand(TapAgregar);
            }
        }
        public ICommand BackToolCommand
        {
            get
            {
                return new RelayCommand(BackTool);
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
        public ICommand CloseToolCommand
        {
            get
            {
                return new RelayCommand(CloseTool);
            }
        }
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
        public ICommand ChangeImageCommand
        {
            get
            {
                return new RelayCommand(ChangeImage);
            }
        }


        #endregion
  
        #region Methods
        async void LoadContactos()
        {
            if (Application.Current.Properties.ContainsKey("ContadorContacto")) //contador de la cantidad de elementos en la lista
            {
                Elementos = int.Parse((Application.Current.Properties["ContadorContacto"]) as string);
            }
            else { Elementos = 0; }

            IsRefreshing = true;

            for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("TipoContacto" + j))
                {
                    tipo = (Application.Current.Properties["TipoContacto" + j]) as string;
                }
                else { tipo = ""; }

                if (Application.Current.Properties.ContainsKey("Detalle" + j))
                {
                    detalle = (Application.Current.Properties["Detalle" + j] as string);
                }
                else { detalle = ""; }

                if (Application.Current.Properties.ContainsKey("NombreContacto" + j))
                {
                    nombrecontacto = (Application.Current.Properties["NombreContacto" + j] as string);
                }
                else { nombrecontacto = ""; }


                Contactos.Add(new Contacto() //agrega a mi lista todos los elementos existentes en persistencia
                {
                    NombreContacto = nombrecontacto,
                    DetalleContacto = detalle,
                    TipoContacto = tipo,
                });
            }

            IsRefreshing = false;

            HeighListView = 44 * Contactos.Count; //cantidad de filas en mi lista, multiplicado por 44 que es el alto maximo de cada fila

        }
        async void Guardar()
        {
            IsEnabled = false;
           
            #region Eleazar
            var fecha = DateSelected.ToString("dd/MM/yyyy");

            if (string.IsNullOrEmpty(ApellidoUno) || string.IsNullOrEmpty(ApellidoDos) || string.IsNullOrEmpty(Nombres) || string.IsNullOrEmpty(Cedula) ||
                string.IsNullOrEmpty(fecha) || string.IsNullOrEmpty(Edad))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Llene los campos obligatorios", "aceptar");
                IsEnabled = true;
                return;
            }
            #endregion
            
            #region Miranda: Guardar Tabla

            #region Limpiar Cache //borrar los datos existentes en persistencia

            if (Application.Current.Properties.ContainsKey("ContadorContacto"))
            {
                Elementos = int.Parse((Application.Current.Properties["ContadorContacto"]) as string);
            }
            else { Elementos = 0; }
            for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("TipoContacto" + j))
                {
                    Application.Current.Properties.Remove("TipoContacto" + j);
                }
                if (Application.Current.Properties.ContainsKey("Detalle" + j))
                {
                    Application.Current.Properties.Remove("Detalle" + j);
                }
                if (Application.Current.Properties.ContainsKey("NombreContacto" + j))
                {
                    Application.Current.Properties.Remove("NombreContacto" + j);
                }
                if (Application.Current.Properties.ContainsKey("ContadorContacto"))
                {
                    Application.Current.Properties.Remove("ContadorContacto");
                }
            }

            #endregion

            #region Ciclo para Guardar en Persistencia
            i = 0; //inicio el contador de mis elementos o filas en (0)
            foreach (var contact in Contactos)
            {
                Application.Current.Properties["NombreContacto" + i] = contact.NombreContacto.ToString();
                Application.Current.Properties["TipoContacto" + i] = contact.TipoContacto.ToString();
                Application.Current.Properties["Detalle" + i] = contact.DetalleContacto.ToString();
                i++;
                Application.Current.Properties["ContadorContacto"] = i.ToString();
                await Application.Current.SavePropertiesAsync();
            }

            #endregion

            int filas;
            HeighListView = 44 * i;
            if (Application.Current.Properties.ContainsKey("ContadorContacto"))
            {
                filas = int.Parse(Application.Current.Properties["ContadorContacto"] as string);
            }
            else { filas = 0; }
            await Application.Current.MainPage.DisplayAlert("Notificación", "El Numero de Filas Guardadas es: " + filas.ToString(), "Excelente");
            IsEnabled = true;

            #endregion
           
            /*
            await Application.Current.MainPage.DisplayAlert(
                "Hola",
                ApellidoUno + " " + ApellidoDos + " " + Nombres + " " + CodigoFloraNueva + " " + Sexo + " " + Cedula + " " + Edad + " " + EstadoCivil + " " + GrupoEtnico,
                "Aceptar"); */
        }
        async void ChangeImage()
        {
            await Application.Current.MainPage.DisplayAlert(
                "Hola",
                "Cambiar imagen",
                "Aceptar");
        }
        async void Volver()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        private void TapAgregar()//agrega una fila vacia a la tabla contactos
        {

            IsRefreshing = true;
            Contactos.Add(new Contacto()
            {
                NombreContacto = "",
                DetalleContacto="",
                TipoContacto=""
            });

            HeighListView = HeighListView + 44;
            IsRefreshing = false;
        }
        async void CloseTool()
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
        async void BackTool()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion

        #region Singleton 
        private static DatosPersonalesViewModel instance;


        public static DatosPersonalesViewModel GetInstance()
        {
            if (instance == null)
            {
                return new DatosPersonalesViewModel();
            }
            return instance;
        }
        #endregion
    }
}
