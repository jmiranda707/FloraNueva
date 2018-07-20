using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Marvelapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VisitaIndividualPro : ContentPage
	{
		public VisitaIndividualPro ()
		{
			InitializeComponent ();
            FechaVisita.Date = DateTime.Now;
            #region PropertiesChanged de los Entry
            MeliponarioMariola.PropertyChanging += MeliponarioMariola_PropertyChanging;
            CampoMariola.PropertyChanging += CampoMariola_PropertyChanging;
            MeliponarioSancuano.PropertyChanging += MeliponarioSancuano_PropertyChanging;
            CampoSancuano.PropertyChanging += CampoSancuano_PropertyChanging;
            MeliponarioOtro.PropertyChanging += MeliponarioOtro_PropertyChanging;
            CampoOtro.PropertyChanging += CampoOtro_PropertyChanging;
            ACFNMariola.PropertyChanging += ACFNMariola_PropertyChanging;
            RusticaMariola.PropertyChanging += RusticaMariola_PropertyChanging;
            ACFNSancuano.PropertyChanging += ACFNSancuano_PropertyChanging;
            RusticaSancuano.PropertyChanging += RusticaSancuano_PropertyChanging;
            ACFNOtro.PropertyChanging += ACFNOtro_PropertyChanging;
            RusticaOtro.PropertyChanging += RusticaOtro_PropertyChanging;
            #endregion
        }

            #region metodos para sumar el total de las matrices en tiempo de ejecucion
        private void RusticaOtro_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            TotalOtroCajas.Text = (int.Parse(ACFNOtro.Text) + int.Parse(RusticaOtro.Text)).ToString();
        }

        private void ACFNOtro_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            TotalOtroCajas.Text = (int.Parse(ACFNOtro.Text) + int.Parse(RusticaOtro.Text)).ToString();
        }

        private void RusticaSancuano_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            TotalSancuanoCajas.Text = (int.Parse(ACFNSancuano.Text) + int.Parse(RusticaSancuano.Text)).ToString();
        }

        private void ACFNSancuano_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            TotalSancuanoCajas.Text = (int.Parse(ACFNSancuano.Text) + int.Parse(RusticaSancuano.Text)).ToString();
        }

        private void RusticaMariola_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            TotalMariolaCajas.Text = (int.Parse(ACFNMariola.Text) + int.Parse(RusticaMariola.Text)).ToString();
        }

        private void ACFNMariola_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            TotalMariolaCajas.Text = (int.Parse(ACFNMariola.Text) + int.Parse(RusticaMariola.Text)).ToString();
        }

        private void CampoSancuano_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            TotalSancuanoTrampa.Text = (int.Parse(MeliponarioSancuano.Text) + int.Parse(CampoSancuano.Text)).ToString();
        }

        private void MeliponarioSancuano_PropertyChanging1(object sender, PropertyChangingEventArgs e)
        {
            TotalSancuanoTrampa.Text = (int.Parse(MeliponarioSancuano.Text) + int.Parse(CampoSancuano.Text)).ToString();
        }

        private void CampoOtro_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            TotalOtroTrampa.Text = (int.Parse(MeliponarioOtro.Text) + int.Parse(CampoOtro.Text)).ToString();
        }

        private void MeliponarioOtro_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            TotalOtroTrampa.Text = (int.Parse(MeliponarioOtro.Text) + int.Parse(CampoOtro.Text)).ToString();
        }

        private void MeliponarioSancuano_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            TotalSancuanoTrampa.Text = (int.Parse(MeliponarioSancuano.Text) + int.Parse(CampoSancuano.Text)).ToString();
        }

        private void CampoMariola_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            TotalMariolaTrampa.Text = (int.Parse(MeliponarioMariola.Text) + int.Parse(CampoMariola.Text)).ToString();
        }

        private void MeliponarioMariola_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            TotalMariolaTrampa.Text = (int.Parse(MeliponarioMariola.Text) + int.Parse(CampoMariola.Text)).ToString();
        }
        #endregion
    }
}