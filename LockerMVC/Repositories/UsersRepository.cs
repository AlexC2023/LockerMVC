using LockerMVC.DataContext;
using LockerMVC.Models;
using LockerMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LockerMVC.Repositories
{
    public class UsersRepository
    {
        private readonly LockerDataContext _context;

        public UsersRepository(LockerDataContext context)
        {
            _context = context;
        }

        public DbSet<UserModel> GetUsers()
        {
            return _context.User;
        }

        public DbSet<UserModel> GetAll()
        {
            return _context.User;
        }

        public void AddUser(UserModel model)
        {
            //model.userid = Guid.NewGuid();
            _context.User.Add(model);
            _context.SaveChanges();
        }

        public UserModel GetUserById(Guid id)
        {
            return _context.User.FirstOrDefault(a => a.userid == id);
        }

        public void UpdateUser(Guid id,UserModel model)
        {
            _context.User.Update(model);
            _context.SaveChanges();
        }

        public void DeleteUserById(UserModel model)
        {
            //var model = _context.User.FirstOrDefault(a => a.userid == id);
            _context.User.Remove(model);
            _context.SaveChanges();
        }
        public UserUsergroupViewModel GetUserUsergroup(Guid id)
        {
            UserUsergroupViewModel modelUsergroupViewModel = new UserUsergroupViewModel();
           UserModel model = _context.User.FirstOrDefault(x => x.userid == id);
            if (model != null)
            {
                modelUsergroupViewModel.name = model.name;
                modelUsergroupViewModel.surname = model.surname;

                IQueryable<UsergroupModel> modelUsergroups = _context.Usergroup.Where(x => x.userid == id); //atunci cand dorim sa facem increase
                                                                                                                //la performanta daca ne e permis

                foreach (UsergroupModel dbUsergroup in modelUsergroups)
                {
                    modelUsergroupViewModel.Users.Add(dbUsergroup);
                }

            }
            return modelUsergroupViewModel;
        }

    }
}
