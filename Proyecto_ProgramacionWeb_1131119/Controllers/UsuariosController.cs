using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_ProgramacionWeb_1131119.Models;
using System.Linq;

namespace Proyecto_ProgramacionWeb_1131119.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly dbHospital _dbhospital;
        // GET: UsuariosController
        public ActionResult Index()
        {
            var usuarios = _dbhospital.Usuarios.ToList();
            return View(usuarios);
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _dbhospital.Usuarios.Add(usuario);
                _dbhospital.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            var usuario = _dbhospital.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dbhospital.Update(usuario);
                _dbhospital.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            var usuario = _dbhospital.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            _dbhospital.Usuarios.Remove(usuario);
            _dbhospital.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
