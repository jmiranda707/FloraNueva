using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class VisitaGrupalANViewModel: BaseViewModel
    {

        #region Properties
        public string GrupoSelected
        {
            get
            {
                return grupoSelected;
            }
            set
            {
                SetValue(ref grupoSelected, value);
            }
        }
        public DateTime FechaDesde
        {
            get
            {
                return fechaDesde;
            }
            set
            {
                SetValue(ref fechaDesde, value);
            }
        }
        public DateTime FechaHastaVisitaGrupal
        {
            get
            {
                return fechaHastaVisitaGrupal;
            }
            set
            {
                SetValue(ref fechaHastaVisitaGrupal, value);
            }
        }
        public string ParticipantesVisitaGrupal
        {
            get
            {
                return participantesVisitaGrupal;
            }
            set
            {
                SetValue(ref participantesVisitaGrupal, value);
            }
        }
        public string EquipoFloraPresente
        {
            get
            {
                return equipoFloraPresente;
            }
            set
            {
                SetValue(ref equipoFloraPresente, value);
            }
        }
        public string OtrosParticipantes
        {
            get
            {
                return otrosParticipantes;
            }
            set
            {
                SetValue(ref otrosParticipantes, value);
            }
        }
        public string TemaObjetivo
        {
            get
            {
                return temaObjetivo;
            }
            set
            {
                SetValue(ref temaObjetivo, value);
            }
        }
        public string DesarrolloAcciones
        {
            get
            {
                return desarrolloAcciones;
            }
            set
            {
                SetValue(ref desarrolloAcciones, value);
            }
        }
        public string MaterialEntregado
        {
            get
            {
                return materialEntregado;
            }
            set
            {
                SetValue(ref materialEntregado, value);
            }
        }
        public string ProblemasDetectados
        {
            get
            {
                return problemasDetectados;
            }
            set
            {
                SetValue(ref problemasDetectados, value);
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
        #endregion

        #region Attributes
        private string recomendaciones;
        private string problemasDetectados;
        private string materialEntregado;
        private string desarrolloAcciones;
        private string otrosParticipantes;
        private string equipoFloraPresente;
        private DateTime fechaHastaVisitaGrupal;
        private DateTime fechaDesde;
        private string grupoSelected;
        private string participantesVisitaGrupal;
        private string temaObjetivo;
        private bool isEnabled;
        #endregion

        #region ApiServices

        #endregion

        #region constructors
        public VisitaGrupalANViewModel()
        {
            this.IsEnabled = true;
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
        private async void Guardar()//guardar cambios
        {
           /*  //ESTAS VALIDACIONES APARENTEMENTE NO VAN PORQUE NO TIENEN EL * (informate si lleva validaciones)
            #region Validaciones  
            if (string.IsNullOrEmpty(GrupoSelected) ||
                string.IsNullOrEmpty(ParticipantesVisitaGrupal) ||
                string.IsNullOrEmpty(EquipoFloraPresente) ||
                string.IsNullOrEmpty(OtrosParticipantes) ||
                string.IsNullOrEmpty(TemaObjetivo) ||
                string.IsNullOrEmpty(DesarrolloAcciones) ||
                string.IsNullOrEmpty(MaterialEntregado) ||
                string.IsNullOrEmpty(ProblemasDetectados) ||
                string.IsNullOrEmpty(Recomendaciones))
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Por Favor Llene los Campos Obligatorios", "Aceptar");
                return;
            }
            #endregion
           */
            await Application.Current.MainPage.DisplayAlert("Guardado", "Grupo Seleccionado: "+GrupoSelected, "Excelente");
        }
        private async void Volver() //regresar
        {

            await Application.Current.MainPage.Navigation.PopAsync();
        }
        
        #endregion
    
    }
}
