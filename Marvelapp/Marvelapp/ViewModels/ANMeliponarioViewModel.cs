using Marvelapp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Marvelapp.Models;

namespace Marvelapp.ViewModels
{
    public class ANMeliponarioViewModel : INotifyPropertyChanged
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
        private Double heighListAN;
        int Elementos;
        int i;
        private bool isEnabled;
        private ObservableCollection<Caja> cajaAN;
        string _IdMeliponario;
        string _Productor;
        string _Latitud;
        string _Longitud;
        bool _FloraNueva;
        string _TipoMeliponarioM;
        DateTime _DateSelected;
        string _Observaciones;
        #endregion

        #region Properties
        public Double HeighListViewAN
        {
            get
            {
                return heighListAN;
            }
            set
            {
                if (heighListAN != value)
                {
                    heighListAN = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(HeighListViewAN)));
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
        public ObservableCollection<Caja> CajasAN
        {
            get
            {
                return cajaAN;
            }
            set
            {
                if (cajaAN != value)
                {
                    cajaAN = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(CajasAN)));
                }
            }
        }
        public string Observaciones
        {
            get { return _Observaciones; }
            set
            {
                _Observaciones = value;
                OnPropertyChanged("Observaciones");
            }
        }
        public DateTime DateSelected
        {
            get { return _DateSelected; }
            set
            {
                _DateSelected = value;
                OnPropertyChanged("DateSelected");
            }
        }
        public string TipoMeliponarioM
        {
            get { return _TipoMeliponarioM; }
            set
            {
                _TipoMeliponarioM = value;
                OnPropertyChanged("TipoMeliponarioM");
            }
        }
        public bool FloraNueva
        {
            get { return _FloraNueva; }
            set
            {
                _FloraNueva = value;
                OnPropertyChanged("FloraNueva");
            }
        }
        public string Longitud
        {
            get { return _Longitud; }
            set
            {
                _Longitud = value;
                OnPropertyChanged("Longitud");
            }
        }
        public string Latitud
        {
            get { return _Latitud; }
            set
            {
                _Latitud = value;
                OnPropertyChanged("Latitud");
            }
        }
        public string Productor
        {
            get { return _Productor; }
            set
            {
                _Productor = value;
                OnPropertyChanged("Productor");
            }
        }
        public string IdMeliponario
        {
            get { return _IdMeliponario; }
            set
            {
                _IdMeliponario = value;
                OnPropertyChanged("IdMeliponario");
            }
        }
        #endregion

        #region Constructors
        public ANMeliponarioViewModel()
        {
            /*
            Application.Current.Properties["Idcaja" + 0] = 1.ToString();
            Application.Current.Properties["Tipocaja" + 0] = "".ToString();
            Application.Current.Properties["Fechaentregacaja" + 0] =DateTime.Now.ToString();
            Application.Current.Properties["Activacaja" + 0] = "".ToString();
            Application.Current.Properties["Comentariocaja" + 0] = "".ToString();
            Application.Current.Properties["Contadorcajas"] = 1.ToString();
            Application.Current.SavePropertiesAsync();
            */

            IsEnabled = true;
            instance = this;
            CajasAN = AnMeliponarioCajaViewModel.GetInstance().Cajas; //obtengo los datos de mi lista en la otra ANMeliponarioCajaViewModel
            HeighListViewAN = AnMeliponarioCajaViewModel.GetInstance().HeighListViewCaja; //obtengo el heigh de ANMeliponarioCajaViewModel
        }

        #endregion

        #region Commands
        public ICommand AgregarCosechaCommand
        {
            get
            {
                return new RelayCommand(AgregarCosecha);
            }
        }
        public ICommand AgregarCajaCommand
        {
            get
            {
                return new RelayCommand(AgregarCaja);
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
        #endregion

        #region Methods
        async void Guardar()
        {
            isEnabled = false;
            #region Validaciones
            /*
            if (string.IsNullOrEmpty(IdMeliponario) || string.IsNullOrEmpty(Productor) || string.IsNullOrEmpty(Latitud) ||
                string.IsNullOrEmpty(Longitud) || string.IsNullOrEmpty(TipoMeliponarioM) || string.IsNullOrEmpty(Observaciones))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Llene los campos obligatorios", "aceptar");
                IsEnabled = true;
                return;
            }
            */
            #endregion

            #region Limpiar Cache //borrar los datos existentes en persistencia

            if (Application.Current.Properties.ContainsKey("Contadorcajas"))//si contador es 0, entonces no hay cajas guardadas y no asigna nada a persistencia
            {
                Elementos = int.Parse((Application.Current.Properties["Contadorcajas"]) as string);
            }
            else { Elementos = 0; }
            for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("Idcaja" + j))
                {
                    Application.Current.Properties.Remove("Idcaja" + j);
                }
                if (Application.Current.Properties.ContainsKey("Tipocaja" + j))
                {
                    Application.Current.Properties.Remove("Tipocaja" + j);
                }
                if (Application.Current.Properties.ContainsKey("Fechaentregacaja"))
                {
                    Application.Current.Properties.Remove("Fechaentregacaja");
                }
                if (Application.Current.Properties.ContainsKey("Activacaja"))
                {
                    Application.Current.Properties.Remove("Activacaja");
                }
                if (Application.Current.Properties.ContainsKey("Comentariocaja"))
                {
                    Application.Current.Properties.Remove("Comentariocaja");
                }
                
            }

            #endregion

            #region Ciclo para Guardar en Persistencia mi lista Actual
            i = 0; //inicio el contador de mis elementos o filas en (0)
            foreach (var caja in CajasAN)
            {
                Application.Current.Properties["Idcaja" + i] = caja.IdCaja.ToString();
                Application.Current.Properties["Tipocaja" + i] = caja.TipoCaja.ToString();
                Application.Current.Properties["Fechaentregacaja" + i] = caja.FechaEntrega.ToString();
                Application.Current.Properties["Activacaja" + i] = caja.Activa.ToString();
                Application.Current.Properties["Comentariocaja" + i] = caja.Comentario.ToString();
                i++;
                Application.Current.Properties["Contadorcajas"] = i.ToString();
                await Application.Current.SavePropertiesAsync();
            }

            #endregion

            int filas;
            filas = CajasAN.Count;
            Application.Current.Properties["Contadorcajas"] = filas.ToString(); //hay que examinar esta linea, es de prueba porque creo que no se actualiza bien el contador en la otra viewmodel cuando se borran todos los registros y esta linea evita eso
            HeighListViewAN = 44 * filas;//actalizo mi heigh
            AnMeliponarioCajaViewModel.GetInstance().Cajas = this.CajasAN; //asigno los datos de mi lista 
            await Application.Current.MainPage.DisplayAlert("Notificación", "Usted Tiene hasta Ahora: " + filas + " Cajas Registradas", "Excelente");
            IsEnabled = true;
            
        }
        async void AgregarCosecha()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ANCosechaMeliponarioPage());
        }
        async void AgregarCaja()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ANMeliponarioCajaPage());
        }
        async void Volver()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        async void CloseTool()
        {
            await Application.Current.MainPage.Navigation.PopAsync();

        }
        async void SaveTool()
        {
            if (string.IsNullOrEmpty(IdMeliponario) || string.IsNullOrEmpty(Productor) || string.IsNullOrEmpty(Latitud) ||
                 string.IsNullOrEmpty(Longitud) || string.IsNullOrEmpty(TipoMeliponarioM) || string.IsNullOrEmpty(Observaciones))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Llene los campos obligatorios", "aceptar");
                return;
            }

            await Application.Current.MainPage.DisplayAlert(
                "Hola",
                "Guardar",
                "Aceptar");
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
        private static ANMeliponarioViewModel instance;
        public static ANMeliponarioViewModel GetInstance()
        {
            if (instance == null)
            {
                return new ANMeliponarioViewModel();
            }
            return instance;
        }
        #endregion

    }
}
