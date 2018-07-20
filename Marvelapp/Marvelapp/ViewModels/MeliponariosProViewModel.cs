using GalaSoft.MvvmLight.Command;
using Marvelapp.Models;
using Marvelapp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.ViewModels
{
    public class MeliponariosProViewModel : BaseViewModel
    {

        #region Attributes
        private ObservableCollection<MeliponarioPro> meliponarios;
        private bool isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<MeliponarioPro> Meliponarios
        {
            get { return meliponarios; }
            set { SetValue(ref meliponarios, value); }
        }
        public bool IsRefreshing //para refrescar el listview
        {
            get { return isRefreshing; }
            set { SetValue(ref isRefreshing, value); }
        }
        #endregion

        #region Constructors
        public MeliponariosProViewModel()
        {
            // this.IsRefreshing = true;
            Meliponarios = new ObservableCollection<MeliponarioPro>();
            LoadMeliponariosList(); //cargo el listado de Meliponarios
        }

        #endregion

        #region Methods
        private void LoadMeliponariosList()
        {
            Meliponarios.Add(new MeliponarioPro()
            {
                FechaCreacion = "01/02/2010",
                FotoProductor = "abejas.jpg",
                IdMeliponario = 201923,
                Tipo = "Individual"

            });
            Meliponarios.Add(new MeliponarioPro()
            {
                FechaCreacion = "08/02/2010",
                FotoProductor = "abejas.jpg",
                IdMeliponario = 300012,
                Tipo = "Gregario"

            }); Meliponarios.Add(new MeliponarioPro()
            {
                FechaCreacion = "01/06/2001",
                FotoProductor = "abejas.jpg",
                IdMeliponario = 20003,
                Tipo = "Individual"

            }); Meliponarios.Add(new MeliponarioPro()
            {
                FechaCreacion = "08/02/2005",
                FotoProductor = "abejas.jpg",
                IdMeliponario = 801971,
                Tipo = "Individual"

            });
            Meliponarios.Add(new MeliponarioPro()
            {
                FechaCreacion = "09/05/2017",
                FotoProductor = "abejas.jpg",
                IdMeliponario = 670163,
                Tipo = "Gregario"

            });

        }

        private async void BuscarMeliponario()//me envia a buscar un Meliponario (VISTA 41)
        {
            /*
            #region Validaciones  
            if (string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty() ||
                string.IsNullOrEmpty())
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Por Favor Llene los Campos Obligatorios", "Aceptar");
                return;
            }
            #endregion
            */
            await Application.Current.MainPage.Navigation.PushAsync(new BuscarMeliponario());
        }

        private async void AgregarMeliponario()//me envia a Agregar un Meliponario  (VISTA 29)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new BuscarMeliponario()); //Esta la Hizo Eleazar
        }
        #endregion

        #region Commands
        public ICommand BuscarMeliponarioCommand
        {
            get
            {
                return new RelayCommand(BuscarMeliponario);
            }
        }
        public ICommand AgregarMeliponarioCommand
        {
            get
            {
                return new RelayCommand(AgregarMeliponario);
            }
        }
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadMeliponariosList);
            }
        }
        #endregion
    }
}
