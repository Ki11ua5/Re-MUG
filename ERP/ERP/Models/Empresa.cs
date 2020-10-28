using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }
        public string NombreEmp { get; set; }
       

    }
}