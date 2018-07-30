    using GalaSoft.MvvmLight.Command;
using Marvelapp.Models;
using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    namespace Marvelapp.ViewModels
{
        public class DatosDiagnosticoViewModel : INotifyPropertyChanged
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
            private string detalle;
            int i;
            private ObservableCollection<Documento> documento;
            private Double heighList;
            private bool isRefreshing;
            private bool isEnabled;
            DateTime _dateSelected;
            bool _visitaCasa;
            string _tipoDocumentoDetalle;
            string _tipoDocumentoDos;
            string _diagnostico;
            string _encuestador;
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
            public ObservableCollection<Documento> Documentos
        {
            get
            {
                return documento;
            }
            set
            {
                if (documento != value)
                {
                    documento = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(Documentos)));
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
            public string Encuestador
            {
                get { return _encuestador; }
                set
                {
                    _encuestador = value;
                    OnPropertyChanged("Encuestador");
                }
            }
            public string Diagnostico
            {
                get { return _diagnostico; }
                set
                {
                    _diagnostico = value;
                    OnPropertyChanged("Diagnostico");
                }
            }
            public string TipoDocumentoDos
            {
                get { return _tipoDocumentoDos; }
                set
                {
                    _tipoDocumentoDos = value;
                    OnPropertyChanged("TipoDocumentoDos");
                }
            }
            public string TipoDocumentoDetalle
            {
                get { return _tipoDocumentoDetalle; }
                set
                {
                    _tipoDocumentoDetalle = value;
                    OnPropertyChanged("TipoDocumentoDetalle");
                }
            }
            public bool VisitaCasa
            {
                get { return _visitaCasa; }
                set
                {
                    _visitaCasa = value;
                    OnPropertyChanged("VisitaCasa");
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
            #endregion
            
            #region Constructors
            public DatosDiagnosticoViewModel()
            {
                IsEnabled = true;
                this.DateSelected = DateTime.Now;
                instance = this;
                Documentos = new ObservableCollection<Documento>();
                LoadDocumentos(); //carga el listado de documentos
            }
            #endregion

            #region Commands
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
            public ICommand AgregarDocumentoCommand
            {
                get
                {
                    return new RelayCommand(AgregarDocumento);
                }
            }
            #endregion

            #region Methods
            async void LoadDocumentos()
            {
            if (Application.Current.Properties.ContainsKey("ContadorDocumentos")) //contador de la cantidad de elementos en la lista
            {
                Elementos = int.Parse((Application.Current.Properties["ContadorDocumentos"]) as string);
            }
            else { Elementos = 0; }

            IsRefreshing = true;

            for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("TipoDocumento" + j))
                {
                    tipo = (Application.Current.Properties["TipoDocumento" + j]) as string;
                }
                else { tipo = ""; }

                if (Application.Current.Properties.ContainsKey("DetalleDocumento" + j))
                {
                    detalle = (Application.Current.Properties["DetalleDocumento" + j] as string);
                }
                else { detalle = ""; }

                Documentos.Add(new Documento() //agrega a mi lista todos los elementos existentes en persistencia
                {
                    DetalleDocumento = detalle,
                    TipoDocumento = tipo,
                });
            }

            IsRefreshing = false;

            HeighListView = 44 * Documentos.Count; //cantidad de filas en mi lista, multiplicado por 44 que es el alto maximo de cada fila
        }
            async void Guardar()
            {
            IsEnabled = false;
            #region Eleazar
            /*
            var today = DateTime.Now.ToString("dd/MM/yyyy");
            var fecha = DateSelected.ToString("dd/MM/yyyy");
            if (string.IsNullOrEmpty(Encuestador) || string.IsNullOrEmpty(fecha) || string.IsNullOrEmpty(Diagnostico))
            {
                await Application.Current.MainPage.DisplayAlert(
                "Error",
                "Llene los campos obligatorios",
                "Aceptar");
                 IsEnabled = true;
                 return;
            }
            */
            #endregion

            #region Miranda: Guardar Tabla

            #region Limpiar Cache //borrar los datos existentes en persistencia

            if (Application.Current.Properties.ContainsKey("ContadorDocumentos"))
            {
                Elementos = int.Parse((Application.Current.Properties["ContadorDocumentos"]) as string);
            }
            else { Elementos = 0; }
            for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("TipoDocumento" + j))
                {
                    Application.Current.Properties.Remove("TipoDocumento" + j);
                }
                if (Application.Current.Properties.ContainsKey("DetalleDocumento" + j))
                {
                    Application.Current.Properties.Remove("DetalleDocumento" + j);
                }
                if (Application.Current.Properties.ContainsKey("ContadorDocumentos"))
                {
                    Application.Current.Properties.Remove("ContadorDocumentos");
                }
            }

            #endregion

            #region Ciclo para Guardar en Persistencia
            i = 0; //inicio el contador de mis elementos o filas en (0)
            foreach (var document in Documentos)
            {
                Application.Current.Properties["TipoDocumento" + i] = document.TipoDocumento.ToString();
                Application.Current.Properties["DetalleDocumento" + i] = document.DetalleDocumento.ToString();
                i++;
                Application.Current.Properties["ContadorDocumentos"] = i.ToString();
                await Application.Current.SavePropertiesAsync();
            }

            #endregion

            int filas;
            HeighListView = 44 * i;
            if (Application.Current.Properties.ContainsKey("ContadorDocumentos"))
            {
                filas = int.Parse(Application.Current.Properties["ContadorDocumentos"] as string);
            }
            else { filas = 0; }
            await Application.Current.MainPage.DisplayAlert("Notificación", "El Numero de Filas Guardadas es: " + filas.ToString(), "Excelente");
            IsEnabled = true;

            #endregion

            /*
            await Application.Current.MainPage.DisplayAlert(
                    "Hola",
                    " " + this.VisitaCasa + " " + this.TipoDocumentoDetalle + " " + this.TipoDocumentoDos + " " + Diagnostico + " " + Encuestador,
                    "Aceptar");
            */
            }
            void AgregarDocumento()
            {

            IsRefreshing = true;
            Documentos.Add(new Documento()
            {
               DetalleDocumento="",
               TipoDocumento="",
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
            private static DatosDiagnosticoViewModel instance;
            public static DatosDiagnosticoViewModel GetInstance()
            {
                if (instance == null)
                {
                    return new DatosDiagnosticoViewModel();
                }
                return instance;
            }
            #endregion

        }
    }





