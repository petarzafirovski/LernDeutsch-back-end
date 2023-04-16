using System.ComponentModel.DataAnnotations;
using LernDeutsch_Backend.Models.Enumerations;
using LernDeutsch_Backend.Models.Identity;

namespace LernDeutsch_Backend.Models
{
    public class Transaction
    {

        [Key]
        public Guid id { get; set; }
        [Required]
        public TransactionStatus TransactionStatus { get; set; } = TransactionStatus.Pending;
        [Required]
        public TransactionType TransactionType { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public BaseUser BoughtBy { get; set; }

        [Required]
        public Course Course { get; set; }


    }
}
