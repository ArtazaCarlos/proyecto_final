using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;
using Data.Entities;

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
        */

        // GET: UsuarioController/Create
        public ActionResult CrearUsuario()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearUsuario(UsuarioCrearVM usuarioCrearMV)
        {
            if (!ModelState.IsValid)
            {
                return View(usuarioCrearMV);
            }
            if (usuarioCrearMV == null)
            {
                return BadRequest();
            }
            var usuarioEntity = new UsuarioEntity
            {
                Apellidos = usuarioCrearMV.Apellidos,
                Nombres = usuarioCrearMV.Nombres,
                Cuil = usuarioCrearMV.Cuil,
                DireccionCorreo = usuarioCrearMV.DireccionCorreo,
                Contrasena = usuarioCrearMV.Contrasena
            };
            _repoUsuarios.crearUsuario(usuarioEntity);

            try
            {
                return RedirectToAction(nameof(ListarUsuarios));
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

            var usuarioMV = new UsuarioEditarVM
            {
                idUsuario = usuario.IdUsuario,
                apellidos = usuario.Apellidos,
                nombres = usuario.Nombres,
                cuil = usuario.Cuil,
                direccionCorreo = usuario.DireccionCorreo,
                bloqueado = usuario.Bloqueado
            };
            
            
            return View(usuarioMV);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(int id, UsuarioEditarVM model)
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
                var usuaarioEntity = new UsuarioEntity
                {
                    IdUsuario = model.idUsuario,
                    Apellidos = model.apellidos,
                    Nombres = model.nombres,
                    Cuil = model.cuil,
                    DireccionCorreo = model.direccionCorreo,
                    Bloqueado = model.bloqueado
                };

                _repoUsuarios.editarUsuario(usuaarioEntity);
                return RedirectToAction(nameof(ListarUsuarios));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult EliminiarUsuario(int id)
        {
            var usuario = _repoUsuarios.obtenerUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            var usuarioMV = new UsuarioListarVM
            {
                idUsuario = usuario.IdUsuario,
                apellidos = usuario.Apellidos,
                nombres = usuario.Nombres,
                direccionCorreo = usuario.DireccionCorreo,
                cuil = usuario.Cuil,
                cargo = usuario.Cargo,
                nombreUsuario = usuario.NombreUsuario,
                bloqueado = usuario.Bloqueado,
                ultimoAcceso = usuario.FechaHoraUltConectado
            };
            return View(usuarioMV);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminiarUsuario(int id, UsuarioListarVM usuarioVM)
        {
            if (id != usuarioVM.idUsuario)
            {
                return BadRequest();
            }
            
            try
            {
                _repoUsuarios.eliminarUsuario(id);
                return RedirectToAction(nameof(ListarUsuarios));
            }
            catch
            {
                return View();
            }
        }
        
    }
}
