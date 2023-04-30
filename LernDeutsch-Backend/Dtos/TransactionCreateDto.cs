using LernDeutsch_Backend.Models.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Dtos
{
    public class TransactionCreateDto
    {
        [Required]
        public TransactionType TransactionType { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public Guid BoughtById { get; set; }
        [Required]
        public Guid CourseId { get; set; }
    }
}
