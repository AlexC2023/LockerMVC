using LockerMVC.DataContext;
using LockerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LockerMVC.Repositories
{
    public class LockertypesRepository
    {
        private readonly LockerDataContext _context;

        public LockertypesRepository(LockerDataContext context)
        {
            _context = context;
        }

        public DbSet<LockertypeModel> GetLockertypes()
        {
            return _context.Lockertype;
        }

        public DbSet<LockertypeModel> GetAll()
        {
            return _context.Lockertype;
        }

        public void AddLockertype(LockertypeModel model)
        {
            
            _context.Lockertype.Add(model);
            _context.SaveChanges();
        }

        public LockertypeModel GetLockertypeById(Guid id)
        {
            return _context.Lockertype.FirstOrDefault(a => a.typeid == id);
        }

        public void UpdateLockertype(Guid id, LockertypeModel model)
        {
            _context.Lockertype.Update(model);
            _context.SaveChanges();
        }
        public void Update(LockertypeModel model)
        {
            LockertypeModel lockertype = GetLockertypeById(model.typeid);
            if (lockertype != null)
            {
                _context.Lockertype.Update(model);
                _context.SaveChanges();
            }

        }


        public void DeleteLockertypeId(LockertypeModel model)
        {
          
            _context.Lockertype.Remove(model);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            LockertypeModel lockertype = GetLockertypeById(id);
            if (lockertype != null)
            {
                _context.Lockertype.Remove(lockertype);
                _context.SaveChanges();
            }

        }

    }
}
