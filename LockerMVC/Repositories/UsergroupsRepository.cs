using LockerMVC.DataContext;
using LockerMVC.Models;
using LockerMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LockerMVC.Repositories
{
    public class UsergroupsRepository
    {
        // clasele de tip repository sunt clase care implementeaza operatiile CRUD pe Baza de date

        private readonly LockerDataContext _context;

        public UsergroupsRepository(LockerDataContext context)
        {
            _context = context;
        }

        public DbSet<UsergroupModel> GetUsergroups()
        {
            return _context.Usergroup;
        }

        public void AddUsergroup(UsergroupModel model)
        {
            model.groupid = Guid.NewGuid();
            _context.Usergroup.Add(model);
            _context.SaveChanges();
        }

        public UsergroupModel GetUsergroupById(Guid id)
        {
            UsergroupModel model = _context.Usergroup.FirstOrDefault(a => a.groupid == id);
            return model;
        }

        public void Update(UsergroupModel model)
        {
            _context.Usergroup.Update(model);
            _context.SaveChanges();
        }

        public void Delete(UsergroupModel userq)
        {
            //var userg = _context.Usergroup.FirstOrDefault(a => a.groupid == id);
            _context.Usergroup.Remove(userq);
            _context.SaveChanges();
        }

        public CompanyLockerlineViewModel GetCompanyLockerline(Guid id)
        {
            CompanyLockerlineViewModel modelLockerlineViewModel = new CompanyLockerlineViewModel();
            UsergroupModel model = _context.Usergroup.FirstOrDefault(x => x.groupid == id);
            if (model != null)
            {
                modelLockerlineViewModel.companyname = model.rolename;
               
               
                IQueryable<LockerlineModel> modelLockerlines = _context.Lockerline.Where(x => x.companyid == id); //atunci cand dorim sa facem increase
                                                                                                                      //la performanta daca ne e permis

                foreach (LockerlineModel dbLockerline in modelLockerlines)
                {
                    modelLockerlineViewModel.Lockerlines.Add(dbLockerline);
                }

            }
            return modelLockerlineViewModel;
        }

    }
}
