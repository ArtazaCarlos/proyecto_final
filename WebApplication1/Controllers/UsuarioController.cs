using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _repoUsuarios;
        public UsuarioController(IUsuarioRepositorio repoUsuarios) 
        {
            _repoUsuarios = repoUsuarios;
        }

        [HttpGet]
        [Route("/usuarios")]
        public IActionResult ListarUsuarios()
        {
            var usuariosVM = new List<UsuarioListarVM>(); 
            var usuarios = _repoUsuarios.obtenerUsuarios();

            foreach (var u in usuarios)
            {
                var usuarioMV = new UsuarioListarVM
                {
                    idUsuario = u.IdUsuario,
                    apellidos = u.Apellidos,
                    nombres = u.Nombres,
                    direccionCorreo = u.DireccionCorreo,
                    cuil = u.Cuil,
                    cargo = u.Cargo,
                    nombreUsuario = u.NombreUsuario,
                    bloqueado = u.Bloqueado,
                    ultimoAcceso = u.FechaHoraUltConectado
                };
                usuariosVM.Add(usuarioMV);
            }
            return View(usuariosVM);
        }

        /*
        // GET: UsuarioController/Details/5
        public ActionResult DetallesUsuario(int id)
        {
            var usuario = _repoUsuarios.obtenerUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: UsuarioController/Edit/5
        public ActionResult EditarUsuario(int id)
        {
            var usuario = _repoUsuarios.obtenerUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(int id, Usuario model)
        {
            if (id != model.idUsuario)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                _repoUsuarios.editarUsuario(model);
                return RedirectToAction(nameof(DetallesUsuario), new { id = model.idUsuario });
            }
            catch
            {
                return View(model);
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
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
        */
    }
}
