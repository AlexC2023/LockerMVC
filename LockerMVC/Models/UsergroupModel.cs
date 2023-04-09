using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LockerMVC.Models
{
    public class UsergroupModel
    {
        [Key]
        public Guid groupid { get; set; }

        public Guid userid { get; set; }

        public  Guid usertypeid { get; set; }

        public DateTime startdate { get; set; }

        public Guid companyid { get; set; }

        public string rolename { get; set; }

    }
}
