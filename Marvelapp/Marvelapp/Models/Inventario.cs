using GalaSoft.MvvmLight.Command;
using Marvelapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.Models
{
    public class Inventario
    {
        public string Especie { set; get; }
        public int CantidadTronco { set; get; }
        public int CantidadArtificial { set; get; }
        public int CantidadRustica { set; get; }
        public int CantidadTecnificada { set; get; }

        #region Exception
        #region Command
        public ICommand SelectedEliminarCommand
        {
            get
            {
                return new RelayCommand(SelectedEliminar);
            }
        }
        #endregion

        #region Methods
        private void SelectedEliminar()
        {
            InventarioEspeciesViewModel.GetInstance().Inventarios.Remove(this);//remuevo los miembros en mi lista principal
            MeliponiculturaViewModel.GetInstance().HeighListViewB = InventarioEspeciesViewModel.GetInstance().HeighListView - 44; //le resto 44, el ancho de la fila que estoy eliminando
            InventarioEspeciesViewModel.GetInstance().HeighListView = MeliponiculturaViewModel.GetInstance().HeighListViewB; //le resto 44, el ancho de la fila que estoy eliminando
            Application.Current.MainPage.DisplayAlert("Mensaje", "Debe Guardar Para Conservar Los Cambios", "Excelente");
        }
        #endregion 
        #endregion
    }

}
