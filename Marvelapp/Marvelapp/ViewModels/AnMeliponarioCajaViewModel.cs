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
    public class AnMeliponarioCajaViewModel : INotifyPropertyChanged
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
        private Double heighListB;
        int Elementos;
        int i;
        private bool isEnabled;
        private ObservableCollection<Accion> accioncaja;
        string _IdCaja;
        string _Tipo;
        string _Productor;
        DateTime _FechaEntrega;
        string _Comentario;
        string _Origen;
        bool _FloraNueva;
        #endregion

        #region Properties
        public Double HeighListViewB
        {
            get
            {
                return heighListB;
            }
            set
            {
                if (heighListB != value)
                {
                    heighListB = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(HeighListViewB)));
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
        public ObservableCollection<Accion> AccionesCaja
        {
            get
            {
                return accioncaja;
            }
            set
            {
                if (accioncaja != value)
                {
                    accioncaja = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(AccionesCaja)));
                }
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
        public string Origen
        {
            get { return _Origen; }
            set
            {
                _Origen = value;
                OnPropertyChanged("Origen");
            }
        }
        public string Comentario
        {
            get { return _Comentario; }
            set
            {
                _Comentario = value;
                OnPropertyChanged("Comentario");
            }
        }
        public DateTime FechaEntrega
        {
            get { return _FechaEntrega; }
            set
            {
                _FechaEntrega = value;
                OnPropertyChanged("FechaEntrega");
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
        public string Tipo
        {
            get { return _Tipo; }
            set
            {
                _Tipo = value;
                OnPropertyChanged("Tipo");
            }
        }
        public string IdCaja
        {
            get { return _IdCaja; }
            set
            {
                _IdCaja = value;
                OnPropertyChanged("IdCaja");
            }
        }
        #endregion

        #region Constructors
        public AnMeliponarioCajaViewModel()
        {
            IsEnabled = true;
            instance = this;
            AccionesCaja = ANAccionMeliponarioViewModel.GetInstance().Acciones; //obtengo los datos de mi lista en la otra ComposicionHogarViewModel
            HeighListViewB = ANAccionMeliponarioViewModel.GetInstance().HeighListView; //obtengo el heigh de ComposicionHogarViewModel

        }
        #endregion

        #region Commands
        public ICommand AgregarAccionCommand
        {
            get
            {
                return new RelayCommand(AgregarAccion);
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
            var fecha = FechaEntrega.ToString("dd/MM/yyyy");

            #region Limpiar Cache //borrar los datos existentes en persistencia

            if (Application.Current.Properties.ContainsKey("ContadorAcciones"))
            {
                Elementos = int.Parse((Application.Current.Properties["ContadorAcciones"]) as string);
            }
            else { Elementos = 0; }
            for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("TipoAccion" + j))
                {
                    Application.Current.Properties.Remove("TipoAccion" + j);
                }
                if (Application.Current.Properties.ContainsKey("FechaAccion" + j))
                {
                    Application.Current.Properties.Remove("FechaAccion" + j);
                }
                if (Application.Current.Properties.ContainsKey("Responsable"))
                {
                    Application.Current.Properties.Remove("Responsable");
                }
                if (Application.Current.Properties.ContainsKey("Comentario"))
                {
                    Application.Current.Properties.Remove("Comentario");
                }
                
            }

            #endregion

            #region Ciclo para Guardar en Persistencia mi lista Actual
            i = 0; //inicio el contador de mis elementos o filas en (0)
            foreach (var action in AccionesCaja)
            {
                Application.Current.Properties["TipoAccion" + i] = action.TipoAccion.ToString();
                Application.Current.Properties["FechaAccion" + i] = action.FechaAccion.ToString();
                Application.Current.Properties["Responsable" + i] = action.Responsable.ToString();
                Application.Current.Properties["Comentario" + i] = action.Comentario.ToString();
                i++;
                Application.Current.Properties["ContadorAcciones"] = i.ToString();
                await Application.Current.SavePropertiesAsync();
            }

            #endregion

            int filas;
            filas = AccionesCaja.Count;
            Application.Current.Properties["ContadorAcciones"] = filas.ToString(); //hay que examinar esta linea, es de prueba porque creo que no se actualiza bien el contador en la otra viewmodel cuando se borran todos los registros y esta linea evita eso
            HeighListViewB = 44 * filas;//actalizo mi heigh
            ANAccionMeliponarioViewModel.GetInstance().Acciones = this.AccionesCaja; //asigno los datos de mi lista 
            await Application.Current.MainPage.DisplayAlert("Notificación", "Usted Tiene hasta Ahora: " + filas + " Acciones en Persistencia", "Excelente");

            await Application.Current.MainPage.DisplayAlert(
                "Hola",
                IdCaja + " " + Tipo + " " + Productor + " " + fecha + " " + Comentario + " " + Origen + " " + FloraNueva,
                "Aceptar");

            IsEnabled = true;

        }
        async void Volver()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
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
        async void AgregarAccion()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ANAccionMeliponarioPage());
        }

        #endregion

        #region Singleton 
        private static AnMeliponarioCajaViewModel instance;
        public static AnMeliponarioCajaViewModel GetInstance()
        {
            if (instance == null)
            {
                return new AnMeliponarioCajaViewModel();
            }
            return instance;
        }
        #endregion
    }
}
