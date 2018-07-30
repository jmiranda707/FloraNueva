using GalaSoft.MvvmLight.Command;
using Marvelapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Marvelapp.Models
{
    public class Contacto
    {
        public string TipoContacto { set; get; }
        public string NombreContacto { set; get; }
        public string DetalleContacto { set; get; }

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
            DatosPersonalesViewModel.GetInstance().Contactos.Remove(this);
            DatosPersonalesViewModel.GetInstance().HeighListView = DatosPersonalesViewModel.GetInstance().HeighListView - 44; //le resto 44, el ancho de la fila que estoy eliminando
        }
        #endregion 
        #endregion
    }

}
