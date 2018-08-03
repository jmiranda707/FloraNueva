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

        #region atributos de caja
        private bool valor;
        private int ElementosCaja;
        private string tipocaja;
        private int idcaja;
        private DateTime fechaentregacaja;
        private string activacaja;
        private string comentariocaja;
        int j;
        private ObservableCollection<Caja> caja;
        private Double heighListCaja;

        #endregion
        private bool isRefreshing;
        private Double heighListB;
        int Elementos;
        int i;
        private bool isEnabled;
        private ObservableCollection<Accion> accioncaja;
        int _IdCaja;
        string _Tipo;
        string _Productor;
        DateTime _FechaEntrega;
        string _Comentario;
        string _Origen;
        bool _FloraNueva;
        #endregion

        #region Properties
       
        #region propiedades de caja
        public Double HeighListViewCaja
        {
            get
            {
                return heighListCaja;
            }
            set
            {
                if (heighListCaja != value)
                {
                    heighListCaja = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(HeighListViewCaja)));
                }
            }
        }
        public ObservableCollection<Caja> Cajas
        {
            get
            {
                return caja;
            }
            set
            {
                if (caja != value)
                {
                    caja = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(Cajas)));
                }
            }
        }
        #endregion
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
        public int IdCaja
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
            /*
            Application.Current.Properties["Idcaja" + 0] = 1.ToString();
            Application.Current.Properties["Tipocaja" + 0] = "".ToString();
            Application.Current.Properties["Fechaentregacaja" + 0] = DateTime.Now.ToString();
            Application.Current.Properties["Activacaja" + 0] = "".ToString();
            Application.Current.Properties["Comentariocaja" + 0] = "".ToString();
            Application.Current.Properties["Contadorcajas"] = 1.ToString();
            Application.Current.SavePropertiesAsync();*/

            Cajas = new ObservableCollection<Caja>();
            LoadCajas(); //carga el listado de cajas
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
        
        async void LoadCajas()
        {
            if (Application.Current.Properties.ContainsKey("Contadorcajas")) //contador de la cantidad de elementos en la lista
            {
                ElementosCaja = int.Parse((Application.Current.Properties["Contadorcajas"]) as string);
            }
            else { ElementosCaja = 0; }

            IsRefreshing = true;

            for (int j = 0; j < ElementosCaja; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("Idcaja" + j))
                {
                    idcaja = int.Parse((Application.Current.Properties["Idcaja" + j]) as string);
                }
                else { idcaja = 0; }

                if (Application.Current.Properties.ContainsKey("Tipocaja" + j))
                {
                    tipocaja = (Application.Current.Properties["Tipocaja" + j] as string);
                }
                else { tipocaja = ""; }
                if (Application.Current.Properties.ContainsKey("Fechaentregacaja" + j))
                {
                    fechaentregacaja = DateTime.Parse(Application.Current.Properties["Fechaentregacaja" + j] as string);
                }
                else { fechaentregacaja = DateTime.Now; }
                if (Application.Current.Properties.ContainsKey("Activacaja" + j))
                {
                    activacaja = (Application.Current.Properties["Activacaja" + j] as string);
                }
                else { activacaja = ""; }
                if (Application.Current.Properties.ContainsKey("Comentariocaja" + j))
                {
                    comentariocaja = (Application.Current.Properties["Comentariocaja" + j] as string);
                }
                else { comentariocaja = ""; }
                



                Cajas.Add(new Caja() //agrega a mi lista todos los elementos existentes en persistencia
                {
                    Activa = activacaja,
                    Comentario = comentariocaja,
                    FechaEntrega = fechaentregacaja,
                    IdCaja = idcaja,
                    TipoCaja = tipocaja,

                });
            }

            IsRefreshing = false;

            HeighListViewCaja = 44 * Cajas.Count; //cantidad de filas en mi lista, multiplicado por 44 que es el alto maximo de cada fila

        }
        
        async void Guardar()
        {
            isEnabled = false;
            if (string.IsNullOrEmpty(FechaEntrega.ToString())){
               await Application.Current.MainPage.DisplayAlert("error", "Debe Llenar El Campo Fecha", "Excelente");
               IsEnabled = true;
               return;
            }
            var fecha = FechaEntrega.ToString();

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


            #region Miranda: Guardar Tabla Cajas

            #region Ciclo para Guardar en Persistencia
            if (Application.Current.Properties.ContainsKey("Contadorcajas"))//verifico cuantos elementos tiene mi lista para saber cual es la psocion del nuevo elemento a agregar
            {
                ElementosCaja = (int.Parse((Application.Current.Properties["Contadorcajas"]) as string));
            }
            else { ElementosCaja = 0; }

            if (FloraNueva)
            {
                activacaja = "No";
            }
            else
            {
                activacaja = "Si";
            }
            string fechaEntrega = FechaEntrega.ToString();
            if (string.IsNullOrEmpty(Tipo))
            {
                Tipo = "";
            }
            if (string.IsNullOrEmpty(Comentario))//si no hago esto, se le pasan valores nulos a persistencia
            {
                Comentario = "";
            }

            Application.Current.Properties["Idcaja" + ElementosCaja] = IdCaja.ToString();
            Application.Current.Properties["Tipocaja" + ElementosCaja] = Tipo.ToString();
            Application.Current.Properties["Fechaentregacaja" + ElementosCaja] = (FechaEntrega).ToString(); //revisar, cuando no se selecciona fecha esta linea manda error OJOO
            Application.Current.Properties["Activacaja" + ElementosCaja] = activacaja.ToString();
            Application.Current.Properties["Comentariocaja" + ElementosCaja] = Comentario.ToString();
            Application.Current.Properties["Contadorcajas"] = (ElementosCaja + 1).ToString();
            await Application.Current.SavePropertiesAsync();
            #endregion


            int filascaja;
            filascaja = ElementosCaja + 1;
            HeighListViewCaja = 44 * filascaja;//actalizo mi heigh
            await Application.Current.MainPage.DisplayAlert("Notificación", "Usted Tiene hasta Ahora: " + filascaja + " Cajas Registradas", "Excelente");
            Cajas.Add(new Caja()
            {
                Activa = activacaja.ToString(),
                Comentario = Comentario.ToString(),
                FechaEntrega = FechaEntrega,
                IdCaja = IdCaja, //int
                TipoCaja = Tipo.ToString(),
                
            });
            ANMeliponarioViewModel.GetInstance().CajasAN = this.Cajas; //asigno los datos de mi lista 
            ANMeliponarioViewModel.GetInstance().HeighListViewAN = this.HeighListViewCaja; //actualizo el heigh de mi vista anterior
            IsEnabled = true;

            await Application.Current.MainPage.Navigation.PopAsync();

            #endregion


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
