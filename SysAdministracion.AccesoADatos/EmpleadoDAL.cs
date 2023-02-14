using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SysAdministracion.EntidadesDeNegocio;
namespace SysAdministracion.AccesoADatos
{
    public class EmpleadoDAL
    {
        public static async Task<int> CrearAsync(Empleado pEmpleado)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pEmpleado);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Empleado pEmpleado)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var empleado = await bdContexto.Empleado.FirstOrDefaultAsync(s => s.Id == pEmpleado.Id);
                Empleado pempleado = new Empleado();
                empleado.Nombre = pEmpleado.Nombre;
                empleado.Apellido = pEmpleado.Apellido;
                empleado.DUI = pEmpleado.DUI;
                empleado.Area = pEmpleado.Area;
                empleado.Cargo = pEmpleado.Cargo;
                bdContexto.Update(empleado);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Empleado pEmpleado)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var empleado = await bdContexto.Empleado.FirstOrDefaultAsync(s => s.Id == pEmpleado.Id);
                bdContexto.Empleado.Remove(empleado);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Empleado> ObtenerPorIdAsync(Empleado pEmpleado)
        {
            var empleado = new Empleado();
            using (var bdContexto = new BDContexto())
            {
                empleado = await bdContexto.Empleado.FirstOrDefaultAsync(s => s.Id == pEmpleado.Id);
            }
            return empleado;
        }
        public static async Task<List<Empleado>> ObtenerTodosAsync()
        {
            var empleados = new List<Empleado>();
            using (var bdContexto = new BDContexto())
            {
                empleados = await bdContexto.Empleado.ToListAsync();
            }
            return empleados;
        }
        internal static IQueryable<Empleado> QuerySelect(IQueryable<Empleado> pQuery, Empleado pEmpleado)
        {
            if (pEmpleado.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pEmpleado.Id);
            if (!string.IsNullOrWhiteSpace(pEmpleado.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pEmpleado.Nombre));
            if (!string.IsNullOrWhiteSpace(pEmpleado.Apellido))
                pQuery = pQuery.Where(s =>s.Apellido.Contains(pEmpleado.Apellido));
            if (!string.IsNullOrWhiteSpace(pEmpleado.DUI))
                pQuery = pQuery.Where(s =>s.DUI.Contains(pEmpleado.DUI));
            if (pEmpleado.Area > 0)
                pQuery = pQuery.Where(s => s.Area == pEmpleado.Area);
            if (pEmpleado.Cargo > 0)
                pQuery = pQuery.Where((s) => s.Cargo == pEmpleado.Cargo);
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pEmpleado.Top_Aux > 0)
                pQuery = pQuery.Take(pEmpleado.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Empleado>> BuscarAsync(Empleado pEmpleado)
        {
            var empleados = new List<Empleado>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Empleado.AsQueryable();
                select = QuerySelect(select, pEmpleado);
                empleados = await select.ToListAsync();
            }
            return empleados;
        }
    }
}
