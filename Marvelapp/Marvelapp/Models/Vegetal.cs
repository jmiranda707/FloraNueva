using GalaSoft.MvvmLight.Command;
using Marvelapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Marvelapp.Models
{
    public class Vegetal
    {
        public string DetalleVegetal { set; get; }
        public string SuperficieVegetal { set; get; }
        public string CategoriaVegetal { set; get; }
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
            ProduccionAgricolaViewModel.GetInstance().Vegetales.Remove(this);
            ProduccionAgricolaViewModel.GetInstance().HeighListViewVegetal = ProduccionAgricolaViewModel.GetInstance().HeighListViewVegetal - 44; //le resto 44, el ancho de la fila que estoy eliminando
        }
        #endregion 
        #endregion
    }

}
