using GalaSoft.MvvmLight.Command;
using Marvelapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvelapp.Models
{
    public class Miembro
    {
        public string NombreMiembro { set; get; }
        public string ParentescoMiembro { set; get; }
        public int EdadMiembro { set; get; }
        public string DiscapacidadMiembro { set; get; }
        public string CondicionLaboral { set; get; }
        public string Escolaridad { set; get; }

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
            ComposicionHogarViewModel.GetInstance().Miembros.Remove(this);//remuevo los miembros en mi lista principal
            BienestarSocialViewModel.GetInstance().HeighListViewB = ComposicionHogarViewModel.GetInstance().HeighListView - 44; //le resto 44, el ancho de la fila que estoy eliminando
            ComposicionHogarViewModel.GetInstance().HeighListView = BienestarSocialViewModel.GetInstance().HeighListViewB; //le resto 44, el ancho de la fila que estoy eliminando
            Application.Current.MainPage.DisplayAlert("Mensaje","Debe Guardar Para Conservar Los Cambios","Excelente");
        }
        #endregion 
        #endregion
    }

}
