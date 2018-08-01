    using System;
    using System.Collections.Generic;
    using System.Text;
    using Marvelapp.Views;
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;
    using System.Collections.ObjectModel;
    using Marvelapp.Models;

namespace Marvelapp.ViewModels
    {
        public class BienestarSocialViewModel : INotifyPropertyChanged
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
            private ObservableCollection<Miembro> miembrobienestar;
            string _personasHogar;
            string _personasActivas;
            string _personasDependientes;
            string _insercionLaboral;
            string _nivelEducativo;
            string _ciudadaniaSocial;
            string _insercionProductiva;
            string _inclusionSocial;
            string _indInsercionLaboral;
            string _IndnivelEducativo;
            string _IndciudadaniaSocial;
            string _IndinsercionProductiva;
            string _actividadEconomica;
            string _indinclusionSocial;
            string _facilidadAcceso;
            string _facilidadAccesoCercana;
            string _indiceFA;
            string _tiempoCentroSalud;
            string _tiempoCentroEducativo;
            string _cercaniaServBasicos;
            string _transportePublico;
            string _transportePropio;
            string _especificarMT;
            string _capacidadDesplazamiento;
            string _conProximidadGeo;
            string _estructuraGeneracional;
            bool _familiaresComunidad;
            string _apoyoFamilia;
            string _cercaniaFamiliar;
            string _apoyoVecinos;
            string _ambienteComunidad;
            bool _parteComunidad;
            bool _miembroGrupoComunidad;
            string _especifiqueMC;
            string _indCercaniaFamiliar;
            string _tRelacionesSociales;
            string _tBienestarSocial;
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
            public ObservableCollection<Miembro> MiembrosBienestar
        {
            get
            {
                return miembrobienestar;
            }
            set
            {
                if (miembrobienestar != value)
                {
                    miembrobienestar = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(MiembrosBienestar)));
                }
            }
        }
            public string TBienestarSocial
            {
                get { return _tBienestarSocial; }
                set
                {
                    _tBienestarSocial = value;
                    OnPropertyChanged("TBienestarSocial");
                }
            }
            public string TRelacionesSociales
            {
                get { return _tRelacionesSociales; }
                set
                {
                    _tRelacionesSociales = value;
                    OnPropertyChanged("TRelacionesSociales");
                }
            }
            public string IndCercaniaFamiliar
            {
                get { return _indCercaniaFamiliar; }
                set
                {
                    _indCercaniaFamiliar = value;
                    OnPropertyChanged("IndCercaniaFamiliar");
                }
            }
            public string EspecifiqueMC
            {
                get { return _especifiqueMC; }
                set
                {
                    _especifiqueMC = value;
                    OnPropertyChanged("EspecifiqueMC");
                }
            }
            public bool MiembroGrupoComunidad
            {
                get { return _miembroGrupoComunidad; }
                set
                {
                    _miembroGrupoComunidad = value;
                    OnPropertyChanged("MiembroGrupoComunidad");
                }
            }
            public bool ParteComunidad
            {
                get { return _parteComunidad; }
                set
                {
                    _parteComunidad = value;
                    OnPropertyChanged("ParteComunidad");
                }
            }
            public string AmbienteComunidad
            {
                get { return _ambienteComunidad; }
                set
                {
                    _ambienteComunidad = value;
                    OnPropertyChanged("AmbienteComunidad");
                }
            }
            public string ApoyoVecinos
            {
                get { return _apoyoVecinos; }
                set
                {
                    _apoyoVecinos = value;
                    OnPropertyChanged("ApoyoVecinos");
                }
            }
            public string CercaniaFamiliar
            {
                get { return _cercaniaFamiliar; }
                set
                {
                    _cercaniaFamiliar = value;
                    OnPropertyChanged("CercaniaFamiliar");
                }
            }
            public string ApoyoFamilia
            {
                get { return _apoyoFamilia; }
                set
                {
                    _apoyoFamilia = value;
                    OnPropertyChanged("ApoyoFamilia");
                }
            }
            public bool FamiliaresComunidad
            {
                get { return _familiaresComunidad; }
                set
                {
                    _familiaresComunidad = value;
                    OnPropertyChanged("FamiliaresComunidad");
                }
            }
            public string EstructuraGeneracional
            {
                get { return _estructuraGeneracional; }
                set
                {
                    _estructuraGeneracional = value;
                    OnPropertyChanged("EstructuraGeneracional");
                }
            }
            public string ConProximidadGeo
            {
                get { return _conProximidadGeo; }
                set
                {
                    _conProximidadGeo = value;
                    OnPropertyChanged("ConProximidadGeo");
                }
            }
            public string CapacidadDesplazamiento
            {
                get { return _capacidadDesplazamiento; }
                set
                {
                    _capacidadDesplazamiento = value;
                    OnPropertyChanged("CapacidadDesplazamiento");
                }
            }
            public string EspecificarMT
            {
                get { return _especificarMT; }
                set
                {
                    _especificarMT = value;
                    OnPropertyChanged("EspecificarMT");
                }
            }
            public string TransportePropio
            {
                get { return _transportePropio; }
                set
                {
                    _transportePropio = value;
                    OnPropertyChanged("TransportePropio");
                }
            }
            public string TransportePublico
            {
                get { return _transportePublico; }
                set
                {
                    _transportePublico = value;
                    OnPropertyChanged("TransportePublico");
                }
            }
            public string CercaniaServBasicos
            {
                get { return _cercaniaServBasicos; }
                set
                {
                    _cercaniaServBasicos = value;
                    OnPropertyChanged("CercaniaServBasicos");
                }
            }
            public string TiempoCentroEducativo
            {
                get { return _tiempoCentroEducativo; }
                set
                {
                    _tiempoCentroEducativo = value;
                    OnPropertyChanged("TiempoCentroEducativo");
                }
            }
            public string TiempoCentroSalud
            {
                get { return _tiempoCentroSalud; }
                set
                {
                    _tiempoCentroSalud = value;
                    OnPropertyChanged("TiempoCentroSalud");
                }
            }
            public string IndiceFA
            {
                get { return _indiceFA; }
                set
                {
                    _indiceFA = value;
                    OnPropertyChanged("IndiceFA");
                }
            }
            public string FacilidadAccesoCercana
            {
                get { return _facilidadAccesoCercana; }
                set
                {
                    _facilidadAccesoCercana = value;
                    OnPropertyChanged("FacilidadAccesoCercana");
                }
            }
            public string FacilidadAcceso
            {
                get { return _facilidadAcceso; }
                set
                {
                    _facilidadAcceso = value;
                    OnPropertyChanged("FacilidadAcceso");
                }
            }
            public string IndInclusionSocial
            {
                get { return _indinclusionSocial; }
                set
                {
                    _indinclusionSocial = value;
                    OnPropertyChanged("IndInclusionSocial");
                }
            }
            public string ActividadEconomica
            {
                get { return _actividadEconomica; }
                set
                {
                    _actividadEconomica = value;
                    OnPropertyChanged("ActividadEconomica");
                }
            }
            public string IndInsercionProductiva
            {
                get { return _IndinsercionProductiva; }
                set
                {
                    _IndinsercionProductiva = value;
                    OnPropertyChanged("IndInsercionProductiva");
                }
            }
            public string IndCiudadaniaSocial
            {
                get { return _IndciudadaniaSocial; }
                set
                {
                    _IndciudadaniaSocial = value;
                    OnPropertyChanged("IndCiudadaniaSocial");
                }
            }
            public string IndNivelEducativo
            {
                get { return _IndnivelEducativo; }
                set
                {
                    _IndnivelEducativo = value;
                    OnPropertyChanged("IndNivelEducativo");
                }
            }
            public string IndInsercionLaboral
            {
                get { return _indInsercionLaboral; }
                set
                {
                    _indInsercionLaboral = value;
                    OnPropertyChanged("IndInsercionLaboral");
                }
            }
            public string InclusionSocial
            {
                get { return _inclusionSocial; }
                set
                {
                    _inclusionSocial = value;
                    OnPropertyChanged("InclusionSocial");
                }
            }
            public string InsercionProductiva
            {
                get { return _insercionProductiva; }
                set
                {
                    _insercionProductiva = value;
                    OnPropertyChanged("InsercionProductiva");
                }
            }
            public string CiudadaniaSocial
            {
                get { return _ciudadaniaSocial; }
                set
                {
                    _ciudadaniaSocial = value;
                    OnPropertyChanged("CiudadaniaSocial");
                }
            }
            public string NivelEducativo
            {
                get { return _nivelEducativo; }
                set
                {
                    _nivelEducativo = value;
                    OnPropertyChanged("NivelEducativo");
                }
            }
            public string InsercionLaboral
            {
                get { return _insercionLaboral; }
                set
                {
                    _insercionLaboral = value;
                    OnPropertyChanged("InsercionLaboral");
                }
            }
            public string PersonasDependientes
            {
                get { return _personasDependientes; }
                set
                {
                    _personasDependientes = value;
                    OnPropertyChanged("PersonasDependientes");
                }
            }
            public string PersonasActivas
            {
                get { return _personasActivas; }
                set
                {
                    _personasActivas = value;
                    OnPropertyChanged("PersonasActivas");
                }
            }
            public string PersonasHogar
            {
                get { return _personasHogar; }
                set
                {
                    _personasHogar = value;
                    OnPropertyChanged("PersonasHogar");
                }
            }
        #endregion

        #region Constructors
        public BienestarSocialViewModel()
        {
            IsEnabled = true;
            instance = this;
            MiembrosBienestar = ComposicionHogarViewModel.GetInstance().Miembros; //obtengo los datos de mi lista en la otra ComposicionHogarViewModel
            HeighListViewB = ComposicionHogarViewModel.GetInstance().HeighListView; //obtengo el heigh de ComposicionHogarViewModel
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
            public ICommand AddMemberCommand
            {
                get
                {
                    return new RelayCommand(AddMember);
                }
            }
        #endregion

        #region Methods
            async void Guardar()
            {
            IsEnabled = false;
            #region Eleazar
            /*
              if (string.IsNullOrEmpty(PersonasHogar) || string.IsNullOrEmpty(PersonasActivas) || string.IsNullOrEmpty(PersonasDependientes) ||
                    string.IsNullOrEmpty(InsercionLaboral) || string.IsNullOrEmpty(NivelEducativo) || string.IsNullOrEmpty(CiudadaniaSocial) ||
                    string.IsNullOrEmpty(InsercionProductiva) || string.IsNullOrEmpty(InclusionSocial) || string.IsNullOrEmpty(IndInsercionLaboral) ||
                    string.IsNullOrEmpty(IndNivelEducativo) || string.IsNullOrEmpty(IndCiudadaniaSocial) || string.IsNullOrEmpty(IndInsercionProductiva) ||
                    string.IsNullOrEmpty(InclusionSocial) || string.IsNullOrEmpty(IndInsercionLaboral) || string.IsNullOrEmpty(IndNivelEducativo) ||
                    string.IsNullOrEmpty(IndCiudadaniaSocial) || string.IsNullOrEmpty(IndInsercionProductiva) || string.IsNullOrEmpty(ActividadEconomica) ||
                    string.IsNullOrEmpty(IndInclusionSocial) || string.IsNullOrEmpty(FacilidadAcceso) || string.IsNullOrEmpty(FacilidadAccesoCercana) ||
                    string.IsNullOrEmpty(IndiceFA) || string.IsNullOrEmpty(TiempoCentroSalud) || string.IsNullOrEmpty(TiempoCentroEducativo) ||
                    string.IsNullOrEmpty(CercaniaServBasicos) || string.IsNullOrEmpty(TransportePublico) || string.IsNullOrEmpty(TransportePropio) ||
                    string.IsNullOrEmpty(CapacidadDesplazamiento) || string.IsNullOrEmpty(ConProximidadGeo) ||
                    string.IsNullOrEmpty(EstructuraGeneracional) || string.IsNullOrEmpty(ApoyoFamilia) || string.IsNullOrEmpty(CercaniaFamiliar) ||
                    string.IsNullOrEmpty(ApoyoVecinos) || string.IsNullOrEmpty(AmbienteComunidad) || string.IsNullOrEmpty(IndCercaniaFamiliar) ||
                    string.IsNullOrEmpty(TRelacionesSociales) || string.IsNullOrEmpty(TBienestarSocial))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Llene los campos obligatorios", "aceptar");
                    IsEnabled = true;
                    return;
                }

                await Application.Current.MainPage.DisplayAlert(
                    "Hola",
                    this.PersonasHogar + " " + PersonasDependientes + " " + PersonasActivas + " " + InsercionLaboral + " " + NivelEducativo + " " +
                    CiudadaniaSocial + " " + InsercionProductiva + " " + InclusionSocial + " " + IndInsercionLaboral + " " + IndNivelEducativo + " " +
                    IndCiudadaniaSocial + " " + IndInsercionProductiva + " " + ActividadEconomica + " " + IndInclusionSocial + " " + FacilidadAcceso + " " +
                    FacilidadAccesoCercana + " " + IndiceFA + " " + TiempoCentroSalud + " " + TiempoCentroEducativo + " " + CercaniaServBasicos + " " +
                    TransportePublico + " " + TransportePropio + " " + EspecificarMT + " " + CapacidadDesplazamiento + " " + ConProximidadGeo + " " +
                    EstructuraGeneracional + " " + FamiliaresComunidad + " " + ApoyoFamilia + " " + ApoyoVecinos + " " + CercaniaFamiliar + " " +
                    AmbienteComunidad + " " + ParteComunidad + " " + EspecifiqueMC + " " + IndCercaniaFamiliar + " " + TRelacionesSociales + " " +
                    TBienestarSocial,
                    "Aceptar");
             */
            #endregion

            #region Limpiar Cache //borrar los datos existentes en persistencia

            if (Application.Current.Properties.ContainsKey("ContadorMiembros"))
            {
                Elementos = int.Parse((Application.Current.Properties["ContadorMiembros"]) as string);
            }
            else { Elementos = 0; }
            for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("NombreMiembro" + j))
                {
                    Application.Current.Properties.Remove("NombreMiembro" + j);
                }
                if (Application.Current.Properties.ContainsKey("Parentesco" + j))
                {
                    Application.Current.Properties.Remove("Parentesco" + j);
                }
                if (Application.Current.Properties.ContainsKey("EdadMiembro"))
                {
                    Application.Current.Properties.Remove("EdadMiembro");
                }
                if (Application.Current.Properties.ContainsKey("Discapacidad"))
                {
                    Application.Current.Properties.Remove("Discapacidad");
                }
                if (Application.Current.Properties.ContainsKey("CondicionLaboral"))
                {
                    Application.Current.Properties.Remove("CondicionLaboral");
                }
                if (Application.Current.Properties.ContainsKey("Escolaridad"))
                {
                    Application.Current.Properties.Remove("Escolaridad");
                }
            }

            #endregion

            #region Ciclo para Guardar en Persistencia mi lista Actual
            i = 0; //inicio el contador de mis elementos o filas en (0)
            foreach (var miembr in MiembrosBienestar)
            {
                Application.Current.Properties["NombreMiembro" + i] = miembr.NombreMiembro.ToString();
                Application.Current.Properties["Parentesco" + i] = miembr.ParentescoMiembro.ToString();
                Application.Current.Properties["EdadMiembro" + i] = miembr.EdadMiembro.ToString();
                Application.Current.Properties["Discapacidad" + i] = miembr.DiscapacidadMiembro.ToString();
                Application.Current.Properties["CondicionLaboral" + i] = miembr.CondicionLaboral.ToString();
                Application.Current.Properties["Escolaridad" + i] = miembr.Escolaridad.ToString();
                i++;
                Application.Current.Properties["ContadorMiembros"] = i.ToString();
                await Application.Current.SavePropertiesAsync();
            }

            #endregion

            int filas;
            filas = MiembrosBienestar.Count;
            Application.Current.Properties["ContadorMiembros"] = filas.ToString(); //hay que examinar esta linea, es de prueba porque creo que no se actualiza bien el contador en la otra viewmodel cuando se borran todos los registros y esta linea evita eso
            HeighListViewB = 44 * filas;//actalizo mi heigh
            ComposicionHogarViewModel.GetInstance().Miembros = this.MiembrosBienestar; //asigno los datos de mi lista 
            await Application.Current.MainPage.DisplayAlert("Notificación", "Usted Tiene hasta Ahora: " + filas + " Parientes Registrados", "Excelente");
            IsEnabled = true;

        }
        async void AddMember()
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ComposicionHogarPage());
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
        private static BienestarSocialViewModel instance;
        public static BienestarSocialViewModel GetInstance()
        {
            if (instance == null)
            {
                return new BienestarSocialViewModel();
            }
            return instance;
        }
        #endregion

    }
}
