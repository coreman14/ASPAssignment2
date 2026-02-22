using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Borrowing
    {
        
        public int ID { get; set; }
        [Required]
        public required int BookId { get; set; }
        [Required]
        public required int ReaderId { get; set; }
        [Required]
        public int DaysToBorrow { get; set; } = 7;
        [DataType(DataType.Date), Required]
        public required DateTime BorrowedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReturnedDate { get; set; } = null;
        public bool IsReturned { get => ReturnedDate != null; }
    }
}
