using Marvelapp.Models;
using Marvelapp.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Marvelapp.Views.Popups
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MaterialEntregadoPopup 
    {
		public MaterialEntregadoPopup ()
		{
			InitializeComponent ();
            this.CloseWhenBackgroundIsClicked = false; //esto desactiva "cerrar" el popup al hacer clic en cualquier parte del popup (en el background)
        }

        #region Refrescar Parent (MaterialEntregadoView) al cerrar el popup
        public delegate void CallbackDelegate(IList list);
        public CallbackDelegate CallbackMethod { get; set; }
        private void InvoceCallback()
        {
            CallbackMethod?.Invoke(MaterialEntregadoViewModels.GetInstance().Materiales);
        }
        #endregion

    }
}