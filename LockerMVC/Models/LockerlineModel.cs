using System.ComponentModel.DataAnnotations;
namespace LockerMVC.Models
{
    
    public class LockerlineModel
    {
        [Key]

        public Guid dataid { get; set; }

        public Guid? companyid { get; set; }
        public Guid? typeid { get; set; }
        public string? appname { get; set; }

        public string? usern { get; set; }

        public string? pass { get; set; }

        public string? details { get; set; }

        public DateTime? dateadded { get; set; }

        public bool active { get; set; }

    }
}
