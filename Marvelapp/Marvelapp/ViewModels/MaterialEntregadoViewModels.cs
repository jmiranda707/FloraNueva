﻿
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


namespace Marvelapp.ViewModels
{
    public class MaterialEntregadoViewModels : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<Material> material;
        private Double heighList;
        private bool isRefreshing;
        string cantidad, fecha, nombre, comentario;
        string boleta;
        //int i;

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

            IsRefreshing = true;
            /*if (Application.Current.Properties.ContainsKey("Contador"))
            {
                Elementos = int.Parse((Application.Current.Properties["Contador"]) as string);
            }
            else { Elementos = 0; }*/




            if (Application.Current.Properties.ContainsKey("Boleta"))
            {
                boleta = (Application.Current.Properties["Boleta"]) as string;
            }
            if (Application.Current.Properties.ContainsKey("Cantidad"))
            {
                cantidad = (Application.Current.Properties["Cantidad"] as string);
            }
            if (Application.Current.Properties.ContainsKey("Comentario"))
            {
                comentario = (Application.Current.Properties["Comentario"] as string);
            }
            if (Application.Current.Properties.ContainsKey("Fecha"))
            {
                fecha = (Application.Current.Properties["Fecha"] as string);
            }
            if (Application.Current.Properties.ContainsKey("NombreMaterial"))
            {
                nombre = (Application.Current.Properties["NombreMaterial"] as string);
            }
            Materiales.Add(new Material()
            {
                Boleta = boleta,
                Cantidad = cantidad,
                Comentario = comentario,
                Fecha = fecha,
                NombreMaterial = nombre,
            });







            ///OJOOOOOOOOOOOOOOOOO: despues que haga mis pruebas le coloco un if, si la lista esta vacia, agrego un material vacio para que la vista previa no se vea vaciaaa
            /*  using( var datos= new DataAccess())
              {

                  this.MaterialesLista = datos.GetMateriales(); //obtener desde persistencia mi lista de Materiales Guardados
              }
            Materiales = new ObservableCollection<Material>(MaterialesLista);*/
            IsRefreshing = false;

            HeighListView = 44 * Materiales.Count;
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
                Boleta = "0",
                NombreMaterial = "",
                Cantidad = "0",
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

        private async void Listo()
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


            foreach (var material in Materiales)
            {
                Application.Current.Properties["Boleta"] = material.Boleta.ToString();
                Application.Current.Properties["Cantidad"] = material.Cantidad.ToString();
                Application.Current.Properties["Comentario"] = material.Comentario;
                Application.Current.Properties["Fecha"] = material.Fecha;
                //Application.Current.Properties["IdMaterial"] = material.IdMaterial;
                Application.Current.Properties["NombreMaterial"] = material.NombreMaterial;
                await Application.Current.SavePropertiesAsync();
            }
            await Application.Current.MainPage.DisplayAlert("Notificación", "el Numero de Boleta es: "+Application.Current.Properties["Boleta"] as string, "Excelente");
            await Application.Current.MainPage.Navigation.PushAsync(new MaterialEntregadoView());
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
        public ICommand ListoCommand
        {
            get
            {
                return new RelayCommand(Listo);
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


