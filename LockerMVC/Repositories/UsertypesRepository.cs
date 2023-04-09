using LockerMVC.DataContext;
using LockerMVC.Models;
using LockerMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LockerMVC.Repositories
{
    public class UsertypesRepository
    {
        private readonly LockerDataContext _context;

        public UsertypesRepository(LockerDataContext context) => _context = context;

        public DbSet<UsertypeModel> GetAllUsertypes()
        {
            return _context.Usertype;
        }

        public DbSet<UsertypeModel> GetAll()
        {
            return _context.Usertype;
        }

        internal void AddUsertype(UsertypeModel model)
        {
            _context.Usertype.Add(model);
            _context.SaveChanges();
        }

        public UsertypeModel FindById(Guid id)
        {
            return _context.Usertype.FirstOrDefault(a => a.usertypeid == id);
        }

        internal void UpdateUsertype(Guid id, UsertypeModel model)
        {
            _context.Usertype.Update(model);
            _context.SaveChanges();
        }

        public void DeleteUserType(UsertypeModel model)
        {
            _context.Usertype.Remove(model);
            _context.SaveChanges();
        }
        public UsertypeUsergroupViewModel GetUsertypeUsergroup(Guid id)
        {
            UsertypeUsergroupViewModel modelUsergroupViewModel = new UsertypeUsergroupViewModel();
            UsertypeModel model = _context.Usertype.FirstOrDefault(x => x.usertypeid == id);
            if (model != null)
            {
                modelUsergroupViewModel.name = model.name;
                modelUsergroupViewModel.description = model.description;

                IQueryable<UsergroupModel> modelUsergroups = _context.Usergroup.Where(x => x.usertypeid == id); //atunci cand dorim sa facem increase
                                                                                                            //la performanta daca ne e permis

                foreach (UsergroupModel dbUsergroup in modelUsergroups)
                {
                    modelUsergroupViewModel.Usertypes.Add(dbUsergroup);
                }

            }
            return modelUsergroupViewModel;
        }

    }
}
