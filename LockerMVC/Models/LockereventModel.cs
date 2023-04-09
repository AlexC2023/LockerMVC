using System.ComponentModel.DataAnnotations;
namespace LockerMVC.Models
{
    public class LockereventModel
    {
        [Key]

        public Guid historyid { get; set; }

        public string eventline { get; set; }

        public Guid userid { get; set; }

        public string newvalue { get; set; }    

        public string oldvalue { get; set; }

        public DateTime eventdate { get; set; } 

    }
}
