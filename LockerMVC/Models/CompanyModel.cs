using System.ComponentModel.DataAnnotations;
namespace LockerMVC.Models
{
    public class CompanyModel
    {
        [Key]
        public Guid? companyid { get; set; }

        public string? companyname { get; set; }

        public string? companyemail { get; set; }

        public string? companycui { get; set; }

        public DateTime? dateadded { get; set; }
        public bool active { get; set; }
    }
}
