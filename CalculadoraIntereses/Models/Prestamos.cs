using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalculadoraIntereses.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamoID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Plazo { get; set; }
        [Required]
        public double Interes { get; set; }
        [Required]
        public double CantidadPrestada { get; set; }

        public double Cuota { get; set; }
        [Required]
        public int IdCliente { get; set; }
    }
}