using System.ComponentModel.DataAnnotations;
namespace LockerMVC.Models
{
    public class LockertypeModel
    {
        [Key]
        
        public Guid typeid { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public DateTime dateadded { get; set; }
    }
}
