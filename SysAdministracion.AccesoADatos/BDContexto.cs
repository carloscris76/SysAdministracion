using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SysAdministracion.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
namespace SysAdministracion.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Empleado> Empleado { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");
        }
    }
}
