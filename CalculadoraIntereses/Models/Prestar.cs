using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalculadoraIntereses.Models
{
    public class Prestar
    {
        [Key]
        public int PrestamoID { get; set; }
        [Required]
        public int Plazo { get; set; }
        [Required]
        public double Interes { get; set; }
        [Required]
        public double CantidadPrestada { get; set; }

        public double Cuota { get; set; }

        [DataType(DataType.Date)]
        public DateTime IniciodePrestamo { get; set; }

        [Required]
        public int IdCliente { get; set; }

    }
}