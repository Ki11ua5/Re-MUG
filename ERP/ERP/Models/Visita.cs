using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class Visita
    {
        [Key]
        public int Folio { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public DateTime Fecha { get; set; }
        public string Coordenadas { get; set; }

        public Estado Estado { get; set; }
        public Tipos Tipo_visita { get; set; }
        public Empresa Empresa { get; set; }
        public Tecnologia Tecnologia { get; set; }

        public Tecnico Tecnico { get; set; }


    }
}