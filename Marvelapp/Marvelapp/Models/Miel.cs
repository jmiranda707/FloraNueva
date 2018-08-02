using GalaSoft.MvvmLight.Command;
using Marvelapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Marvelapp.Models
{
    public class Miel
    {
        public int Lote { set; get; }
        public string Especie { set; get; }
        //Falta definir los Checkboxs
        public string Alza { set; get; }
        public int Peso { set; get; }
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
            ANCosechaMeliponarioViewModel.GetInstance().Mieles.Remove(this);
            ANCosechaMeliponarioViewModel.GetInstance().HeighListView = ANCosechaMeliponarioViewModel.GetInstance().HeighListView - 44; //le resto 44, el ancho de la fila que estoy eliminando
        }
        #endregion 
        #endregion
    }

}
