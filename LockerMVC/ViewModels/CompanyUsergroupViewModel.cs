using LockerMVC.Models;

namespace LockerMVC.ViewModels
{
    public class CompanyUsergroupViewModel
    {
        public string? companyname { get; set; }

        public string? companyemail { get; set; }

        public string? companycui { get; set; }

        public List<UsergroupModel> Companys = new List<UsergroupModel>();
    }
}
