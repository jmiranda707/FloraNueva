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
    public class MaterialEntregadoViewModels :BaseViewModel
    {
        #region Attributes
        private ObservableCollection<Material> material;
        private bool isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<Material> Materiales
        {
            get { return material; }
            set { SetValue(ref material, value); }
        }
        public bool IsRefreshing //para refrescar el listview
        {
            get { return isRefreshing; }
            set { SetValue(ref isRefreshing, value); }
        }
        #endregion

        #region Constructors
        public MaterialEntregadoViewModels()
        {
            // this.IsRefreshing = true;
            instance = this;
            Materiales = new ObservableCollection<Material>();
            LoadMateriales(); //cargo el listado de materiales
            //NewMaterial();
        }

        #endregion

        #region Methods
        private void LoadMateriales()
        {
            Materiales.Add(new Material()
            {
                Boleta = 0,
                Cantidad = 0,
                Comentario = "",
                Fecha = "",
                NombreMaterial = ""
            });
            IsRefreshing = false;
        }

        private async void NuevaVisita()//me envia a agregar una nueva visita individual-prod (VISTA 33)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new VisitaIndividualPro());
        }

        private async void SearchVisita()//me envia a buscar una visita individual (VISTA 40)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new BuscarVisitaIndividual());
        }

        
        private void TapAgregar()//me envia a buscar una visita individual (VISTA 40)
        {

            IsRefreshing = true;
            Materiales.Add(new Material()
            {
                Boleta = 0,
                NombreMaterial = "este",
                Cantidad = 0,
                Fecha = "",
                Comentario = "ACABAS DE AGREGARLO"
            });
            IsRefreshing = false;
        }

        private async void Guardar()
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
            await Application.Current.MainPage.DisplayAlert("Guardado", "Usted ha Guardado Exitosamente", "Excelente");
        }

        private async void Volver()
        {

            await Application.Current.MainPage.Navigation.PopAsync();
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
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadMateriales);
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
        public ICommand TapAgregarCommand
        {
            get
            {
                return new RelayCommand(TapAgregar);
            }
        }
        
        #endregion
        #region Singleton 
        private static MaterialEntregadoViewModels instance;

        public static MaterialEntregadoViewModels GetInstance()
        {
            if (instance == null)
            {
                return new MaterialEntregadoViewModels();
            }
            return instance;
        }
        #endregion
    }
}
