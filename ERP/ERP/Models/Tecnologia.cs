using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class Tecnologia
    {
        [Key]
        public int id_tecnologia { get; set; }
        public string nombre_tecnologia { get; set; }
    }
}