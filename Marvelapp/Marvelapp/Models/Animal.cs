using GalaSoft.MvvmLight.Command;
using Marvelapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Marvelapp.Models
{
    public class Animal
    {
        public string DetalleAnimal { set; get; }
        public string CantidadAnimal { set; get; }
        public string NombreAnimal { set; get; }
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
            ProduccionAgricolaViewModel.GetInstance().Animales.Remove(this);
            ProduccionAgricolaViewModel.GetInstance().HeighListViewAnimal = ProduccionAgricolaViewModel.GetInstance().HeighListViewAnimal - 44; //le resto 44, el ancho de la fila que estoy eliminando
        }
        #endregion 
        #endregion
    }

}
