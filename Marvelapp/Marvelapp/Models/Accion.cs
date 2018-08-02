using GalaSoft.MvvmLight.Command;
using Marvelapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.Models
{
    public class Accion
    {
        public string TipoAccion { set; get; }
        public DateTime FechaAccion { set; get; }
        public string Responsable { set; get; }
        public string Comentario { set; get; }

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
              ANAccionMeliponarioViewModel.GetInstance().Acciones.Remove(this);//remuevo los miembros en mi lista principal
              AnMeliponarioCajaViewModel.GetInstance().HeighListViewB = ANAccionMeliponarioViewModel.GetInstance().HeighListView - 44; //le resto 44, el ancho de la fila que estoy eliminando
              ANAccionMeliponarioViewModel.GetInstance().HeighListView = AnMeliponarioCajaViewModel.GetInstance().HeighListViewB; //le resto 44, el ancho de la fila que estoy eliminando
              Application.Current.MainPage.DisplayAlert("Mensaje", "Debe Guardar Para Conservar Los Cambios", "Excelente");
        }
        #endregion 
        #endregion
    }
}
