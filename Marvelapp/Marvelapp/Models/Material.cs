using GalaSoft.MvvmLight.Command;
using Marvelapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace Marvelapp.Models
{
    public class Material
    {
        public string Fecha { set; get; }
        public string Boleta { set; get; }
        public string NombreMaterial { set; get; }
        public string Cantidad { set; get; }
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
            MaterialEntregadoViewModels.GetInstance().Materiales.Remove(this);
        }
        #endregion 
        #endregion
    }
}
