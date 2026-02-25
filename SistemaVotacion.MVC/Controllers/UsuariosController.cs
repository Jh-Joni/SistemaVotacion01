using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVotacion.ApiConsumer;
using SistemaVotacion01;

namespace SistemaVotacion.MVC.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: UsuariosController
        public ActionResult Index()
        {
            var lista = Crud<Usuario>.GetAll();
            
            return View(lista);
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            CargarRoles();
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                Crud<Usuario>.Create(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                CargarRoles();
                return View(usuario);
            }
        }

        private void CargarRoles()
        {
            var roles = Crud<Rol>.GetAll();
            ViewBag.Roles = new SelectList(roles, "Id", "NombreRol");
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            var usuario = Crud<Usuario>.GetById(id);
            return View(usuario);
        }
    }
}
