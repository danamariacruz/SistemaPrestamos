using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalculadoraIntereses.Models
{
    public class Cliente
    {  
        public int ClienteID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
    }
}