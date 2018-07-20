using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class VisitaIndividualProViewModel: BaseViewModel
    {
        #region Properties
        public DateTime FechaVisita
        {
            get
            {
                return fechaVisita;
            }
            set
            {
                SetValue(ref fechaVisita, value);
            }
        }
        public bool MeniponicultorPresente
        {
            get
            {
                return meniponicultorPresente;
            }
            set
            {
                SetValue(ref meniponicultorPresente, value);
            }
        }
        public string OtraPersonaPresente
        {
            get
            {
                return otraPersonaPresente;
            }
            set
            {
                SetValue(ref otraPersonaPresente, value);
            }
        }
        public string Motivo
        {
            get
            {
                return motivo;
            }
            set
            {
                SetValue(ref motivo, value);
            }
        }
        public string Observaciones
        {
            get
            {
                return observaciones;
            }
            set
            {
                SetValue(ref observaciones, value);
            }
        }
        public string AccionCorrectiva1
        {
            get
            {
                return accionCorrectiva1;
            }
            set
            {
                SetValue(ref accionCorrectiva1, value);
            }
        }
        public string AccionCorrectiva2
        {
            get
            {
                return accionCorrectiva2;
            }
            set
            {
                SetValue(ref accionCorrectiva2, value);
            }
        }
        public string AccionCorrectiva3
        {
            get
            {
                return accionCorrectiva3;
            }
            set
            {
                SetValue(ref accionCorrectiva3, value);
            }
        }
        public string AccionCorrectiva4
        {
            get
            {
                return accionCorrectiva4;
            }
            set
            {
                SetValue(ref accionCorrectiva4, value);
            }
        }
        public string Recomendaciones
        {
            get
            {
                return recomendaciones;
            }
            set
            {
                SetValue(ref recomendaciones, value);
            }
        }
        public int MeliponarioMariola
        {
            get
            {
                return meliponarioMariola;
            }
            set
            {
                SetValue(ref meliponarioMariola, value);
            }
        }
        public int MeliponarioSancuano
        {
            get
            {
                return meliponarioSancuano;
            }
            set
            {
                SetValue(ref meliponarioSancuano, value);
            }
        }
        public int MeliponarioOtro
        {
            get
            {
                return meliponarioOtro;
            }
            set
            {
                SetValue(ref meliponarioOtro, value);
            }
        }
        public int CampoMariola
        {
            get
            {
                return campoMariola;
            }
            set
            {
                SetValue(ref campoMariola, value);
            }
        }
        public int CampoSancuano
        {
            get
            {
                return campoSancuano;
            }
            set
            {
                SetValue(ref campoSancuano, value);
            }
        }
        public int CampoOtro
        {
            get
            {
                return campoOtro;
            }
            set
            {
                SetValue(ref campoOtro, value);
            }
        }
        public int TotalMariolaTrampa
        {
            get
            {
                return totalMariolaTrampa;
            }
            set
            {
                SetValue(ref totalMariolaTrampa, value);
            }
        }
        public int TotalSancuanoTrampa
        {
            get
            {
                return totalSancuanoTrampa;
            }
            set
            {
                SetValue(ref totalSancuanoTrampa, value);
            }
        }
        public int TotalOtroTrampa
        {
            get
            {
                return totalOtroTrampa;
            }
            set
            {
                SetValue(ref totalOtroTrampa, value);
            }
        }
        public int ACFNMariola
        {
            get
            {
                return aCFNMariola;
            }
            set
            {
                SetValue(ref aCFNMariola, value);
            }
        }
        public int ACFNSancuano
        {
            get
            {
                return aCFNSancuano;
            }
            set
            {
                SetValue(ref aCFNSancuano, value);
            }
        }
        public int ACFNOtro
        {
            get
            {
                return aCFNOtro;
            }
            set
            {
                SetValue(ref aCFNOtro, value);
            }
        }
        public int RusticaMariola
        {
            get
            {
                return rusticaMariola;
            }
            set
            {
                SetValue(ref rusticaMariola, value);
            }
        }
        public int RusticaSancuano
        {
            get
            {
                return rusticaSancuano;
            }
            set
            {
                SetValue(ref rusticaSancuano, value);
            }
        }
        public int RusticaOtro
        {
            get
            {
                return rusticaOtro;
            }
            set
            {
                SetValue(ref rusticaOtro, value);
            }
        }
        public int TotalSancuanoCajas
        {
            get
            {
                return totalSancuanoCajas;
            }
            set
            {
                SetValue(ref totalSancuanoCajas, value);
            }
        }
        public string Otros
        {
            get
            {
                return otros;
            }
            set
            {
                SetValue(ref otros, value);
            }
        }
        public int TotalMariolaCajas
        {
            get
            {
                return totalMariolaCajas;
            }
            set
            {
                SetValue(ref totalMariolaCajas, value);
            }
        }
        public int TotalOtroCajas
        {
            get
            {
                return totalOtroCajas;
            }
            set
            {
                SetValue(ref totalOtroCajas, value);
            }
        }
        #endregion

        #region Attributes

        private string otros;
        private int totalSancuanoCajas;
        private int totalMariolaCajas;
        private int rusticaOtro;
        private int rusticaSancuano;
        private int rusticaMariola;
        public int aCFNOtro;
        private int totalOtroCajas;
        private int aCFNSancuano;
        private int aCFNMariola;
        private int totalOtroTrampa;
        private int totalSancuanoTrampa;
        private int totalMariolaTrampa;
        private int campoOtro;
        private int campoSancuano;
        private int campoMariola;
        private int meliponarioOtro;
        private int meliponarioSancuano;
        private int meliponarioMariola;
        private string recomendaciones;
        private string accionCorrectiva1;
        private string accionCorrectiva2;
        private string accionCorrectiva3;
        private string accionCorrectiva4;
        private string observaciones;
        private string motivo;
        private string otraPersonaPresente;
        private bool meniponicultorPresente;
        private DateTime fechaVisita;
        #endregion

        #region ApiServices

        #endregion

        #region constructors
        public VisitaIndividualProViewModel()
        {
           

           // totalMariolaCajas = aCFNOtro + rusticaOtro;

//TotalMariolaCajas = ACFNOtro + RusticaOtro;
          //  TotalMariolaCajas = aCFNOtro + rusticaOtro;
           // totalOtroCajas = aCFNOtro + rusticaOtro;
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
        #endregion

        #region Methods
        private async void Guardar()
        {
            /* //creo que no lleva validaciones esta vista
            #region Validaciones  
            if (string.IsNullOrEmpty(OtraPersonaPresente) ||
                string.IsNullOrEmpty(Motivo) ||
                string.IsNullOrEmpty(Observaciones) ||
                string.IsNullOrEmpty(AccionCorrectiva1) ||
                string.IsNullOrEmpty(AccionCorrectiva2) ||
                string.IsNullOrEmpty(AccionCorrectiva3) ||
                string.IsNullOrEmpty(AccionCorrectiva4) ||
                string.IsNullOrEmpty(Recomendaciones) ||
                string.IsNullOrEmpty(Otros))
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Por Favor Llene los Campos Obligatorios", "Aceptar");
                return;
            }
            #endregion
            */
            await Application.Current.MainPage.DisplayAlert("Guardado", "Fecha: "+ FechaVisita
                                                            + "Meniponicultor Presente? :"
                                                            + meniponicultorPresente, "Excelente");
        }
        private async void Volver()
        {

            await Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
