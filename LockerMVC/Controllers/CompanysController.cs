using LockerMVC.Models;
using LockerMVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LockerMVC.Controllers
{
    public class CompanysController : Controller
    {
        private readonly CompanysRepository _repository;

        public CompanysController(CompanysRepository repository)
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
            var model = new CompanyModel();
            TryUpdateModelAsync(model);
            _repository.AddCompany(model);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var company = _repository.GetCompanyById(id);
            return View("Edit", company);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            var updatedCompany = new CompanyModel();
            TryUpdateModelAsync(updatedCompany);

            _repository.UpdateCompany(id, updatedCompany);

            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            return View("Details", _repository.GetCompanyById(id));
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var model = _repository.GetCompanyById(id);
            return View("Delete", model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.DeleteCompanyById(_repository.GetCompanyById(id));
            return RedirectToAction("Index");
        }
    }
}
