    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Marvelapp.Models;
    using System;
using Marvelapp.Views;

namespace Marvelapp.ViewModels
{
    public class ComposicionHogarViewModel : INotifyPropertyChanged
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
           private string nombre;
           private string parentesco;
           private int edad;
           private string discapacidad;
           private string condicionlaboral;
           private string escolaridad;
           int i;
           private ObservableCollection<Miembro> miembro;
           private Double heighList;
           private bool isRefreshing;
           private bool isEnabled;
           string _nombre;

            bool _isToggledSexo;
            bool _isToggledDiscapacidad;
            bool _comoSeguroChecked;
            bool _allDayChecked;
            bool _cuarentaHorasChecked;
            bool _cotizaChecked;
            bool _derechosLaboralesChecked;
            string _edad;
            string _ocupacion;
            string _indiceSeguridad;
            string _indiceInsercionLaboral;
            string _indiceCiudadaniaSocial;
            string _especificar;
            string _indiceSocialPersona;
            string _relacionPersona;
            string _condicionLaboral;
            string _situacionAutoempleo;
            string _leerEscribir;
            string _nivelEscolar;
            string _proyectoComunitario;
            string _aseguramiento;
            string _indiceNivelEducativo;
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
            public ObservableCollection<Miembro> Miembros
        {
            get
            {
                return miembro;
            }
            set
            {
                if (miembro != value)
                {
                    miembro = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(Miembros)));
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
            public string IndiceNivelEducativo
            {
                get { return _indiceNivelEducativo; }
                set
                {
                    _indiceNivelEducativo = value;
                    OnPropertyChanged("IndiceNivelEducativo");
                }
            }
            public string Aseguramiento
            {
                get { return _aseguramiento; }
                set
                {
                    _aseguramiento = value;
                    OnPropertyChanged("Aseguramiento");
                }
            }
            public string ProyectoComunitario
            {
                get { return _proyectoComunitario; }
                set
                {
                    _proyectoComunitario = value;
                    OnPropertyChanged("ProyectoComunitario");
                }
            }
            public string NivelEscolar
            {
                get { return _nivelEscolar; }
                set
                {
                    _nivelEscolar = value;
                    OnPropertyChanged("NivelEscolar");
                }
            }
            public string LeerEscribir
            {
                get { return _leerEscribir; }
                set
                {
                    _leerEscribir = value;
                    OnPropertyChanged("LeerEscribir");
                }
            }
            public string SituacionAutoempleo
            {
                get { return _situacionAutoempleo; }
                set
                {
                    _situacionAutoempleo = value;
                    OnPropertyChanged("SituacionAutoempleo");
                }
            }
            public string CondicionLaboral
            {
                get { return _condicionLaboral; }
                set
                {
                    _condicionLaboral = value;
                    OnPropertyChanged("CondicionLaboral");
                }
            }
            public string RelacionPersona
            {
                get { return _relacionPersona; }
                set
                {
                    _relacionPersona = value;
                    OnPropertyChanged("RelacionPersona");
                }
            }
            public string Nombre
            {
                get { return _nombre; }
                set
                {
                    _nombre = value;
                    OnPropertyChanged("Nombre");
                }
            }
            public bool IsToggledSexo
            {
                get { return _isToggledSexo; }
                set
                {
                    _isToggledSexo = value;
                    OnPropertyChanged("IsToggledSexo");
                }
            }
            public bool IsToggledDiscapacidad
            {
                get { return _isToggledDiscapacidad; }
                set
                {
                    _isToggledDiscapacidad = value;
                    OnPropertyChanged("IsToggledDiscapacidad");
                }
            }
            public bool ComoSeguroChecked
            {
                get { return _comoSeguroChecked; }
                set
                {
                    _comoSeguroChecked = value;
                    OnPropertyChanged("ComoSeguroChecked");
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
            public string Ocupacion
            {
                get { return _ocupacion; }
                set
                {
                    _ocupacion = value;
                    OnPropertyChanged("Ocupacion");
                }
            }
            public string IndiceSeguridad
            {
                get { return _indiceSeguridad; }
                set
                {
                    _indiceSeguridad = value;
                    OnPropertyChanged("IndiceSeguridad");
                }
            }
            public string IndiceInsercionLaboral
            {
                get { return _indiceInsercionLaboral; }
                set
                {
                    _indiceInsercionLaboral = value;
                    OnPropertyChanged("IndiceInsercionLaboral");
                }
            }
            public string IndiceCiudadaniaSocial
            {
                get { return _indiceCiudadaniaSocial; }
                set
                {
                    _indiceCiudadaniaSocial = value;
                    OnPropertyChanged("IndiceCiudadaniaSocial");
                }
            }
            public string Especificar
            {
                get { return _especificar; }
                set
                {
                    _especificar = value;
                    OnPropertyChanged("Especificar");
                }
            }
            public string IndiceSocialPersona
            {
                get { return _indiceSocialPersona; }
                set
                {
                    _indiceSocialPersona = value;
                    OnPropertyChanged("IndiceSocialPersona");
                }
            }
            public bool AllDayChecked
            {
                get { return _allDayChecked; }
                set
                {
                    _allDayChecked = value;
                    OnPropertyChanged("AllDayChecked");
                }
            }
            public bool CuarentaHorasChecked
            {
                get { return _cuarentaHorasChecked; }
                set
                {
                    _cuarentaHorasChecked = value;
                    OnPropertyChanged("CuarentaHorasChecked");
                }
            }
            public bool CotizaChecked
            {
                get { return _cotizaChecked; }
                set
                {
                    _cotizaChecked = value;
                    OnPropertyChanged("CotizaChecked");
                }
            }
            public bool DerechosLaboralesChecked
            {
                get { return _derechosLaboralesChecked; }
                set
                {
                    _derechosLaboralesChecked = value;
                    OnPropertyChanged("DerechosLaboralesChecked");
                }
            }
        #endregion

        #region Constructors
        public ComposicionHogarViewModel()
        {
            instance = this;
            IsEnabled = true;
            Miembros = new ObservableCollection<Miembro>();
            LoadMiembros(); //carga el listado de miembros
        }
        #endregion

        #region Commands
        public ICommand BackCommand
            {
                get
                {
                    return new RelayCommand(Back);
                }
            }

            public ICommand NextCommand
            {
                get
                {
                    return new RelayCommand(Next);
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
            async void LoadMiembros()
        {
            if (Application.Current.Properties.ContainsKey("ContadorMiembros")) //contador de la cantidad de elementos en la lista
            {
                Elementos = int.Parse((Application.Current.Properties["ContadorMiembros"]) as string);
            }
            else { Elementos = 0; }

            IsRefreshing = true;

            for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("NombreMiembro" + j))
                {
                    nombre = (Application.Current.Properties["NombreMiembro" + j]) as string;
                }
                else { nombre = ""; }

                if (Application.Current.Properties.ContainsKey("Parentesco" + j))
                {
                    parentesco = (Application.Current.Properties["Parentesco" + j] as string);
                }
                else { parentesco = ""; }
                if (Application.Current.Properties.ContainsKey("EdadMiembro" + j))
                {
                    edad = int.Parse(Application.Current.Properties["EdadMiembro" + j] as string);
                }
                else { edad = 0; }
                if (Application.Current.Properties.ContainsKey("Discapacidad" + j))
                {
                    discapacidad = (Application.Current.Properties["Discapacidad" + j] as string);
                }
                else { discapacidad = ""; }
                if (Application.Current.Properties.ContainsKey("CondicionLaboral" + j))
                {
                    condicionlaboral = (Application.Current.Properties["CondicionLaboral" + j] as string);
                }
                else { condicionlaboral = ""; }
                if (Application.Current.Properties.ContainsKey("Escolaridad" + j))
                {
                    escolaridad = (Application.Current.Properties["Escolaridad" + j] as string);
                }
                else { escolaridad = ""; }



                Miembros.Add(new Miembro() //agrega a mi lista todos los elementos existentes en persistencia
                {
                    CondicionLaboral = condicionlaboral,
                    DiscapacidadMiembro= discapacidad,
                    EdadMiembro= edad,
                    Escolaridad= escolaridad,
                    NombreMiembro= nombre,
                    ParentescoMiembro= parentesco,
                
                });
            }

            IsRefreshing = false;

            HeighListView = 44 * Miembros.Count; //cantidad de filas en mi lista, multiplicado por 44 que es el alto maximo de cada fila
        }
            async void Guardar()
            {
            #region Eleazar
            /*
            var ssasasa = NivelEscolar;
            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(LeerEscribir) || string.IsNullOrEmpty(RelacionPersona) ||
                string.IsNullOrEmpty(Edad) || string.IsNullOrEmpty(Ocupacion) || string.IsNullOrEmpty(CondicionLaboral) ||
                string.IsNullOrEmpty(IndiceSeguridad) || string.IsNullOrEmpty(SituacionAutoempleo) || string.IsNullOrEmpty(IndiceInsercionLaboral) ||
                string.IsNullOrEmpty(IndiceNivelEducativo) || string.IsNullOrEmpty(NivelEscolar) || string.IsNullOrEmpty(Aseguramiento) ||
                string.IsNullOrEmpty(IndiceCiudadaniaSocial) || string.IsNullOrEmpty(ProyectoComunitario) || string.IsNullOrEmpty(Especificar) ||
                string.IsNullOrEmpty(IndiceSocialPersona))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Llene los campos obligatorios",
                    "aceptar");
                return;
            }

            if (AllDayChecked == false && CotizaChecked == false && DerechosLaboralesChecked == false && ComoSeguroChecked == false)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Llene los campos obligatorios", "aceptar");
                return;
            }

            await Application.Current.MainPage.DisplayAlert(
                "Hola",
                this.Nombre + " " + this.Edad + " " + this.IndiceCiudadaniaSocial + " " + this.IndiceInsercionLaboral + " "
                + this.IndiceSeguridad + " " + this.IndiceSocialPersona + " " + this.IsToggledDiscapacidad.ToString() + " "
                + this.IsToggledSexo.ToString() + " " + this.ComoSeguroChecked.ToString() + " " +
                this.AllDayChecked.ToString() + " " + this.CotizaChecked.ToString() + " " + this.CuarentaHorasChecked.ToString()
                + " " + this._derechosLaboralesChecked.ToString() + " " + RelacionPersona + " " + CondicionLaboral + " " +
                SituacionAutoempleo + " " + LeerEscribir + " " + NivelEscolar + " " + ProyectoComunitario,
                "Aceptar");
                */
            #endregion

            #region Miranda: Guardar Tabla

            #region Ciclo para Guardar en Persistencia
            if (Application.Current.Properties.ContainsKey("ContadorMiembros"))//verifico cuantos elementos tiene mi lista para saber cual es la psocion del nuevo elemento a agregar
            {
                Elementos = (int.Parse((Application.Current.Properties["ContadorMiembros"]) as string));
            }
            else { Elementos = 0; }

            if (IsToggledDiscapacidad)
            {
                discapacidad = "No";
            }
            else
            {
                discapacidad = "Si";
            }
            
                Application.Current.Properties["NombreMiembro" + Elementos] =Nombre.ToString();
                Application.Current.Properties["Parentesco" + Elementos] =  RelacionPersona.ToString();
                Application.Current.Properties["EdadMiembro" + Elementos] = Edad.ToString();
                Application.Current.Properties["Discapacidad" + Elementos] = discapacidad.ToString();
                Application.Current.Properties["CondicionLaboral" + Elementos] = CondicionLaboral.ToString();
                Application.Current.Properties["Escolaridad" + Elementos] = NivelEscolar.ToString();
                Application.Current.Properties["ContadorMiembros"] = (Elementos + 1).ToString();
                await Application.Current.SavePropertiesAsync();
            #endregion


            int filas;
            filas = Elementos + 1;
            HeighListView = 44 * filas;//actalizo mi heigh
            await Application.Current.MainPage.DisplayAlert("Notificación", "Usted Tiene hasta Ahora: " + filas + " Parientes Registrados", "Excelente");
            IsEnabled = true;
            Miembros.Add(new Miembro()
            {
                CondicionLaboral= CondicionLaboral.ToString(),
                DiscapacidadMiembro= discapacidad.ToString(),
                EdadMiembro= int.Parse(Edad.ToString()),
                Escolaridad= NivelEscolar.ToString(),
                NombreMiembro= Nombre.ToString(),
                ParentescoMiembro= RelacionPersona.ToString(),
            });
            BienestarSocialViewModel.GetInstance().MiembrosBienestar = this.Miembros; //asigno los datos de mi lista 
            BienestarSocialViewModel.GetInstance().HeighListViewB = this.HeighListView; //actualizo el heigh de mi vista anterior

            await Application.Current.MainPage.Navigation.PopAsync();

            #endregion

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
                    "Edit Tool",
                    "Aceptar");
            }
            async void BackTool()
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            async void Back()
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Hola",
                   "Back",
                   "Aceptar");
            }
            async void Next()
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Hola",
                    "Next",
                    "Aceptar");
            }
            async void Volver()
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        #endregion

        #region Singleton 
        private static ComposicionHogarViewModel instance;
        public static ComposicionHogarViewModel GetInstance()
        {
            if (instance == null)
            {
                return new ComposicionHogarViewModel();
            }
            return instance;
        }
        #endregion


        }
}

