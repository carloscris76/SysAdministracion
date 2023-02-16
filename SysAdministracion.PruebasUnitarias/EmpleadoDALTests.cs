using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysAdministracion.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SysAdministracion.EntidadesDeNegocio;

namespace SysAdministracion.AccesoADatos.Tests
{
    [TestClass()]
    public class EmpleadoDALTests
    {
        private static Empleado empleadoInicial = new Empleado { Id = 10 };  // Agregar un id existente en la base de datos 
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var empleado = new Empleado();
            empleado.Nombre = "Maria";
            empleado.Apellido = "garcia";
            empleado.DUI = "0234567-9";
            empleado.Cargo = 1;
            empleado.Area = 2;
            int result = await EmpleadoDAL.CrearAsync(empleado);
            Assert.AreNotEqual(0, result);
            empleadoInicial.Id = empleado.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var empleado = new Empleado();
            empleado.Id = empleadoInicial.Id;
            empleado.Nombre = "Marisol";
            empleado.Apellido = "garcia";
            empleado.DUI = "0234567-9";
            empleado.Cargo = 2;
            empleado.Area = 3;
            int result = await EmpleadoDAL.ModificarAsync(empleado);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var empleado = new Empleado();
            empleado.Id = empleadoInicial.Id;
            var resultEmpleado = await EmpleadoDAL.ObtenerPorIdAsync(empleado);
            Assert.AreEqual(empleado.Id, resultEmpleado.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultEmpleado = await EmpleadoDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultEmpleado.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var empleado = new Empleado();
            empleado.Nombre = "M";
            empleado.Apellido = "g";
            empleado.Top_Aux = 10;
            var resultEmpleado = await EmpleadoDAL.BuscarAsync(empleado);
            Assert.AreNotEqual(0, resultEmpleado.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var empleado = new Empleado();
            empleado.Id = empleadoInicial.Id;
            int result = await EmpleadoDAL.EliminarAsync(empleado);
            Assert.AreNotEqual(0, result);
        }
    }
}