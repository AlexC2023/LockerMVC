using LockerMVC.Models;
using LockerMVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LockerMVC.ViewModels;

namespace LockerMVC.Controllers
{
    public class UsergroupsController : Controller
    {
        private readonly UsergroupsRepository _repository;
        private readonly UsersRepository _usersrepository;
        private readonly UsertypesRepository _usertypesrepository;
        private readonly CompanysRepository _companysrepository;
        public UsergroupsController(UsergroupsRepository repository, UsersRepository usersrepository, UsertypesRepository usertypesrepository, CompanysRepository companysrepository)
        {
            _repository = repository;
            _usersrepository = usersrepository;
            _usertypesrepository = usertypesrepository;
            _companysrepository = companysrepository;

        }

        //public UsergroupsController(UsergroupsRepository repository)
        //{
        //    _repository = repository;
        //}

        public IActionResult Index()
        {
            var model = _repository.GetUsergroups();
            return View("Index", model);
        }

        public IActionResult Create()
        {
            var usertype = _usertypesrepository.GetAllUsertypes();
            var user = _usersrepository.GetUsers();
            var company = _companysrepository.GetCompanys();
            ViewBag.data1 = user;
            ViewBag.data2 = usertype;
            ViewBag.data4 = company;
            return View("Create");
        }

        //public IActionResult Create()
        //{
        //    return View("Create");
        //}

        [HttpPost]
        public IActionResult Create(IFormCollection usergroups)
        {
            UsergroupModel model = new UsergroupModel();
            TryUpdateModelAsync(model);
            _repository.AddUsergroup(model);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            //return View("Edit", _repository.GetUsergroupById(id));
            var usertype = _usertypesrepository.GetAllUsertypes();
            var company = _companysrepository.GetCompanys();
            ViewBag.data3 = usertype;            
            ViewBag.data5 = company;
            return View("Edit", _repository.GetUsergroupById(id));
        }

        [HttpPost]
        public IActionResult Edit(IFormCollection collection)
        {
            UsergroupModel model = new UsergroupModel();
            TryUpdateModelAsync(model);
            _repository.Update(model);


            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            return View("Details", _repository.GetUsergroupById(id));
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var model = _repository.GetUsergroupById(id);
            return View("Delete", model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
           _repository.Delete(_repository.GetUsergroupById(id));
            return RedirectToAction("Index");
        }

        //public IActionResult DetailsWithLockerlines(Guid id)
        //{
        //    UsergroupLockerlineViewModel viewModel = _repository.GetUsergroupLockerline(id);
        //    return View("DetailsWithLockerlines", viewModel);
        //}
    }
}
