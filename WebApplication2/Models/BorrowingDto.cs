using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class BorrowingDto
    {
        
        public required int ID { get; set; }
        public required int BookId { get; set; }
        public required string BookName { get; set; }
        public required int ReaderId { get; set; }
        public required string ReaderName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public required DateTime BorrowedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public required DateTime LastDate { get; set; }
        public required bool IsReturned { get; set; }
    }
}
