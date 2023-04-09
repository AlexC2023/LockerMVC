using LockerMVC.Models;
using LockerMVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LockerMVC.Controllers
{
    public class LockertypesController : Controller
    {
        private readonly LockertypesRepository _repository;

        public LockertypesController(LockertypesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = _repository.GetLockertypes();
            return View("Index", user);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            var model = new LockertypeModel();
            TryUpdateModelAsync(model);
            _repository.AddLockertype(model);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var user = _repository.GetLockertypeById(id);
            return View("Edit", user);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            var updatedmodel = new LockertypeModel();
            TryUpdateModelAsync(updatedmodel);

            _repository.UpdateLockertype(id, updatedmodel);

            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            return View("Details", _repository.GetLockertypeById(id));
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var model = _repository.GetLockertypeById(id);
            return View("Delete", model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.DeleteLockertypeId(_repository.GetLockertypeById(id));
            return RedirectToAction("Index");
        }
    }
}
