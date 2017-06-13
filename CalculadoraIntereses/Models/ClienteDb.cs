using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CalculadoraIntereses.Models
{
    public class ClienteDb: DbContext 
    {
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Prestar> prestar { get; set; }
    }
}