using GalaSoft.MvvmLight.Command;
using Marvelapp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class InventarioEspeciesViewModel : INotifyPropertyChanged
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
        int i;
        private ObservableCollection<Inventario> inventario;
        private Double heighList;
        private bool isRefreshing;
        private bool isEnabled;
        private int cantidadCajaTecnificada;
        private int cantidadCajaRustica;
        private int cantidadNidoArtificial;
        private int cantidadEnTronco;
        private string especie;
        string _productores;
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
        public ObservableCollection<Inventario> Inventarios
        {
            get
            {
                return inventario;
            }
            set
            {
                if (inventario != value)
                {
                    inventario = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(Inventario)));
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
        public string Productores
        {
            get { return _productores; }
            set
            {
                _productores = value;
                OnPropertyChanged("Productores");
            }
        }
        public string Especie
        {
            get { return especie; }
            set
            {
                especie = value;
                OnPropertyChanged("Especie");
            }
        }
        public int CantidadEnTronco
        {
            get { return cantidadEnTronco; }
            set
            {
                cantidadEnTronco = value;
                OnPropertyChanged("CantidadEnTronco");
            }
        }
        public int CantidadNidoArtificial
        {
            get { return cantidadNidoArtificial; }
            set
            {
                cantidadNidoArtificial = value;
                OnPropertyChanged("CantidadNidoArtificial");
            }
        }
        public int CantidadCajaRustica
        {
            get { return cantidadCajaRustica; }
            set
            {
                cantidadCajaRustica = value;
                OnPropertyChanged("CantidadCajaRustica");
            }
        }
        public int CantidadCajaTecnificada
        {
            get { return cantidadCajaTecnificada; }
            set
            {
                cantidadCajaTecnificada = value;
                OnPropertyChanged("CantidadCajaTecnificada");
            }
        }
        #endregion

        #region ApiServices

        #endregion

        #region constructors
        public InventarioEspeciesViewModel()
        {
            Inventarios = new ObservableCollection<Inventario>();
            LoadInventarios(); //carga el listado de inventarios
            IsEnabled = true;
            instance = this;
            string productores; //esto es provisional, debe eliminarse la condicion
            if (Application.Current.Properties.ContainsKey("Productores"))
            {
                productores = Application.Current.Properties["Productores"] as string;
            }
            else { productores = "Alejandro Navarro"; }

            this.Productores = productores;
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
        int tronco, artificial, rustica, tecnificada;
        string especies;
        async void LoadInventarios()
        {
            if (Application.Current.Properties.ContainsKey("ContadorInventarios")) //contador de la cantidad de elementos en la lista
            {
                Elementos = int.Parse((Application.Current.Properties["ContadorInventarios"]) as string);
            }
            else { Elementos = 0; }

            IsRefreshing = true;

            for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("Especie" + j))
                {
                    especies = (Application.Current.Properties["Especie" + j]) as string;
                }
                else { especies = ""; }

                if (Application.Current.Properties.ContainsKey("CantidadTronco" + j))
                {
                    tronco = int.Parse(Application.Current.Properties["CantidadTronco" + j] as string);
                }
                else { tronco = 0; }
                if (Application.Current.Properties.ContainsKey("CantidadArtificial" + j))
                {
                    artificial = int.Parse(Application.Current.Properties["CantidadArtificial" + j] as string);
                }
                else { artificial = 0; }
                if (Application.Current.Properties.ContainsKey("CantidadRustica" + j))
                {
                    rustica = int.Parse(Application.Current.Properties["CantidadRustica" + j] as string);
                }
                else { rustica = 0; }
                if (Application.Current.Properties.ContainsKey("CantidadTecnificada" + j))
                {
                    tecnificada = int.Parse(Application.Current.Properties["CantidadTecnificada" + j] as string);
                }
                else { tecnificada = 0; }
                
                Inventarios.Add(new Inventario() //agrega a mi lista todos los elementos existentes en persistencia
                {
                    CantidadArtificial = artificial,
                    CantidadRustica = rustica,
                    CantidadTecnificada = tecnificada,
                    CantidadTronco = tronco,
                    Especie = especies,

                });
            }

            IsRefreshing = false;

            HeighListView = 44 * Inventarios.Count; //cantidad de filas en mi lista, multiplicado por 44 que es el alto maximo de cada fila
        }

        private async void Guardar()
        {
            IsEnabled = false;
            #region Descomentar Esto
            /*
             #region Validaciones  
            if ((CantidadEnTronco == 0) || string.IsNullOrEmpty(CantidadEnTronco.ToString()) ||
                (CantidadNidoArtificial == 0) || string.IsNullOrEmpty(CantidadNidoArtificial.ToString()) ||
                (CantidadCajaRustica == 0) || string.IsNullOrEmpty(CantidadCajaRustica.ToString()) ||
                (CantidadCajaTecnificada == 0) || string.IsNullOrEmpty(CantidadCajaTecnificada.ToString()) ||
                string.IsNullOrEmpty(Especie))
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Por Favor Llene los Campos Obligatorios", "Aceptar");
                IsEnabled = true;
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
                IsEnabled = true;
            }
             */
            #endregion

            #region Miranda: Guardar Tabla

            #region Ciclo para Guardar en Persistencia
            if (Application.Current.Properties.ContainsKey("ContadorInventarios"))//verifico cuantos elementos tiene mi lista para saber cual es la psocion del nuevo elemento a agregar
            {
                Elementos = (int.Parse((Application.Current.Properties["ContadorInventarios"]) as string));
            }
            else { Elementos = 0; }

            Application.Current.Properties["Especie" + Elementos] = Especie.ToString();
            Application.Current.Properties["CantidadTronco" + Elementos] = CantidadEnTronco.ToString();
            Application.Current.Properties["CantidadArtificial" + Elementos] = CantidadNidoArtificial.ToString();
            Application.Current.Properties["CantidadRustica" + Elementos] = CantidadCajaRustica.ToString();
            Application.Current.Properties["CantidadTecnificada" + Elementos] = CantidadCajaTecnificada.ToString();
            Application.Current.Properties["ContadorInventarios"] = (Elementos + 1).ToString();
            await Application.Current.SavePropertiesAsync();
            #endregion


            int filas;
            filas = Elementos + 1;
            HeighListView = 44 * filas;//actalizo mi heigh
            await Application.Current.MainPage.DisplayAlert("Notificación", "Usted Tiene hasta Ahora: " + filas + " Elementos en Inventario", "Excelente");
            IsEnabled = true;
            Inventarios.Add(new Inventario()
            {
                CantidadArtificial = CantidadNidoArtificial,
                CantidadRustica = CantidadCajaRustica,
                CantidadTecnificada = CantidadCajaTecnificada,
                CantidadTronco = CantidadEnTronco,
                Especie = Especie,
            });
            MeliponiculturaViewModel.GetInstance().InventariosMeliponicultura = this.Inventarios; //asigno los datos de mi lista 
            MeliponiculturaViewModel.GetInstance().HeighListViewB = this.HeighListView; //actualizo el heigh de mi vista anterior

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
        #endregion

        #region Singleton 
        private static InventarioEspeciesViewModel instance;
        public static InventarioEspeciesViewModel GetInstance()
        {
            if (instance == null)
            {
                return new InventarioEspeciesViewModel();
            }
            return instance;
        }
        #endregion

    }
}
