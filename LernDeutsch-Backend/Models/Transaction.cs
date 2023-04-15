using System.ComponentModel.DataAnnotations;
using LernDeutsch_Backend.Models.Enumerations;

namespace LernDeutsch_Backend.Models
{
    public class Transaction
    {

        [Key]
        public Guid id { get; set; }
        [Required]
        public BaseUser boughtBy { get; set; }
        [Required]
        public Course course { get; set; }
        [Required]
        public TransactionStatus transactionStatus { get; set; } = TransactionStatus.Pending;
        [Required]
        public TransactionType transactionType { get; set; }
        [Required]
        public int amount { get; set; }

    }
}
