using System.ComponentModel.DataAnnotations;
using LockerMVC.Models;

namespace LockerMVC.ViewModels
{
    public class UserUsergroupViewModel
    {
        public string? name { get; set; }

        public string? surname { get; set; }

        public List<UsergroupModel> Users = new List<UsergroupModel>();
    }
}
