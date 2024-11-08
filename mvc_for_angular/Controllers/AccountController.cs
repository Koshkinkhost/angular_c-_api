using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using mvc_for_angular.frontend.client_app.src.app.ViewModels;
using mvc_for_angular.models;
using nginx_project.models;
namespace mvc_for_angular.Controllers
{
    public class AccountController(nginx_project.models.AppContext _context) : Controller
    {
        
        private readonly nginx_project.models.AppContext context= _context;
        [HttpPost]
        public IResult Registration([FromBody]Registration model)
        {
            if (ModelState.IsValid)
            {
                return Results.Json(model);

            }

            List<string> errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            return Results.Json(new RegistrationResponse{ errors=errors,success=false});

        }
        // GET: Authentification
        public ActionResult Index( )
        {
            
            return View();
        }

        // GET: Authentification/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Authentification/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authentification/Create
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

        // GET: Authentification/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Authentification/Edit/5
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

        // GET: Authentification/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Authentification/Delete/5
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
