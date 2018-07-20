using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Marvelapp.Models
{
    public class Proyecto
    {
        public string NombreProyecto { set; get; }
        public string EstatusIntegracion { set; get; }
        public DateTime FechaIntegracion { set; get; }
        public DateTime FechaSalida { set; get; }
        public string RazonSalida { set; get; }
        /*
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
            MaterialEntregadoViewModels.GetInstance().Materiales.Remove(this);
        }
        #endregion 
        #endregion
        */
    }

}
