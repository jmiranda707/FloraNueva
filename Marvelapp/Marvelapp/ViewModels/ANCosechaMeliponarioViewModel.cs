using GalaSoft.MvvmLight.Command;
using Marvelapp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class ANCosechaMeliponarioViewModel : INotifyPropertyChanged
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

        #region Atributos
        private int Elementos;
        private int lote;
        private string especie;
        private string alza;
        private int peso;
        int i;
        private ObservableCollection<Miel> miel;
        private Double heighList;
        private bool isRefreshing;
        private bool isEnabled;

        DateTime _Datepicker;
        string _Responsable;
        string _MariolaAlzas;
        string _SoncuanoAlzas;
        string _TotalAlzas;
        string _MariolaKg;
        string _SoncuanoKg;
        string _TotalKg;
        string _PrecioCompra;
        string _TotalPagar;
        string _Comentario;
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
        public ObservableCollection<Miel> Mieles
        {
            get
            {
                return miel;
            }
            set
            {
                if (miel != value)
                {
                    miel = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(Mieles)));
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

        public string Comentario
        {
            get { return _Comentario; }
            set
            {
                _Comentario = value;
                OnPropertyChanged("Comentario");
            }
        }
        public string TotalPagar
        {
            get { return _TotalPagar; }
            set
            {
                _TotalPagar = value;
                OnPropertyChanged("TotalPagar");
            }
        }
        public string PrecioCompra
        {
            get { return _PrecioCompra; }
            set
            {
                _PrecioCompra = value;
                OnPropertyChanged("PrecioCompra");
            }
        }
        public string TotalKg
        {
            get { return _TotalKg; }
            set
            {
                _TotalKg = value;
                OnPropertyChanged("TotalKg");
            }
        }
        public string SoncuanoKg
        {
            get { return _SoncuanoKg; }
            set
            {
                _SoncuanoKg = value;
                OnPropertyChanged("SoncuanoKg");
            }
        }
        public string MariolaKg
        {
            get { return _MariolaKg; }
            set
            {
                _MariolaKg = value;
                OnPropertyChanged("MariolaKg");
            }
        }
        public string TotalAlzas
        {
            get { return _TotalAlzas; }
            set
            {
                _TotalAlzas = value;
                OnPropertyChanged("TotalAlzas");
            }
        }
        public string SoncuanoAlzas
        {
            get { return _SoncuanoAlzas; }
            set
            {
                _SoncuanoAlzas = value;
                OnPropertyChanged("SoncuanoAlzas");
            }
        }
        public string MariolaAlzas
        {
            get { return _MariolaAlzas; }
            set
            {
                _MariolaAlzas = value;
                OnPropertyChanged("MariolaAlzas");
            }
        }
        public string Responsable
        {
            get { return _Responsable; }
            set
            {
                _Responsable = value;
                OnPropertyChanged("Responsable");
            }
        }
        public DateTime Datepicker
        {
            get { return _Datepicker; }
            set
            {
                _Datepicker = value;
                OnPropertyChanged("Datepicker");
            }
        }
        #endregion

        #region Constructors
        public ANCosechaMeliponarioViewModel()
        {
            instance = this;
            IsEnabled = true;
            Mieles = new ObservableCollection<Miel>();
            LoadMieles(); //carga el listado de Mieles
        }
        #endregion

        #region Commands
        public ICommand AgregarCanMielCommand
        {
            get
            {
                return new RelayCommand(AgregarCanMiel);
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
        async private void LoadMieles()
        {
            if (Application.Current.Properties.ContainsKey("ContadorMieles")) //contador de la cantidad de elementos en la lista
            {
                Elementos = int.Parse((Application.Current.Properties["ContadorMieles"]) as string);
            }
            else { Elementos = 0; }

            IsRefreshing = true;

            for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("Lote" + j))
                {
                    lote = int.Parse((Application.Current.Properties["Lote" + j]) as string);
                }
                else { lote = 0; }

                if (Application.Current.Properties.ContainsKey("Especie" + j))
                {
                    especie = (Application.Current.Properties["Especie" + j] as string);
                }
                else { especie = ""; }
                if (Application.Current.Properties.ContainsKey("Alza" + j))
                {
                    alza = (Application.Current.Properties["Alza" + j] as string);
                }
                else { alza = ""; }
                if (Application.Current.Properties.ContainsKey("Peso" + j))
                {
                    peso = int.Parse(Application.Current.Properties["Peso" + j] as string);
                }
                else { peso = 0; }

                Mieles.Add(new Miel() //agrega a mi lista todos los elementos existentes en persistencia
                {
                    Alza = alza,
                    Especie = especie,
                    Lote = lote,
                    Peso= peso,
                });
            }

            IsRefreshing = false;

            HeighListView = 44 * Mieles.Count; //cantidad de filas en mi lista, multiplicado por 44 que es el alto maximo de cada fila

        }
        async void Guardar()
        {
            IsEnabled = false;
            var fecha = Datepicker.ToString("dd/MM/yyyy");

            #region Miranda: Guardar Tabla

            #region Limpiar Cache //borrar los datos existentes en persistencia

            if (Application.Current.Properties.ContainsKey("ContadorMieles"))
            {
                Elementos= int.Parse((Application.Current.Properties["ContadorMieles"]) as string);
            }
            else { Elementos = 0; }
            for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("Lote" + j))
                {
                    Application.Current.Properties.Remove("Lote" + j);
                }
                if (Application.Current.Properties.ContainsKey("Especie" + j))
                {
                    Application.Current.Properties.Remove("Especie" + j);
                }
                if (Application.Current.Properties.ContainsKey("Alza" + j))
                {
                    Application.Current.Properties.Remove("Alza" + j);
                }
                if (Application.Current.Properties.ContainsKey("Peso"))
                {
                    Application.Current.Properties.Remove("Peso");
                }
            }

            #endregion

            #region Ciclo para Guardar en Persistencia
            i = 0; //inicio el contador de mis elementos o filas en (0)
            foreach (var miel in Mieles)
            {
                Application.Current.Properties["Lote" + i] = miel.Lote.ToString();
                Application.Current.Properties["Especie" + i] = miel.Especie.ToString();
                Application.Current.Properties["Alza" + i] = miel.Alza.ToString();
                Application.Current.Properties["Peso" + i] = miel.Peso.ToString();
                i++;
                Application.Current.Properties["ContadorMieles"] = i.ToString();
                await Application.Current.SavePropertiesAsync();
            }

            #endregion

            int filas;
            HeighListView = 44 * i;
            if (Application.Current.Properties.ContainsKey("ContadorMieles"))
            {
                filas = int.Parse(Application.Current.Properties["ContadorMieles"] as string);
            }
            else { filas = 0; }
            filas= Mieles.Count;
            await Application.Current.MainPage.DisplayAlert("Notificación", "El Numero de Lotes Guardados es: " + filas.ToString(), "Excelente");

            #endregion


            await Application.Current.MainPage.DisplayAlert(
                "Hola",
                fecha + " " + Responsable + " " + MariolaAlzas + " " + SoncuanoAlzas + " " + TotalAlzas + " " + MariolaKg + " " + SoncuanoKg + " " + TotalKg + " " + PrecioCompra + " " +
                TotalPagar + " " + Comentario,
                "Aceptar");
            IsEnabled = true;
        }
        async void AgregarCanMiel()
        {
            IsRefreshing = true;
            Mieles.Add(new Miel()
            {
                Alza = "",
                Especie = "",
                Lote = 0,
                Peso= 0,
            });
            HeighListView = HeighListView + 44;
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
        async void SaveTool()
        {
            var fecha = Datepicker.ToString("dd/MM/yyyy");

            await Application.Current.MainPage.DisplayAlert(
                "Hola",
                fecha + " " + Responsable + " " + MariolaAlzas + " " + SoncuanoAlzas + " " + TotalAlzas + " " + MariolaKg + " " + SoncuanoKg + " " + TotalKg + " " + PrecioCompra + " " +
                TotalPagar + " " + Comentario,
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
        private static ANCosechaMeliponarioViewModel instance;
        public static ANCosechaMeliponarioViewModel GetInstance()
        {
            if (instance == null)
            {
                return new ANCosechaMeliponarioViewModel();
            }
            return instance;
        }
        #endregion

    }
}
