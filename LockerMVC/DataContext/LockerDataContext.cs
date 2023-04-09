using LockerMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LockerMVC.DataContext
{
    public class LockerDataContext :DbContext

    {
        public LockerDataContext(DbContextOptions<LockerDataContext> options) : base(options)
        {

        }

        public DbSet<LockereventModel> Lockerevent { get; set; }
        public DbSet<LockerlineModel> Lockerline { get; set; }
        public DbSet<LockertypeModel> Lockertype { get; set; }
        public DbSet<UsergroupModel> Usergroup { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<UsertypeModel> Usertype { get; set; }

        public DbSet<CompanyModel> Company { get; set; }
    }
}
