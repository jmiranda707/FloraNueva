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
    public class MeliponariosViewModel : BaseViewModel
    {
        
            #region Attributes
            private ObservableCollection<Meliponario> meliponarios;
            private bool isRefreshing;
            #endregion

            #region Properties
            public ObservableCollection<Meliponario> Meliponarios
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
        public MeliponariosViewModel()
        {
            // this.IsRefreshing = true;
            Meliponarios = new ObservableCollection<Meliponario>();
            LoadMeliponariosList(); //cargo el listado de visitas
        }
           
        #endregion

            #region Methods
            private void LoadMeliponariosList()
            {
                Meliponarios.Add(new Meliponario()
                {
                    FechaCreacion="01/02/2010",
                    FotoProductor="abej.jpg",
                    IdMeliponario=201923,
                    NameProductor="Jesus Daniel Miranda"

                });
            Meliponarios.Add(new Meliponario()
            {
                FechaCreacion = "08/02/2010",
                FotoProductor = "abej.jpg",
                IdMeliponario = 300012,
                NameProductor = "Arnaldo Miranda"

            }); Meliponarios.Add(new Meliponario()
            {
                FechaCreacion = "01/06/2001",
                FotoProductor = "abej.jpg",
                IdMeliponario = 20003,
                NameProductor = "Andres Antonio Azocar"

            }); Meliponarios.Add(new Meliponario()
            {
                FechaCreacion = "08/02/2005",
                FotoProductor = "abej.jpg",
                IdMeliponario = 801971,
                NameProductor = "Dariana Parabavire"

            });
            Meliponarios.Add(new Meliponario()
            {
                FechaCreacion = "09/05/2017",
                FotoProductor = "abej.jpg",
                IdMeliponario = 670163,
                NameProductor = "Jose Luis Miranda"

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
