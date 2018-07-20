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
    public class VisitasGrupalesProViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<VisitaGrupalProductor> visitas;
        private bool isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<VisitaGrupalProductor> Visitas
        {
            get { return visitas; }
            set { SetValue(ref visitas, value); }
        }
        public bool IsRefreshing //para refrescar el listview
        {
            get { return isRefreshing; }
            set { SetValue(ref isRefreshing, value); }
        }
        #endregion

        #region Constructors
        public VisitasGrupalesProViewModel()
        {
            // this.IsRefreshing = true;
            Visitas = new ObservableCollection<VisitaGrupalProductor>();
            LoadVisitasGrupales(); //cargo el listado de visitas
        }
        #endregion

        #region Methods
        private void LoadVisitasGrupales()
        {
            Visitas.Add(new VisitaGrupalProductor()
            {
                NameGrupo = "La Esperanza",
                FechaDesde = "19/18/2000",
                FechaHasta = "30/20/2001",
                FotoVisita = "abeja.jpg"
            });
            Visitas.Add(new VisitaGrupalProductor()
            {
                NameGrupo = "La Esperanza",
                FechaDesde = "19/18/2000",
                FechaHasta = "30/20/2001",
                FotoVisita = "abeja.jpg"
            }); Visitas.Add(new VisitaGrupalProductor()
            {
                NameGrupo = "La Esperanza",
                FechaDesde = "19/18/2000",
                FechaHasta = "30/20/2001",
                FotoVisita = "abeja.jpg"
            }); Visitas.Add(new VisitaGrupalProductor()
            {
                NameGrupo = "La Esperanza",
                FechaDesde = "19/18/2000",
                FechaHasta = "30/20/2001",
                FotoVisita = "abeja.jpg"
            });
            Visitas.Add(new VisitaGrupalProductor()
            {
                NameGrupo = "La Esperanza",
                FechaDesde = "19/18/2015",
                FechaHasta = "01/29/2012",
                FotoVisita = "abeja.jpg"
            });
            Visitas.Add(new VisitaGrupalProductor()
            {
                NameGrupo = "La Esperanza",
                FechaDesde = "20/20/2000",
                FechaHasta = "30/20/2011",
                FotoVisita = "abeja.jpg"
            });
        }

        private async void VisitaGrupalc()//me envia a agregar una nueva visita grupal (VISTA 37)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new VisitaGrupalPro());
        }

        private async void SearchVisitaGrupal()//me envia a buscar una visita grupal (VISTA 38)
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
            await Application.Current.MainPage.Navigation.PushAsync(new BuscarVisitaGrupal());
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadVisitasGrupales);
            }
        }
        public ICommand VisitaGrupalcCommand
        {
            get
            {
                return new RelayCommand(VisitaGrupalc);
            }
        }
        public ICommand SearchVisitaGrupalCommand
        {
            get
            {
                return new RelayCommand(SearchVisitaGrupal);
            }
        }
        #endregion

    }
}
