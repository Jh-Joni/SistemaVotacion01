using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
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
                return View(usuario);
            }
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            var usuario = Crud<Usuario>.GetById(id);
            return View(usuario);
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
