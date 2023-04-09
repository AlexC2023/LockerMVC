using System.ComponentModel.DataAnnotations;
namespace LockerMVC.Models
{
    public class UsertypeModel
    {
        [Key]

        public Guid usertypeid { get; set; }
        public string name { get; set; } 

        public string description { get; set; }
    }
}
