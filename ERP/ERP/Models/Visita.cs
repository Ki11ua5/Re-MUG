using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class Visita
    {
        public int Folio { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public DateTime Fecha { get; set; }
         
        public Tecnico Tecnico { get; set; }

    }
}