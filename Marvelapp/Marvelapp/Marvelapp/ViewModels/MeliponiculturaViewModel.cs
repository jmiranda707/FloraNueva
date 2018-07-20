using GalaSoft.MvvmLight.Command;
using Marvelapp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class MeliponiculturaViewModel :BaseViewModel
    {

        #region Properties
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                SetValue(ref isEnabled, value);
            }
        }
        public bool ProduceMiel
        {
            get
            {
                return produceMiel;
            }
            set
            {
                SetValue(ref produceMiel, value);
            }
        }
        public bool AbejasSinAguijon
        {
            get
            {
                return abejasSinAguijon;
            }
            set
            {
                SetValue(ref abejasSinAguijon, value);
            }
        }
        public int DesdeCuando
        {
            get
            {
                return desdeCuando;
            }
            set
            {
                SetValue(ref desdeCuando, value);
            }
        }

        public string OtrasEspecies
        {
            get
            {
                return otrasEspecies;
            }
            set
            {
                SetValue(ref otrasEspecies, value);
            }
        }

        public string ComoObtuvoColmena
        {
            get
            {
                return comoObtuvoColmena;
            }
            set
            {
                SetValue(ref comoObtuvoColmena, value);
            }
        }
        public string ComoCosecha
        {
            get
            {
                return comoCosecha;
            }
            set
            {
                SetValue(ref comoCosecha, value);
            }
        }
        public string SelectedOption
        {
            get
            {
                return selectedOption;
            }
            set
            {
                SetValue(ref selectedOption, value);
            }
        }
        public string DondeSeVende
        {
            get
            {
                return dondeSeVende;
            }
            set
            {
                SetValue(ref dondeSeVende, value);
            }
        }
        public int PrecioVenta
        {
            get
            {
                return precioVenta;
            }
            set
            {
                SetValue(ref precioVenta, value);
            }
        }
        public string DondeColocaColmena
        {
            get
            {
                return dondeColocaColmena;
            }
            set
            {
                SetValue(ref dondeColocaColmena, value);
            }
        }
        public string DondeUbicanColmenas
        {
            get
            {
                return dondeUbicanColmenas;
            }
            set
            {
                SetValue(ref dondeUbicanColmenas, value);
            }
        }
        public string DiagnosticoMeliponario
        {
            get
            {
                return diagnosticoMeliponario;
            }
            set
            {
                SetValue(ref diagnosticoMeliponario, value);
            }
        }
        public string PotencialLugarTenerAbejas
        {
            get
            {
                return potencialLugarTenerAbejas;
            }
            set
            {
                SetValue(ref potencialLugarTenerAbejas, value);
            }
        }
        public string RiesgoRobo
        {
            get
            {
                return riesgoRobo;
            }
            set
            {
                SetValue(ref riesgoRobo, value);
            }
        }
        public string MotivacionTenerla
        {
            get
            {
                return motivacionTenerla;
            }
            set
            {
                SetValue(ref motivacionTenerla, value);
            }
        }
        public string ComoAprendioCriarlas
        {
            get
            {
                return comoAprendioCriarlas;
            }
            set
            {
                SetValue(ref comoAprendioCriarlas, value);
            }
        }
        public string NivelConocimiento
        {
            get
            {
                return nivelConocimiento;
            }
            set
            {
                SetValue(ref nivelConocimiento, value);
            }
        }
        public string ComentarioMeliponicultura
        {
            get
            {
                return comentarioMeliponicultura;
            }
            set
            {
                SetValue(ref comentarioMeliponicultura, value);
            }
        }
        #endregion

        #region Attributes
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
        #endregion

        #region ApiServices

        #endregion

        #region constructors
        public MeliponiculturaViewModel()
        {

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
        #endregion

        #region Methods
        private async void Inventario()
        {
            
            await Application.Current.MainPage.Navigation.PushAsync(new InventarioEspecies());
        }
        private async void Guardar()
        {
            #region Validaciones  
            if (string.IsNullOrEmpty(OtrasEspecies) ||
                string.IsNullOrEmpty(ComoObtuvoColmena) ||
                string.IsNullOrEmpty(ComoCosecha) ||
                string.IsNullOrEmpty(SelectedOption) ||
                string.IsNullOrEmpty(DondeColocaColmena) ||
                (PrecioVenta== 0) ||
                string.IsNullOrEmpty(PrecioVenta.ToString()) ||
                (DesdeCuando== 0) ||
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
            }
        }
        private async void Volver()
        {

            await Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
