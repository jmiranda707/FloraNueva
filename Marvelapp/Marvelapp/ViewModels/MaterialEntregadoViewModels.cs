using GalaSoft.MvvmLight.Command;
using Marvelapp.Models;
using Marvelapp.Views;
using Marvelapp.Views.Popups;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;


namespace Marvelapp.ViewModels
{
    public class MaterialEntregadoViewModels :BaseViewModel
    {
        #region Attributes
        private ObservableCollection<Material> material;
        private Double heighList;
        private bool isRefreshing;
        #endregion

        #region Properties
        public Double HeighListView
        {
            get { return heighList; }
            set { SetValue(ref heighList, value); }
        }
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
                Boleta = 1,
                Cantidad = 0,
                Comentario = "",
                Fecha = "",
                NombreMaterial = ""
            });
            Materiales.Add(new Material()
            {
                Boleta = 2,
                Cantidad = 0,
                Comentario = "",
                Fecha = "",
                NombreMaterial = ""
            });
            Materiales.Add(new Material()
            {
                Boleta = 3,
                Cantidad = 0,
                Comentario = "",
                Fecha = "",
                NombreMaterial = ""
            });
            Materiales.Add(new Material()
            {
                Boleta = 4,
                Cantidad = 0,
                Comentario = "",
                Fecha = "",
                NombreMaterial = ""
            });
            Materiales.Add(new Material()
            {
                Boleta = 5,
                Cantidad = 0,
                Comentario = "",
                Fecha = "",
                NombreMaterial = ""
            });
            Materiales.Add(new Material()
            {
                Boleta = 6,
                Cantidad = 0,
                Comentario = "",
                Fecha = "",
                NombreMaterial = ""
            });
            Materiales.Add(new Material()
            {
                Boleta = 7,
                Cantidad = 0,
                Comentario = "",
                Fecha = "",
                NombreMaterial = ""
            });
            // MaterialesOrder= Materiales.LastOrDefault();
            IsRefreshing = false;
            
            HeighListView = 44*Materiales.Count();
        }

        private async void NuevaVisita()//me envia a agregar una nueva visita individual-prod (VISTA 33)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new VisitaIndividualPro());
        }

        private async void SearchVisita()//me envia a buscar una visita individual (VISTA 40)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new BuscarVisitaIndividual());
        }


        private async void TapPopup()//me envia a buscar una visita individual (VISTA 40)
        {

            ///Aqui viene el popup para agregar un nuevo Material///
            //PopupNavigation.Instance.PushAsync;
            await PopupNavigation.PushAsync(new MaterialEntregadoPopup());
        }


        private void TapAgregar()//me envia a buscar una visita individual (VISTA 40)
        {
            
                        IsRefreshing = true;
                        Materiales.Add(new Material()
                        {
                            Boleta = 0,
                            NombreMaterial = "",
                            Cantidad = 0,
                            Fecha = "",
                            Comentario = ""
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
       
        public ICommand TapPopupCommand
        {
            get
            {
                return new RelayCommand(TapPopup);
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
