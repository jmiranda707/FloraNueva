using GalaSoft.MvvmLight.Command;
using Marvelapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.Models
{
    public class Caja
    {
        public int IdCaja { set; get; }
        public string TipoCaja { set; get; }
        public DateTime FechaEntrega { set; get; }
        public string Activa { set; get; }
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
            AnMeliponarioCajaViewModel.GetInstance().Cajas.Remove(this);//remuevo los miembros en mi lista principal
            ANMeliponarioViewModel.GetInstance().HeighListViewAN = AnMeliponarioCajaViewModel.GetInstance().HeighListViewCaja - 44; //le resto 44, el ancho de la fila que estoy eliminando
            AnMeliponarioCajaViewModel.GetInstance().HeighListViewCaja = ANMeliponarioViewModel.GetInstance().HeighListViewAN; //le resto 44, el ancho de la fila que estoy eliminando
            Application.Current.MainPage.DisplayAlert("Mensaje", "Debe Guardar Para Conservar Los Cambios", "Excelente");
        }
        #endregion 
        #endregion
    }

}
