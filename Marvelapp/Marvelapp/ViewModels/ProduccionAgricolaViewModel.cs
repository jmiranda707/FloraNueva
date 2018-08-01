using GalaSoft.MvvmLight.Command;
using Marvelapp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class ProduccionAgricolaViewModel : INotifyPropertyChanged
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
        private int ElementosAnimal;
        private int ElementosVegetal;
        private string categoriavegetal;
        private string nombreanimal;
        private string detalleanimal;
        private string cantidadanimal;
        private string detallevegetal;
        private string superficievegetal;
        int k;
        int i;
        private ObservableCollection<Animal> animal;
        private ObservableCollection<Vegetal> vegetal;
        private Double heighListAnimal;
        private Double heighListVegetal;
        private bool isRefreshing;
        private bool isEnabled;

        string _FormaJuridica;
        bool _PropiosAlimentos;
        string _Organizaciones;
        string _TenenciaTierra;
        bool _DuenoTerreno;
        string _EspecificarTerreno;
        string _UbicacionTierra;
        string _SuperficieParcela;
        string _DescripcionFinca;
        string _ProduccionPrincipal;
        string _OtraProduccion;
        string _Abono;
        string _ControlMalezas;
        string _Plaguicidas;
        string _Semillas;
        string _RiegoCultivos;
        bool _PoseeCertificacion;
        string _Certifiacion;
        string _CategoriaManejo;
        string _Manejo;
        string _ListaMaquinarias;
        string _CategoriaMecanizacion;
        string _ListaInfraestructura;
        string _CatInfraestructura;
        bool _TransValorAgregado;
        string _ValorAgregado;
        string _DestinoProduccion;
        string _CanalesComercializacion;
        string _CatExplotacion;
        string _TecnicoEco;
        string _ComExplotacion;
        #endregion

        #region Properties
        public Double HeighListViewAnimal
        {
            get
            {
                return heighListAnimal;
            }
            set
            {
                if (heighListAnimal != value)
                {
                    heighListAnimal = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(HeighListViewAnimal)));
                }
            }
        }
        public Double HeighListViewVegetal
        {
            get
            {
                return heighListVegetal;
            }
            set
            {
                if (heighListVegetal != value)
                {
                    heighListVegetal = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(HeighListViewVegetal)));
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
        public ObservableCollection<Animal> Animales
        {
            get
            {
                return animal;
            }
            set
            {
                if (animal != value)
                {
                    animal = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(Animales)));
                }
            }
        }
        public ObservableCollection<Vegetal> Vegetales
        {
            get
            {
                return vegetal;
            }
            set
            {
                if (vegetal != value)
                {
                    vegetal = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(Vegetales)));
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
        public string ComExplotacion
        {
            get { return _ComExplotacion; }
            set
            {
                _ComExplotacion = value;
                OnPropertyChanged("ComExplotacion");
            }
        }
        public string TecnicoEco
        {
            get { return _TecnicoEco; }
            set
            {
                _TecnicoEco = value;
                OnPropertyChanged("TecnicoEco");
            }
        }
        public string CatExplotacion
        {
            get { return _CatExplotacion; }
            set
            {
                _CatExplotacion = value;
                OnPropertyChanged("CatExplotacion");
            }
        }
        public string CanalesComercializacion
        {
            get { return _CanalesComercializacion; }
            set
            {
                _CanalesComercializacion = value;
                OnPropertyChanged("CanalesComercializacion");
            }
        }
        public string DestinoProduccion
        {
            get { return _DestinoProduccion; }
            set
            {
                _DestinoProduccion = value;
                OnPropertyChanged("DestinoProduccion");
            }
        }
        public string ValorAgregado
        {
            get { return _ValorAgregado; }
            set
            {
                _ValorAgregado = value;
                OnPropertyChanged("ValorAgregado");
            }
        }
        public bool TransValorAgregado
        {
            get { return _TransValorAgregado; }
            set
            {
                _TransValorAgregado = value;
                OnPropertyChanged("TransValorAgregado");
            }
        }
        public string CatInfraestructura
        {
            get { return _CatInfraestructura; }
            set
            {
                _CatInfraestructura = value;
                OnPropertyChanged("CatInfraestructura");
            }
        }
        public string ListaInfraestructura
        {
            get { return _ListaInfraestructura; }
            set
            {
                _ListaInfraestructura = value;
                OnPropertyChanged("ListaInfraestructura");
            }
        }
        public string CategoriaMecanizacion
        {
            get { return _CategoriaMecanizacion; }
            set
            {
                _CategoriaMecanizacion = value;
                OnPropertyChanged("CategoriaMecanizacion");
            }
        }
        public string ListaMaquinarias
        {
            get { return _ListaMaquinarias; }
            set
            {
                _ListaMaquinarias = value;
                OnPropertyChanged("ListaMaquinarias");
            }
        }
        public string Manejo
        {
            get { return _Manejo; }
            set
            {
                _Manejo = value;
                OnPropertyChanged("Manejo");
            }
        }
        public string CategoriaManejo
        {
            get { return _CategoriaManejo; }
            set
            {
                _CategoriaManejo = value;
                OnPropertyChanged("CategoriaManejo");
            }
        }
        public string Certifiacion
        {
            get { return _Certifiacion; }
            set
            {
                _Certifiacion = value;
                OnPropertyChanged("Certifiacion");
            }
        }
        public bool PoseeCertificacion
        {
            get { return _PoseeCertificacion; }
            set
            {
                _PoseeCertificacion = value;
                OnPropertyChanged("PoseeCertificacion");
            }
        }
        public string RiegoCultivos
        {
            get { return _RiegoCultivos; }
            set
            {
                _RiegoCultivos = value;
                OnPropertyChanged("RiegoCultivos");
            }
        }
        public string Semillas
        {
            get { return _Semillas; }
            set
            {
                _Semillas = value;
                OnPropertyChanged("Semillas");
            }
        }
        public string Plaguicidas
        {
            get { return _Plaguicidas; }
            set
            {
                _Plaguicidas = value;
                OnPropertyChanged("Plaguicidas");
            }
        }
        public string ControlMalezas
        {
            get { return _ControlMalezas; }
            set
            {
                _ControlMalezas = value;
                OnPropertyChanged("ControlMalezas");
            }
        }
        public string Abono
        {
            get { return _Abono; }
            set
            {
                _Abono = value;
                OnPropertyChanged("Abono");
            }
        }
        public string OtraProduccion
        {
            get { return _OtraProduccion; }
            set
            {
                _OtraProduccion = value;
                OnPropertyChanged("OtraProduccion");
            }
        }
        public string ProduccionPrincipal
        {
            get { return _ProduccionPrincipal; }
            set
            {
                _ProduccionPrincipal = value;
                OnPropertyChanged("ProduccionPrincipal");
            }
        }
        public string DescripcionFinca
        {
            get { return _DescripcionFinca; }
            set
            {
                _DescripcionFinca = value;
                OnPropertyChanged("DescripcionFinca");
            }
        }
        public string SuperficieParcela
        {
            get { return _SuperficieParcela; }
            set
            {
                _SuperficieParcela = value;
                OnPropertyChanged("SuperficieParcela");
            }
        }
        public string UbicacionTierra
        {
            get { return _UbicacionTierra; }
            set
            {
                _UbicacionTierra = value;
                OnPropertyChanged("UbicacionTierra");
            }
        }
        public string EspecificarTerreno
        {
            get { return _EspecificarTerreno; }
            set
            {
                _EspecificarTerreno = value;
                OnPropertyChanged("EspecificarTerreno");
            }
        }
        public bool DuenoTerreno
        {
            get { return _DuenoTerreno; }
            set
            {
                _DuenoTerreno = value;
                OnPropertyChanged("DuenoTerreno");
            }
        }
        public string TenenciaTierra
        {
            get { return _TenenciaTierra; }
            set
            {
                _TenenciaTierra = value;
                OnPropertyChanged("TenenciaTierra");
            }
        }
        public string Organizaciones
        {
            get { return _Organizaciones; }
            set
            {
                _Organizaciones = value;
                OnPropertyChanged("Organizaciones");
            }
        }
        public bool PropiosAlimentos
        {
            get { return _PropiosAlimentos; }
            set
            {
                _PropiosAlimentos = value;
                OnPropertyChanged("PropiosAlimentos");
            }
        }
        public string FormaJuridica
        {
            get { return _FormaJuridica; }
            set
            {
                _FormaJuridica = value;
                OnPropertyChanged("FormaJuridica");
            }
        }
        #endregion

        #region Constructors
        public ProduccionAgricolaViewModel()
        {
            instance = this;
            Vegetales = new ObservableCollection<Vegetal>();
            Animales = new ObservableCollection<Animal>();
            LoadAnimales(); //carga el listado de Animales
            LoadVegetales(); //carga el listado de Vegetales

        }

        #endregion


        #region Commands
        public ICommand AgregarAnimalCommand
        {
            get
            {
                return new RelayCommand(AgregarAnimal);
            }
        }
        public ICommand AgregarVegetalCommand
        {
            get
            {
                return new RelayCommand(AgregarVegetal);
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
        async private void LoadVegetales()
        {
            if (Application.Current.Properties.ContainsKey("ContadorVegetales")) //contador de la cantidad de elementos en la lista
            {
                ElementosVegetal = int.Parse((Application.Current.Properties["ContadorVegetales"]) as string);
            }
            else { ElementosVegetal = 0; }

            IsRefreshing = true;

            for (int j = 0; j < ElementosVegetal; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("DetalleVegetal" + j))
                {
                    detallevegetal = (Application.Current.Properties["DetalleVegetal" + j]) as string;
                }
                else { detallevegetal = ""; }

                if (Application.Current.Properties.ContainsKey("SuperficieVegetal" + j))
                {
                    superficievegetal = (Application.Current.Properties["SuperficieVegetal" + j] as string);
                }
                else { superficievegetal = ""; }
                if (Application.Current.Properties.ContainsKey("CategoriaVegetal" + j))
                {
                    categoriavegetal = (Application.Current.Properties["CategoriaVegetal" + j] as string);
                }
                else { categoriavegetal = ""; }

                Vegetales.Add(new Vegetal() //agrega a mi lista todos los elementos existentes en persistencia
                {
                    CategoriaVegetal=categoriavegetal,
                    DetalleVegetal = detallevegetal,
                    SuperficieVegetal = superficievegetal,
                });
            }

            IsRefreshing = false;

            HeighListViewVegetal = 44 * Vegetales.Count; //cantidad de filas en mi lista, multiplicado por 44 que es el alto maximo de cada fila

        }

        async private void LoadAnimales()
        {
            if (Application.Current.Properties.ContainsKey("ContadorAnimales")) //contador de la cantidad de elementos en la lista
            {
                ElementosAnimal = int.Parse((Application.Current.Properties["ContadorAnimales"]) as string);
            }
            else { ElementosAnimal = 0; }

            IsRefreshing = true;

            for (int j = 0; j < ElementosAnimal; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("DetalleAnimal" + j))
                {
                    detalleanimal = (Application.Current.Properties["DetalleAnimal" + j]) as string;
                }
                else { detalleanimal = ""; }
                if (Application.Current.Properties.ContainsKey("NombreAnimal" + j))
                {
                    nombreanimal = (Application.Current.Properties["NombreAnimal" + j]) as string;
                }
                else { nombreanimal = ""; }

                if (Application.Current.Properties.ContainsKey("CantidadAnimal" + j))
                {
                    cantidadanimal = (Application.Current.Properties["CantidadAnimal" + j] as string);
                }
                else { cantidadanimal = ""; }

                Animales.Add(new Animal() //agrega a mi lista todos los elementos existentes en persistencia
                {
                    DetalleAnimal = detalleanimal,
                    CantidadAnimal = cantidadanimal,
                    NombreAnimal= nombreanimal,
                });
            }

            IsRefreshing = false;

            HeighListViewAnimal = 44 * Animales.Count; //cantidad de filas en mi lista, multiplicado por 44 que es el alto maximo de cada fila

        }

        async void Guardar()
        {
            #region Eleazar
            /*
             if (string.IsNullOrEmpty(FormaJuridica) || string.IsNullOrEmpty(Organizaciones) || string.IsNullOrEmpty(TenenciaTierra) ||
                string.IsNullOrEmpty(EspecificarTerreno) || string.IsNullOrEmpty(UbicacionTierra) || string.IsNullOrEmpty(SuperficieParcela) ||
                string.IsNullOrEmpty(DescripcionFinca) || string.IsNullOrEmpty(ProduccionPrincipal) || string.IsNullOrEmpty(OtraProduccion) ||
                string.IsNullOrEmpty(Abono) || string.IsNullOrEmpty(ControlMalezas) || string.IsNullOrEmpty(Plaguicidas) ||
                string.IsNullOrEmpty(Semillas) || string.IsNullOrEmpty(RiegoCultivos) || string.IsNullOrEmpty(Certifiacion) ||
                string.IsNullOrEmpty(CategoriaManejo) || string.IsNullOrEmpty(Manejo) || string.IsNullOrEmpty(ListaMaquinarias) ||
                string.IsNullOrEmpty(CategoriaMecanizacion) || string.IsNullOrEmpty(ListaInfraestructura) ||
                string.IsNullOrEmpty(CatInfraestructura) || string.IsNullOrEmpty(ValorAgregado) || string.IsNullOrEmpty(DestinoProduccion) ||
                string.IsNullOrEmpty(CanalesComercializacion) || string.IsNullOrEmpty(CatExplotacion) || string.IsNullOrEmpty(TecnicoEco) ||
                string.IsNullOrEmpty(ComExplotacion))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Llene los campos obligatorios", "aceptar");
                return;
            }

            await Application.Current.MainPage.DisplayAlert(
                "Hola",
                "Guardar",
                "Aceptar");
             */
            #endregion

            #region Miranda: Guardar Tabla Animal

            #region Limpiar Cache //borrar los datos existentes en persistencia

            if (Application.Current.Properties.ContainsKey("ContadorAnimales"))
            {
                ElementosAnimal = int.Parse((Application.Current.Properties["ContadorAnimales"]) as string);
            }
            else { ElementosAnimal = 0; }
            for (int j = 0; j < ElementosAnimal; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("DetalleAnimal" + j))
                {
                    Application.Current.Properties.Remove("DetalleAnimal" + j);
                }
                if (Application.Current.Properties.ContainsKey("NombreAnimal" + j))
                {
                    Application.Current.Properties.Remove("NombreAnimal" + j);
                }
                if (Application.Current.Properties.ContainsKey("CantidadAnimal" + j))
                {
                    Application.Current.Properties.Remove("CantidadAnimal" + j);
                }
                if (Application.Current.Properties.ContainsKey("ContadorAnimales"))
                {
                    Application.Current.Properties.Remove("ContadorAnimales");
                }
            }

            #endregion

            #region Ciclo para Guardar en Persistencia
            i = 0; //inicio el contador de mis elementos o filas en (0)
            foreach (var animal in Animales)
            {
                Application.Current.Properties["DetalleAnimal" + i] = animal.DetalleAnimal.ToString();
                Application.Current.Properties["CantidadAnimal" + i] = animal.CantidadAnimal.ToString();
                Application.Current.Properties["NombreAnimal" + i] = animal.NombreAnimal.ToString();
                i++;
                Application.Current.Properties["ContadorAnimales"] = i.ToString();
                await Application.Current.SavePropertiesAsync();
            }

            #endregion

            int filas;
            HeighListViewAnimal = 55 * i;
            if (Application.Current.Properties.ContainsKey("ContadorAnimales"))
            {
                filas = int.Parse(Application.Current.Properties["ContadorAnimales"] as string);
            }
            else { filas = 0; }
            await Application.Current.MainPage.DisplayAlert("Notificación", "El Numero de Filas Guardadas en Produccion Animal es: " + filas.ToString(), "Excelente");
            IsEnabled = true;

            #endregion

            #region Miranda: Guardar Tabla Vegetal

            #region Limpiar Cache //borrar los datos existentes en persistencia

            if (Application.Current.Properties.ContainsKey("ContadorVegetales"))
            {
                ElementosVegetal = int.Parse((Application.Current.Properties["ContadorVegetales"]) as string);
            }
            else { ElementosAnimal = 0; }
            for (int j = 0; j < ElementosVegetal; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("DetalleVegetal" + j))
                {
                    Application.Current.Properties.Remove("DetalleVegetal" + j);
                }
                if (Application.Current.Properties.ContainsKey("CategoriaVegetal" + j))
                {
                    Application.Current.Properties.Remove("CategoriaVegetal" + j);
                }
                if (Application.Current.Properties.ContainsKey("SuperficieVegetal" + j))
                {
                    Application.Current.Properties.Remove("SuperficieVegetal" + j);
                }
                if (Application.Current.Properties.ContainsKey("ContadorVegetales"))
                {
                    Application.Current.Properties.Remove("ContadorVegetales");
                }
            }

            #endregion

            #region Ciclo para Guardar en Persistencia
            k = 0; //inicio el contador de mis elementos o filas en (0)
            foreach (var vegetal in Vegetales)
            {
                Application.Current.Properties["DetalleVegetal" + k] = vegetal.DetalleVegetal.ToString();
                Application.Current.Properties["SuperficieVegetal" + k] = vegetal.SuperficieVegetal.ToString();
                Application.Current.Properties["CategoriaVegetal" + k] = vegetal.CategoriaVegetal.ToString();
                k++;
                Application.Current.Properties["ContadorVegetales"] = k.ToString();
                await Application.Current.SavePropertiesAsync();
            }

            #endregion

            int filasveg;
            HeighListViewVegetal = 44 * k;
            if (Application.Current.Properties.ContainsKey("ContadorVegetales"))
            {
                filasveg = int.Parse(Application.Current.Properties["ContadorVegetales"] as string);
            }
            else { filasveg = 0; }
            await Application.Current.MainPage.DisplayAlert("Notificación", "El Numero de Filas Guardadas en Produccion Vegetal es: " + filasveg + "", "Excelente");
            IsEnabled = true;

            #endregion

        }
        async void AgregarAnimal()
        {
            IsRefreshing = true;
            Animales.Add(new Animal()
            {
                DetalleAnimal="",
                CantidadAnimal="",
                NombreAnimal="",
            });
            HeighListViewAnimal = HeighListViewAnimal + 44;
            IsRefreshing = false;
        }
        async void AgregarVegetal()
        {
            IsRefreshing = true;
            Vegetales.Add(new Vegetal()
            {
                DetalleVegetal = "",
                SuperficieVegetal = "",
                CategoriaVegetal="",
            });
            HeighListViewVegetal = HeighListViewVegetal + 44;
            IsRefreshing = false;


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
        private static ProduccionAgricolaViewModel instance;
        public static ProduccionAgricolaViewModel GetInstance()
        {
            if (instance == null)
            {
                return new ProduccionAgricolaViewModel();
            }
            return instance;
        }
        #endregion

    }
}
