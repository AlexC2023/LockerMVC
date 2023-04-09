using LockerMVC.Models;
using LockerMVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LockerMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersRepository _repository;

        public UsersController(UsersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = _repository.GetAll();
            return View("Index", user);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            var model = new UserModel();
            TryUpdateModelAsync(model);
            _repository.AddUser(model);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var user = _repository.GetUserById(id);
            return View("Edit", user);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            var updatedUser = new UserModel();
            TryUpdateModelAsync(updatedUser);

            _repository.UpdateUser(id, updatedUser);

            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            return View("Details", _repository.GetUserById(id));
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var model = _repository.GetUserById(id);
            return View("Delete", model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.DeleteUserById(_repository.GetUserById(id));
            return RedirectToAction("Index");
        }


    }
}
