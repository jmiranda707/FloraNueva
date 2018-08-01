using Marvelapp.Views;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.Collections.ObjectModel;
using Marvelapp.Models;

namespace Marvelapp.ViewModels
{
    public class MeliponiculturaViewModel : INotifyPropertyChanged
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
        private ObservableCollection<Inventario> inventariomeliponicultura;
        private bool isEnabled;
        private string comentarioMeliponicultura;
        private string nivelConocimiento;
        private string comoAprendioCriarlas;
        private string motivacionTenerla;
        private string riesgoRobo;
        private string potencialLugarTenerAbejas;
        private string diagnosticoMeliponario;
        private string dondeUbicanColmenas;
        private string dondeColocaColmena;
        private int precioVenta;
        private string dondeSeVende;
        private string selectedOption;
        private string comoCosecha;
        private bool abejasSinAguijon;
        private bool produceMiel;
        private string comoObtuvoColmena;
        private int desdeCuando;
        private string otrasEspecies;
        string _productores;
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
        public ObservableCollection<Inventario> InventariosMeliponicultura
        {
            get
            {
                return inventariomeliponicultura;
            }
            set
            {
                if (inventariomeliponicultura != value)
                {
                    inventariomeliponicultura = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(InventariosMeliponicultura)));
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
        public bool ProduceMiel
        {
            get { return produceMiel; }
            set
            {
                produceMiel = value;
                OnPropertyChanged("ProduceMiel");
            }
        }
        public bool AbejasSinAguijon
        {
            get { return abejasSinAguijon; }
            set
            {
                abejasSinAguijon = value;
                OnPropertyChanged("AbejasSinAguijon");
            }
        }
        public int DesdeCuando
        {
            get { return desdeCuando; }
            set
            {
                desdeCuando = value;
                OnPropertyChanged("DesdeCuando");
            }
        }
        public string OtrasEspecies
        {
            get { return otrasEspecies; }
            set
            {
                otrasEspecies = value;
                OnPropertyChanged("OtrasEspecies");
            }
        }
        public string ComoObtuvoColmena
        {
            get { return comoObtuvoColmena; }
            set
            {
                comoObtuvoColmena = value;
                OnPropertyChanged("ComoObtuvoColmena");
            }
        }
        public string ComoCosecha
        {
            get { return comoCosecha; }
            set
            {
                comoCosecha = value;
                OnPropertyChanged("ComoCosecha");
            }
        }
        public string SelectedOption
        {
            get { return selectedOption; }
            set
            {
                selectedOption = value;
                OnPropertyChanged("SelectedOption");
            }
        }
        public string DondeSeVende
        {
            get { return dondeSeVende; }
            set
            {
                dondeSeVende = value;
                OnPropertyChanged("DondeSeVende");
            }
        }
        public int PrecioVenta
        {
            get { return precioVenta; }
            set
            {
                precioVenta = value;
                OnPropertyChanged("PrecioVenta");
            }
        }
        public string DondeColocaColmena
        {
            get { return dondeColocaColmena; }
            set
            {
                dondeColocaColmena = value;
                OnPropertyChanged("DondeColocaColmena");
            }
        }
        public string DondeUbicanColmenas
        {
            get { return dondeUbicanColmenas; }
            set
            {
                dondeUbicanColmenas = value;
                OnPropertyChanged("DondeUbicanColmenas");
            }
        }
        public string DiagnosticoMeliponario
        {
            get { return diagnosticoMeliponario; }
            set
            {
                diagnosticoMeliponario = value;
                OnPropertyChanged("DiagnosticoMeliponario");
            }
        }
        public string PotencialLugarTenerAbejas
        {
            get { return potencialLugarTenerAbejas; }
            set
            {
                potencialLugarTenerAbejas = value;
                OnPropertyChanged("PotencialLugarTenerAbejas");
            }
        }
        public string RiesgoRobo
        {
            get { return riesgoRobo; }
            set
            {
                riesgoRobo = value;
                OnPropertyChanged("RiesgoRobo");
            }
        }
        public string MotivacionTenerla
        {
            get { return motivacionTenerla; }
            set
            {
                motivacionTenerla = value;
                OnPropertyChanged("MotivacionTenerla");
            }
        }
        public string ComoAprendioCriarlas
        {
            get { return comoAprendioCriarlas; }
            set
            {
                comoAprendioCriarlas = value;
                OnPropertyChanged("ComoAprendioCriarlas");
            }
        }
        public string NivelConocimiento
        {
            get { return nivelConocimiento; }
            set
            {
                nivelConocimiento = value;
                OnPropertyChanged("NivelConocimiento");
            }
        }
        public string ComentarioMeliponicultura
        {
            get { return comentarioMeliponicultura; }
            set
            {
                comentarioMeliponicultura = value;
                OnPropertyChanged("ComentarioMeliponicultura");
            }
        }
        #endregion

        #region ApiServices

        #endregion

        #region constructors
        public MeliponiculturaViewModel()
        {
            IsEnabled = true;
            instance = this;
            InventariosMeliponicultura = InventarioEspeciesViewModel.GetInstance().Inventarios; //obtengo los datos de mi lista en InventarioEspeciesViewModel
            HeighListViewB = InventarioEspeciesViewModel.GetInstance().HeighListView; //obtengo el heigh de InventarioEspeciesViewModel
            string productores; //esto es provicional, debe eliminarse la condicion
            if (Application.Current.Properties.ContainsKey("Productores")) 
            {
                 productores = Application.Current.Properties["Productores"] as string;
            }
            else { productores = "Alejandro Navarro"; }

            this.Productores = productores;
        }
        #endregion

        #region Commands
        public ICommand InventarioCommand
        {
            get
            {
                return new RelayCommand(Inventario);
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
        async void Inventario()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new InventarioEspeciesPage());
        }
        private async void Guardar()
        {
            IsEnabled = false;
            #region OJOOOO Descomentar Todo Esto
            /*
              #region Validaciones  
            if (string.IsNullOrEmpty(OtrasEspecies) ||
                string.IsNullOrEmpty(ComoObtuvoColmena) ||
                string.IsNullOrEmpty(ComoCosecha) ||
                string.IsNullOrEmpty(SelectedOption) ||
                string.IsNullOrEmpty(DondeColocaColmena) ||
                (PrecioVenta == 0) ||
                string.IsNullOrEmpty(PrecioVenta.ToString()) ||
                (DesdeCuando == 0) ||
                string.IsNullOrEmpty(DesdeCuando.ToString()) ||
                string.IsNullOrEmpty(DondeColocaColmena) ||
                string.IsNullOrEmpty(DondeUbicanColmenas) ||
                string.IsNullOrEmpty(DiagnosticoMeliponario) ||
                string.IsNullOrEmpty(PotencialLugarTenerAbejas) ||
                string.IsNullOrEmpty(RiesgoRobo) ||
                string.IsNullOrEmpty(MotivacionTenerla) ||
                string.IsNullOrEmpty(ComoAprendioCriarlas) ||
                string.IsNullOrEmpty(NivelConocimiento) ||
                string.IsNullOrEmpty(ComentarioMeliponicultura))

            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Por Favor Llene los Campos Obligatorios", "Aceptar");
                IsEnabled = true;
                return;
            }
            #endregion
            else
            {
                await Application.Current.MainPage.DisplayAlert("Guardado", selectedOption, "Excelente");
                OtrasEspecies = string.Empty;
                PotencialLugarTenerAbejas = string.Empty;
                ComentarioMeliponicultura = string.Empty;
                NivelConocimiento = string.Empty;
                ComoAprendioCriarlas = string.Empty;
                MotivacionTenerla = string.Empty;
                RiesgoRobo = string.Empty;
                PrecioVenta = 0;
                DiagnosticoMeliponario = string.Empty;
                DondeUbicanColmenas = string.Empty;
                DondeColocaColmena = string.Empty;
                DesdeCuando = 0;
                ComoObtuvoColmena = string.Empty;
                ComoCosecha = string.Empty;
                SelectedOption = string.Empty;
                DondeColocaColmena = string.Empty;
                IsEnabled = true;

            }
            */
            #endregion

            #region Limpiar Cache //borrar los datos existentes en persistencia

            if (Application.Current.Properties.ContainsKey("ContadorInventarios"))
            {
                Elementos = int.Parse((Application.Current.Properties["ContadorInventarios"]) as string);
            }
            else { Elementos = 0; }
            for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("Especie" + j))
                {
                    Application.Current.Properties.Remove("Especie" + j);
                }
                if (Application.Current.Properties.ContainsKey("CantidadTronco" + j))
                {
                    Application.Current.Properties.Remove("CantidadTronco" + j);
                }
                if (Application.Current.Properties.ContainsKey("CantidadArtificial"))
                {
                    Application.Current.Properties.Remove("CantidadArtificial");
                }
                if (Application.Current.Properties.ContainsKey("CantidadRustica"))
                {
                    Application.Current.Properties.Remove("CantidadRustica");
                }
                if (Application.Current.Properties.ContainsKey("CantidadTecnificada"))
                {
                    Application.Current.Properties.Remove("CantidadTecnificada");
                }
                
            }

