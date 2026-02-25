using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVotacion.ApiConsumer;
using SistemaVotacion01;

namespace SistemaVotacion.MVC.Controllers
{
    public class RolesController : Controller
    {
        // GET: RolesController
        public ActionResult Index()
        {
            var lista = Crud<Rol>.GetAll();
            return View(lista);
        }

       // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rol rol)
        {
            try
            {
                Crud<Rol>.Create(rol);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Index", Crud<Rol>.GetAll());
            }
        }

        // GET: RolesController/Edit/5
        public ActionResult Edit(int id)
        {
            var rol = Crud<Rol>.GetById(id);
            return View(rol);
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Rol rol)
        {
            Crud<Rol>.Update(id, rol);
            return RedirectToAction(nameof(Index));
        }
    }
}
