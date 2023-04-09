using System.ComponentModel.DataAnnotations;
using LockerMVC.Models;

namespace LockerMVC.ViewModels
{
    public class UsertypeUsergroupViewModel
        {
        public string name { get; set; }

        public string description { get; set; }

        public List<UsergroupModel> Usertypes = new List<UsergroupModel>();

    }
}
