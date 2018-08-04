using System;
using System.Collections.Generic;
using System.Text;

namespace Marvelapp.Models
{
    public class Historico
    {
        public int IdMeliponario { set; get; }
        public string Productor { set; get; }
        public DateTime FechaDesde { set; get; }
        public DateTime FechaHasta { set; get; }
        public string Actual { set; get; }
    }
}
