using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SysAdministracion.EntidadesDeNegocio;
using SysAdministracion.LogicaDeNegocio;
namespace SysAdministracion.UI.AppWebAspCore.Controllers
{
    public class EmpleadoController : Controller
    {
        EmpleadoBL empleadoBL = new EmpleadoBL();
        // GET: EmpleadoController
        public async Task<ActionResult> Index(Empleado pEmpleado = null)
        {
            if (pEmpleado ==null)
                pEmpleado = new Empleado();
            if (pEmpleado.Top_Aux == 0)
                pEmpleado.Top_Aux = 10;
            else if (pEmpleado.Top_Aux == -1)
                pEmpleado.Top_Aux = 0;
            var empleados = await empleadoBL.BuscarAsync(pEmpleado);
            ViewBag.Top = pEmpleado.Top_Aux;
            return View(empleados);
        }

        // GET: EmpleadoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var empleado = await empleadoBL.ObtenerPorIdAsync(new Empleado { Id= id });
            return View(empleado);
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        public async Task<ActionResult> Create(Empleado pEmpleado)
        {
            try
            {
                int result = await empleadoBL.CrearAsync(pEmpleado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pEmpleado);
            }
        }

        // GET: EmpleadoController/Edit/5
        public async Task<ActionResult> Edit(Empleado pEmpleado)
        {
            var empleado = await empleadoBL.ObtenerPorIdAsync(pEmpleado);
            ViewBag.Error = "";
            return View(empleado);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Empleado pEmpleado)
        {
            try
            {
                int result = await empleadoBL.ModificarAsync(pEmpleado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Empleados = await empleadoBL.ObtenerTodosAsync();
                return View(pEmpleado);
            }
        }

        // GET: EmpleadoController/Delete/5
        public async Task<ActionResult> Delete(Empleado pEmpleado)
        {
            ViewBag.Error = "";
            var empleado = await empleadoBL.ObtenerPorIdAsync(pEmpleado);
            return View(empleado);
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Empleado pEmpleado)
        {
            try
            {
                int result = await empleadoBL.EliminarAsync(pEmpleado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ViewBag.Error = ex.Message;
                var empleado = await empleadoBL.ObtenerPorIdAsync(pEmpleado);
                if (empleado == null)
                    empleado = new Empleado();
                if (empleado.Id > 0)
                    empleado = await empleadoBL.ObtenerPorIdAsync(new Empleado { Id = empleado.Id });
                    return View(pEmpleado);
            }
        }
    }
}
