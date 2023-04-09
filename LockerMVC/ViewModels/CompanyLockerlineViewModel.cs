using System.ComponentModel.DataAnnotations;
using LockerMVC.Models;

namespace LockerMVC.ViewModels

{
    public class CompanyLockerlineViewModel
    {
        public string companyname { get; set; }

        public List<LockerlineModel> Lockerlines = new List<LockerlineModel>();

    }
}
