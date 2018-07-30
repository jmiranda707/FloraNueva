using GalaSoft.MvvmLight.Command;
using Marvelapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Marvelapp.Models
{
    public class Documento
    {
        public string TipoDocumento { set; get; }
        public string DetalleDocumento { set; get; }

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
            DatosDiagnosticoViewModel.GetInstance().Documentos.Remove(this);
            DatosDiagnosticoViewModel.GetInstance().HeighListView = DatosDiagnosticoViewModel.GetInstance().HeighListView - 44; //le resto 44, el ancho de la fila que estoy eliminando
        }
        #endregion 
        #endregion
    }
}
