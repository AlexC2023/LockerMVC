using LockerMVC.DataContext;
using LockerMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerMVC.UnitTests.Helpers
{
    public class DBContextHelper
    {
        public static LockerDataContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<LockerDataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            var databaseContext = new LockerDataContext(options);
            databaseContext.Database.EnsureCreated();
            return databaseContext;
        }

        public static LockertypeModel AddLockertype(LockerDataContext context, LockertypeModel lockertype)
        {
            context.Add(lockertype);
            context.SaveChangesAsync();
            context.Entry(lockertype).State = EntityState.Detached;
            return lockertype;
        }
    }
}