            #endregion

            #region Ciclo para Guardar en Persistencia mi lista Actual
            i = 0; //inicio el contador de mis elementos o filas en (0)
            foreach (var inventario in InventariosMeliponicultura)
            {
                Application.Current.Properties["Especie" + i] = inventario.Especie.ToString();
                Application.Current.Properties["CantidadTronco" + i] = inventario.CantidadTronco.ToString();
                Application.Current.Properties["CantidadArtificial" + i] = inventario.CantidadArtificial.ToString();
                Application.Current.Properties["CantidadRustica" + i] = inventario.CantidadRustica.ToString();
                Application.Current.Properties["CantidadTecnificada" + i] = inventario.CantidadTecnificada.ToString();
                i++;
                Application.Current.Properties["ContadorInventarios"] = i.ToString();
                await Application.Current.SavePropertiesAsync();
            }

            #endregion

            int filas;
            filas = InventariosMeliponicultura.Count;
            Application.Current.Properties["ContadorInventarios"] = filas.ToString();
            await Application.Current.SavePropertiesAsync();
            HeighListViewB = 44 * filas;//actalizo mi heigh
            InventarioEspeciesViewModel.GetInstance().Inventarios = this.InventariosMeliponicultura; //asigno los datos de mi lista 
            await Application.Current.MainPage.DisplayAlert("Notificación", "Hay: " + filas + " Elementos en Inventario", "Excelente");
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
        #endregion

        #region Singleton 
        private static MeliponiculturaViewModel instance;
        public static MeliponiculturaViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MeliponiculturaViewModel();
            }
            return instance;
        }
        #endregion
    }
}
