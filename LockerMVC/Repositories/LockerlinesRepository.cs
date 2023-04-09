using LockerMVC.DataContext;
using LockerMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LockerMVC.Repositories
{
    public class LockerlinesRepository
    {
        // clasele de tip repository sunt clase care implementeaza operatiile CRUD pe Baza de date

        private readonly LockerDataContext _context;

        public LockerlinesRepository(LockerDataContext context)
        {
            _context = context;
        }


        // metoda echivalenta Get
        public DbSet<LockerlineModel> GetLockerlines()
        {
            return _context.Lockerline;
        }

        public void Add(LockerlineModel model)
        {
            model.dataid = Guid.NewGuid();  //setam id-ul
            _context.Lockerline.Add(model);      // adaugam modelul in layerul ORM
            _context.SaveChanges();                 // commit to database
        }


        public LockerlineModel GetLockerlineById(Guid id)
        {
            LockerlineModel model = _context.Lockerline.FirstOrDefault(a => a.dataid == id);
            return model;
        }


        public void Update(LockerlineModel model)
        {
            _context.Lockerline.Update(model);
            _context.SaveChanges();
        }

        public void DeleteLockerlineById(LockerlineModel model)
        {
            _context.Lockerline.Remove(model);
            _context.SaveChanges();
        }

    }
}
