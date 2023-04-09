using LockerMVC.Models;
using LockerMVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LockerMVC.Controllers
{
    public class LockerlinesController : Controller
    {
        private readonly LockerlinesRepository _repository;

        private readonly CompanysRepository _companysrepository;

        private readonly LockertypesRepository _lockertypesrepository;
        public LockerlinesController(LockerlinesRepository repository, CompanysRepository companysrepository, LockertypesRepository lockertypesrepository)
        {
            _repository = repository;
            _companysrepository = companysrepository;
            _lockertypesrepository = lockertypesrepository;
        }
        public IActionResult Index()
        {
            var model = _repository.GetLockerlines();
            return View("Index", model);
        }

        public ActionResult Create()
        {
            var companys = _companysrepository.GetCompanys();
            var lockertypes = _lockertypesrepository.GetLockertypes();
            ViewBag.data = companys;
            ViewBag.data6 = lockertypes;
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            LockerlineModel model = new LockerlineModel();          // se creaza un model nou pentru inserarea in baza de date
            TryUpdateModelAsync(model);                                 // mapeaza datele din colectie - formular - pe modelul creat local
            _repository.Add(model);                                     // se transmite modelul spre ORM


            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid id)
        {
            var model = _repository.GetLockerlineById(id);
            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(IFormCollection collection)
        {
            LockerlineModel model = new();
            TryUpdateModelAsync(model);
            _repository.Update(model);

            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            return View("Details", _repository.GetLockerlineById(id));
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var model = _repository.GetLockerlineById(id);
            return View("Delete", model);
            
        }

        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.DeleteLockerlineById(_repository.GetLockerlineById(id));
            return RedirectToAction("Index");

        }
    }
}
