using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LockerMVC.Controllers
{
    public class LockereventsController : Controller
    {
        // GET: LockereventsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LockereventsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LockereventsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LockereventsController/Create
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

        // GET: LockereventsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LockereventsController/Edit/5
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

        // GET: LockereventsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LockereventsController/Delete/5
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
