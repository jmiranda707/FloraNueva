using GalaSoft.MvvmLight.Command;
using Marvelapp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class ANAccionMeliponarioViewModel : INotifyPropertyChanged
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
        private string _comentario;
        private DateTime _fechaAccion;
        private string _responsableAccion;
        private string _tipoAccion;
        int i;
        private ObservableCollection<Accion> accion;
        private Double heighList;
        private bool isRefreshing;
        private bool isEnabled;

        private string comentario;
        private DateTime fechaAccion;
        private string responsableAccion;
        private string origenColonia;
        private string tipoAccion;
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
        public ObservableCollection<Accion> Acciones
        {
            get
            {
                return accion;
            }
            set
            {
                if (accion != value)
                {
                    accion = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(Acciones)));
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

        public string TipoAccion
        {
            get { return tipoAccion; }
            set
            {
                tipoAccion = value;
                OnPropertyChanged("TipoAccion");
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
        public string OrigenColonia
        {
            get { return origenColonia; }
            set
            {
                origenColonia = value;
                OnPropertyChanged("OrigenColonia");
            }
        }
        public string ResponsableAccion
        {
            get { return responsableAccion; }
            set
            {
                responsableAccion = value;
                OnPropertyChanged("ResponsableAccion");
            }
        }
        public DateTime FechaAccion
        {
            get { return fechaAccion; }
            set
            {
                fechaAccion = value;
                OnPropertyChanged("FechaAccion");
            }
        }
        public string Comentario
        {
            get { return comentario; }
            set
            {
                comentario = value;
                OnPropertyChanged("Comentario");
            }
        }
        #endregion

        #region ApiServices

        #endregion

        #region constructors
        public ANAccionMeliponarioViewModel()
        {
            instance = this;
            IsEnabled = true;
            Acciones = new ObservableCollection<Accion>();
            LoadAcciones(); //carga el listado de miembros
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
        #endregion

        #region Methods
        async void LoadAcciones()
        {
            if (Application.Current.Properties.ContainsKey("ContadorAcciones")) //contador de la cantidad de elementos en la lista
            {
                Elementos = int.Parse((Application.Current.Properties["ContadorAcciones"]) as string);
            }
            else { Elementos = 0; }

            IsRefreshing = true;

            for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("TipoAccion" + j))
                {
                    _tipoAccion = (Application.Current.Properties["TipoAccion" + j]) as string;
                }
                else { _tipoAccion = ""; }

                if (Application.Current.Properties.ContainsKey("FechaAccion" + j))
                {
                    _fechaAccion = DateTime.Parse(Application.Current.Properties["FechaAccion" + j] as string);
                }
                else { _fechaAccion = DateTime.Now; }
                if (Application.Current.Properties.ContainsKey("Responsable" + j))
                {
                    _responsableAccion = (Application.Current.Properties["Responsable" + j] as string);
                }
                else { _responsableAccion = ""; }
                if (Application.Current.Properties.ContainsKey("Comentario" + j))
                {
                    _comentario = (Application.Current.Properties["Comentario" + j] as string);
                }
               
                Acciones.Add(new Accion() //agrega a mi lista todos los elementos existentes en persistencia
                {
                    Comentario = _comentario,
                    FechaAccion = _fechaAccion,
                    TipoAccion = _tipoAccion,
                    Responsable = _responsableAccion,
                });
            }

            IsRefreshing = false;

            HeighListView = 44 * Acciones.Count; //cantidad de filas en mi lista, multiplicado por 44 que es el alto maximo de cada fila
        }

        private async void Guardar()
        {
             IsEnabled = false;
            #region Miranda: Guardar Tabla

            #region Ciclo para Guardar en Persistencia
            if (Application.Current.Properties.ContainsKey("ContadorAcciones"))//verifico cuantos elementos tiene mi lista para saber cual es la psocion del nuevo elemento a agregar
            {
                Elementos = (int.Parse((Application.Current.Properties["ContadorAcciones"]) as string));
            }
            else { Elementos = 0; }

            Application.Current.Properties["TipoAccion" + Elementos] = TipoAccion.ToString();
            Application.Current.Properties["FechaAccion" + Elementos] = FechaAccion.ToString();
            Application.Current.Properties["Responsable" + Elementos] = ResponsableAccion.ToString();
            Application.Current.Properties["Comentario" + Elementos] = Comentario.ToString();
            Application.Current.Properties["ContadorAcciones"] = (Elementos + 1).ToString();
            await Application.Current.SavePropertiesAsync();
            #endregion


            int filas;
            filas = Elementos + 1;
            HeighListView = 44 * filas;//actalizo mi heigh
            await Application.Current.MainPage.DisplayAlert("Notificación", "Usted Tiene hasta Ahora: " + filas + " Acciones", "Excelente");
            IsEnabled = true;
            Acciones.Add(new Accion()
            {
                Comentario = Comentario.ToString(),
                FechaAccion = FechaAccion,
                TipoAccion = TipoAccion.ToString(),
                Responsable = ResponsableAccion.ToString(),
      
            });
            AnMeliponarioCajaViewModel.GetInstance().AccionesCaja = Acciones; //asigno los datos de mi lista 
            AnMeliponarioCajaViewModel.GetInstance().HeighListViewB = this.HeighListView; //actualizo el heigh de mi vista anterior

            await Application.Current.MainPage.Navigation.PopAsync();


            #endregion


             TipoAccion = string.Empty;
             OrigenColonia = string.Empty;
             ResponsableAccion = string.Empty;
             Comentario = string.Empty;
             IsEnabled = true;
        }
        private async void Volver()
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
        #endregion

        #region Singleton 
        private static ANAccionMeliponarioViewModel instance;
        public static ANAccionMeliponarioViewModel GetInstance()
        {
            if (instance == null)
            {
                return new ANAccionMeliponarioViewModel();
            }
            return instance;
        }
        #endregion

    }
}
