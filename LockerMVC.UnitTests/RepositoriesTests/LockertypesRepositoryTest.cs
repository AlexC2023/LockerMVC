using LockerMVC.DataContext;
using LockerMVC.Models;
using LockerMVC.Repositories;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LockerMVC.UnitTests.RepositoriesTests
{
    [TestClass]
    public class LockertypesRepositoryTest
    {
        private readonly LockertypesRepository _repository;
        private readonly LockerDataContext _contextInMemory;

        public LockertypesRepositoryTest()
        {
            _contextInMemory = Helpers.DBContextHelper.GetDatabaseContext();
            _repository = new LockertypesRepository(_contextInMemory);
        }

        [TestMethod]
        public void GetAllLockertypes_withDataInDB()
        {
            //Arrange -> vom crea niste Lockertypes fake
            LockertypeModel lockertype1 = new LockertypeModel
            {
                typeid = Guid.NewGuid(),
                name = "TEST",
                description = "Descriere",
                dateadded = new DateTime(2023, 04, 10),
             };

            LockertypeModel lockertype2 = new LockertypeModel
            {
                typeid = Guid.NewGuid(),
                name = "TEST2",
                description = "Descriere2",
                dateadded = new DateTime(2023, 04, 20),
            };

            List<LockertypeModel> list = new List<LockertypeModel>();
            list.Add(lockertype1);
            list.Add(lockertype2);
            Helpers.DBContextHelper.AddLockertype(_contextInMemory, lockertype1);
            Helpers.DBContextHelper.AddLockertype(_contextInMemory, lockertype2);

            //Act -> chemam metoda din repository
            List<LockertypeModel> dbLockertypes = _repository.GetLockertypes().ToList();

            //Assert -> verifica rezultatul 
            //Assert.AreEqual(2, list.Count);
            Assert.AreEqual(list.Count, dbLockertypes.Count);
        }

        [TestMethod]
        public void GetAllLockertypes_WithoutDataInDB()
        {
            List<LockertypeModel> dbLockertypes = _repository.GetLockertypes().ToList();
            Assert.AreEqual(0, dbLockertypes.Count);
        }

        [TestMethod]
        public void GetLockertypesById()
        {
            //Arrange -> vom crea niste announcements fake
            LockertypeModel lockertype1 = new LockertypeModel
            {
                typeid = Guid.NewGuid(),
                name = "TEST3",
                description = "Descriere3",
                dateadded = new DateTime(2023, 04, 12),
            };
            LockertypeModel lockertype = Helpers.DBContextHelper.AddLockertype(_contextInMemory, lockertype1);

            Guid id = (Guid)lockertype1.typeid;

            //Act -> chemam metoda din repository
            var result = _repository.GetLockertypeById(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(lockertype1.name, result.name);
            Assert.AreEqual(lockertype1.description, result.description);
            Assert.AreEqual(lockertype1.dateadded, result.dateadded);
           
        }

        [TestMethod]
        public void GetLockertypesById_WhenNotExists()
        {
            //Arrange 
            Guid id = Guid.NewGuid();

            //Act
            var result = _repository.GetLockertypeById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteLockertype_LockertypeNotExists()
        {
            //Arrange 
            Guid id = Guid.NewGuid();

            //Act
            _repository.Delete(id);
            var result = _repository.GetLockertypeById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteLockertype_LockertypeExists()
        {
            //Arrange -> vom crea niste announcements fake
            Guid id = Guid.NewGuid();
            LockertypeModel lockertype1 = new LockertypeModel
            {
                typeid = Guid.NewGuid(),
                name = "TEST3",
                description = "Descriere3",
                dateadded = new DateTime(2023, 04, 15),
            };
            LockertypeModel lockertype = Helpers.DBContextHelper.AddLockertype(_contextInMemory, lockertype1);

            //Act
            _repository.Delete(id);
            var result = _repository.GetLockertypeById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateLockertype_LockertypeExist()
        {
            LockertypeModel lockertype1 = new LockertypeModel
            {
                typeid = Guid.NewGuid(),
                name = "TEST3",
                description = "Descriere3",
                dateadded = new DateTime(2023, 04, 15),
            };
            LockertypeModel lockertype = Helpers.DBContextHelper.AddLockertype(_contextInMemory, lockertype1);
            lockertype.name = "nameUpdated";
            _repository.Update(lockertype);

            LockertypeModel updatedModel = _repository.GetLockertypeById((Guid)lockertype1.typeid);

            Assert.IsNotNull(updatedModel);
          
        }


        //    [TestMethod]
        //    //public void GetAllAnnouncements()
        //    //{
        //        //Arrange
        //        //AnnouncementModel announcement2 = new AnnouncementModel
        //        //{
        //        //    IdAnnouncement = Guid.NewGuid(),
        //        //    ValidFrom = new DateTime(2023, 10, 10),
        //        //    ValidTo = new DateTime(2023, 10, 10),
        //        //    EventDate = new DateTime(2023, 11, 11),
        //        //    ActivityTagsCollection = "tags1",
        //        //    TextReader = "Announcement",
        //        //    AssemblyTitleAttribute = "Event1",
        //        //};

        //        //List<AnnouncementModel> list = new List<AnnouncementModel>
        //        //Act

        //        //Assert
        //    //}

    }
}
