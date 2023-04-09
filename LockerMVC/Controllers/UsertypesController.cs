using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LockerMVC.Models;
using LockerMVC.Repositories;

namespace LockerMVC.Controllers
{
    public class UsertypesController : Controller
    {
        private readonly UsertypesRepository _repository;

        public UsertypesController(UsertypesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var usertypes = _repository.GetAll();
            return View("Index", usertypes);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            var model = new UsertypeModel();
            TryUpdateModelAsync(model);
            _repository.AddUsertype(model);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var usertype = _repository.FindById(id);
            return View("Edit", usertype);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            var updatedUsertype = new UsertypeModel();
            TryUpdateModelAsync(updatedUsertype);

            _repository.UpdateUsertype(id, updatedUsertype);

            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            return View("Details", _repository.FindById(id));
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var model = _repository.FindById(id);
            return View("Delete", model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.DeleteUserType(_repository.FindById(id));
            return RedirectToAction("Index");
        }
    }
}
