using System.ComponentModel.DataAnnotations;
using LockerMVC.Models;

namespace LockerMVC.ViewModels
{
     

        public class LockertypeLockerlineViewModel
        {
            public string name { get; set; }

            public List<LockerlineModel> Lockerlines = new List<LockerlineModel>();

        }
   

}

