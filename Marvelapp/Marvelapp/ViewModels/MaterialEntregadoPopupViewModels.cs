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

namespace Marvelapp.ViewModels
{
    public class MaterialEntregadoPopupViewModels :BaseViewModel
    {

        #region Attributes
        private ObservableCollection<Material> material;
        private Double heighList;
        private bool isRefreshing;
        private string cantidad;
        private string fecha;
        private string nombre;
        private string comentario;
        private string boleta;
        private int i;
        private int Elementos;
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
            public MaterialEntregadoPopupViewModels()
            {
                instance = this;
                Materiales = new ObservableCollection<Material>();
                LoadMateriales(); //cargo el listado de materiales
            }
            #endregion

        #region Methods

            private void LoadMateriales()
            {
                if (Application.Current.Properties.ContainsKey("Contador"))
                {
                    Elementos = int.Parse((Application.Current.Properties["Contador"]) as string);
                }
                else { Elementos = 0; }

                IsRefreshing = true;
                for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de filas existentes en mi persistencia
                {
                    if (Application.Current.Properties.ContainsKey("Boleta" + j))
                    {
                        boleta = (Application.Current.Properties["Boleta" + j]) as string;
                    }
                    else { boleta = "0"; }
                    if (Application.Current.Properties.ContainsKey("Cantidad" + j))
                    {
                        cantidad = (Application.Current.Properties["Cantidad" + j] as string);
                    }
                    else { cantidad = "0"; }
                    if (Application.Current.Properties.ContainsKey("Comentario" + j))
                    {
                        comentario = (Application.Current.Properties["Comentario" + j] as string);
                    }
                    else { comentario = ""; }
                    if (Application.Current.Properties.ContainsKey("Fecha" + j))
                    {
                        fecha = (Application.Current.Properties["Fecha" + j] as string);
                    }
                    else { fecha = ""; }
                    if (Application.Current.Properties.ContainsKey("NombreMaterial" + j))
                    {
                        nombre = (Application.Current.Properties["NombreMaterial" + j] as string);
                    }
                    else { nombre = ""; }
                    Materiales.Add(new Material()
                    {
                        Boleta = boleta,
                        Cantidad = cantidad,
                        Comentario = comentario,
                        Fecha = fecha,
                        NombreMaterial = nombre,
                    });
                }
                IsRefreshing = false;

                HeighListView = 44 * Materiales.Count; //cantidad de filas en mi lista, multiplicado por 44 que es el alto maximo de cada fila

            }
        
            private void TapAgregar()//agrega una fila vacia a la tabla materiales
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

            private async void Listo()
            {

                #region Validaciones  
                /*
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
                }*/
                #endregion

                #region Limpiar Cache //borrar los datos existentes en persistencia

                if (Application.Current.Properties.ContainsKey("Contador"))
                {
                    Elementos = int.Parse((Application.Current.Properties["Contador"]) as string);
                }
                else { Elementos = 0; }

                for (int j = 0; j < Elementos; j++) //i va a representar el total de elementos o filas existentes en mi persistencia
                {
                    if (Application.Current.Properties.ContainsKey("Boleta" + j))
                    {
                        Application.Current.Properties.Remove("Boleta" + j);
                    }
                    if (Application.Current.Properties.ContainsKey("Cantidad" + j))
                    {
                        Application.Current.Properties.Remove("Cantidad" + j);
                    }
                    if (Application.Current.Properties.ContainsKey("Comentario" + j))
                    {
                        Application.Current.Properties.Remove("Comentario" + j);
                    }
                    if (Application.Current.Properties.ContainsKey("Fecha" + j))
                    {
                        Application.Current.Properties.Remove("Fecha" + j);
                    }
                    if (Application.Current.Properties.ContainsKey("NombreMaterial" + j))
                    {
                        Application.Current.Properties.Remove("NombreMaterial" + j);
                    }
                    if (Application.Current.Properties.ContainsKey("Contador"))
                    {
                        Application.Current.Properties.Remove("Contador");
                    }
            }

                #endregion

                #region Ciclo para Guardar en Persistencia
                i = 0; //inicio el contador de mis elementos o filas en (0)
                foreach (var material in Materiales)
                {
                    Application.Current.Properties["Boleta" + i] = material.Boleta.ToString();
                    Application.Current.Properties["Cantidad" + i] = material.Cantidad.ToString();
                    Application.Current.Properties["Comentario" + i] = material.Comentario;
                    Application.Current.Properties["Fecha" + i] = material.Fecha;
                    Application.Current.Properties["NombreMaterial" + i] = material.NombreMaterial;
                    i++;
                    Application.Current.Properties["Contador"] = i.ToString();
                    await Application.Current.SavePropertiesAsync();
                }

            #endregion
            int filas;
            MaterialEntregadoViewModels.GetInstance().Materiales = Materiales; // igualo el valor de mis listas
            MaterialEntregadoViewModels.GetInstance().HeighListView = 44 * i;
            if (Application.Current.Properties.ContainsKey("Contador"))
            {
                filas = int.Parse(Application.Current.Properties["Contador"]as string);
            }
            else { filas = 0; }
            await Application.Current.MainPage.DisplayAlert("Notificación", "El Numero de Filas Guardadas es: " + filas.ToString(), "Excelente");    
            await PopupNavigation.PopAsync(); //para cerrar el popup

                  //LoadMateriales();
                  
                  //MaterialEntregadoViewModels.GetInstance().IsRefreshing = true;

        }

            private async void Salir()
            {
                await PopupNavigation.PopAsync(); //para cerrar el popup sin guardar los cambios en persistencia
            }
            #endregion

        #region Commands

            public ICommand SalirCommand
            {
                get
                {
                    return new RelayCommand(Salir);
                }
            }
            
            public ICommand ListoCommand
            {
                get
                {
                    return new RelayCommand(Listo);
                }
            }
           
            public ICommand RefreshCommand
            {
                get
                {
                    return new RelayCommand(LoadMateriales);
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

            private static MaterialEntregadoPopupViewModels instance;
            public static MaterialEntregadoPopupViewModels GetInstance()
            {
                if (instance == null)
                {
                    return new MaterialEntregadoPopupViewModels();
                }
                return instance;
            }

            #endregion
       
        //nuevo comentario// este viewmodel es agregado hoy

    }
}
