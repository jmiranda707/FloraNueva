
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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Marvelapp.ViewModels
{
    public class MaterialEntregadoViewModels : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

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
            get
            {
                return heighList;
            }
            set
            {
                if (heighList != value)
                {
                    heighList = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(HeighListView)));
                }
            }
        }
        public ObservableCollection<Material> Materiales
        {
            get
            {
                return material;
            }
            set
            {
                if (material != value)
                {
                    material = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(Materiales)));
                }
            }
        }
        public bool IsRefreshing //para refrescar el listview
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                if (isRefreshing != value)
                {
                    isRefreshing = value;
                    PropertyChanged?.Invoke(
                                            this,
                                            new PropertyChangedEventArgs(nameof(IsRefreshing)));
                }
            }
        }
        #endregion

        #region Constructors
        public MaterialEntregadoViewModels()
        {
            instance = this;
            Materiales = new ObservableCollection<Material>();
            LoadMateriales(); //carga el listado de materiales
        }
        #endregion

        #region Methods
       

        private void LoadMateriales()
        {
            if (Application.Current.Properties.ContainsKey("Contador")) //contador de la cantidad de elementos en la lista
            {
                Elementos = int.Parse((Application.Current.Properties["Contador"]) as string);
            }
            else { Elementos = 0; }

            IsRefreshing = true;

            for (int j = 0; j < Elementos; j++) //Elementos va a representar el total de elementos o filas existentes en mi persistencia
            {
                if (Application.Current.Properties.ContainsKey("Boleta"+j))
                {
                    boleta = (Application.Current.Properties["Boleta"+j]) as string;
                }
                else { boleta = "0"; }

                if (Application.Current.Properties.ContainsKey("Cantidad"+j))
                {
                    cantidad = (Application.Current.Properties["Cantidad"+j] as string);
                }
                else { cantidad = "0"; }

                if (Application.Current.Properties.ContainsKey("Comentario"+j))
                {
                    comentario = (Application.Current.Properties["Comentario"+j] as string);
                }
                else { comentario = ""; }

                if (Application.Current.Properties.ContainsKey("Fecha"+j))
                {
                    fecha = (Application.Current.Properties["Fecha"+j] as string);
                }
                else { fecha = ""; }

                if (Application.Current.Properties.ContainsKey("NombreMaterial"+j))
                {
                    nombre = (Application.Current.Properties["NombreMaterial"+j] as string);
                }
                else { nombre = ""; }

                Materiales.Add(new Material() //agrega a mi lista todos los elementos existentes en persistencia
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

        private async void NuevaVisita()//me envia a agregar una nueva visita individual-prod (VISTA 33)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new VisitaIndividualPro());
        }

        private async void SearchVisita()//me envia a buscar una visita individual (VISTA 40)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new BuscarVisitaIndividual());
        }

        private async void TapPopup()//me envia al popup para adicionar o eliminar filas del listado
        {
            await PopupNavigation.PushAsync(new MaterialEntregadoPopup());
        }
      
        private async void Guardar()
        {
            #region Validaciones  
           /* if (string.IsNullOrEmpty() ||
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
            
            await Application.Current.MainPage.DisplayAlert("Guardado", "Su Lista se Ha Guardado Exitosamente", "Excelente");
        }
      
        private async void Volver()
        {
            await Application.Current.MainPage.Navigation.PopAsync();//
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


