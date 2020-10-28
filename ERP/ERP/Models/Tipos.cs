using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class Tipos
    {
        [Key]
        public int id_visita { get; set; }
        public string nombre { get; set; }
    }
}