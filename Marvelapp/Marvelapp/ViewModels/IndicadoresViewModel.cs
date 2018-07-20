using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class IndicadoresViewModel :BaseViewModel
    {
        #region Properties
        public int BienestarSocialFamiliar
        {
            get
            {
                return bienestarSocialFamiliar;
            }
            set
            {
                SetValue(ref bienestarSocialFamiliar, value);
            }
        }
        public int BienestarEconomicoHogar
        {
            get
            {
                return bienestarEconomicoHogar;
            }
            set
            {
                SetValue(ref bienestarEconomicoHogar, value);
            }
        }
        public int SoberaniaAlimenticia
        {
            get
            {
                return soberaniaAlimenticia;
            }
            set
            {
                SetValue(ref soberaniaAlimenticia, value);
            }
        }
        public int Felicidad
        {
            get
            {
                return felicidad;
            }
            set
            {
                SetValue(ref felicidad, value);
            }
        }
        #endregion

        #region Attributes
        private int bienestarSocialFamiliar;
        private int bienestarEconomicoHogar;
        private int soberaniaAlimenticia;
        private int felicidad;
        #endregion

        #region ApiServices

        #endregion

        #region constructors

        #endregion

        #region Commands
        public ICommand VolverCommand
        {
            get
            {
                return new RelayCommand(Volver);
            }
        }
        #endregion

        #region Methods
        private async void Volver()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
