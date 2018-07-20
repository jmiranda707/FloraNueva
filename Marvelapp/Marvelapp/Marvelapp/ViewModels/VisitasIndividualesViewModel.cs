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
    public class VisitasIndividualesViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<VisitaIndividual> visitasIndi;
        private bool isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<VisitaIndividual> VisitasIndi
        {
            get { return visitasIndi; }
            set { SetValue(ref visitasIndi, value); }
        }
        public bool IsRefreshing //para refrescar el listview
        {
            get { return isRefreshing; }
            set { SetValue(ref isRefreshing, value); }
        }
        #endregion

        #region Constructors
        public VisitasIndividualesViewModel()
        {
            // this.IsRefreshing = true;
            VisitasIndi = new ObservableCollection<VisitaIndividual>();
            LoadVisitasIndividuales(); //cargo el listado de visitas
        }
        #endregion

        #region Methods
        private void LoadVisitasIndividuales()
        {
            VisitasIndi.Add(new VisitaIndividual()
            {
                FechaVisita="07/08/2018",
                Motivo="Cumpleaños",
                Observaciones="Excelente, todo muy bien",
                FotoVisitaIndividual= "abej.jpg"
            });
            VisitasIndi.Add(new VisitaIndividual()
            {
                FechaVisita = "08/09/2018",
                Motivo = "Seguimiento",
                Observaciones = "Todo bajo perfecta normalidad",
                FotoVisitaIndividual = "abej.jpg"
            });
            VisitasIndi.Add(new VisitaIndividual()
            {
                FechaVisita = "09/08/2018",
                Motivo = "Seguimiento",
                Observaciones = "No hay nada",
                FotoVisitaIndividual = "abej.jpg"
            });
            VisitasIndi.Add(new VisitaIndividual()
            {
                FechaVisita = "10/08/2018",
                Motivo = "Seguimiento",
                Observaciones = "Todo bajo perfecta normalidad",
                FotoVisitaIndividual = "abej.jpg"
            });
            VisitasIndi.Add(new VisitaIndividual()
            {
                FechaVisita = "11/08/2018",
                Motivo = "Seguimiento",
                Observaciones = "Sin comentarios",
                FotoVisitaIndividual = "abej.jpg"
            });
            VisitasIndi.Add(new VisitaIndividual()
            {
                FechaVisita = "12/08/2018",
                Motivo = "Seguimiento",
                Observaciones = "Todo bajo perfecta normalidad",
                FotoVisitaIndividual = "abej.jpg"
            });
        }

        private async void NuevaVisita()//me envia a agregar una nueva visita individual-prod (VISTA 33)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new VisitaIndividualPro());
        }

        private async void SearchVisita()//me envia a buscar una visita individual (VISTA 40)
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
            await Application.Current.MainPage.Navigation.PushAsync(new BuscarVisitaIndividual());
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadVisitasIndividuales);
            }
        }
        public ICommand NuevaVisitaCommand
        {
            get
            {
                return new RelayCommand(NuevaVisita);
            }
        }
        public ICommand SearchVisitaCommand
        {
            get
            {
                return new RelayCommand(SearchVisita);
            }
        }
        #endregion
    }
}
