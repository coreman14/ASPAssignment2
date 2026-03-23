using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required, StringLength(30)]
        public required string Title { get; set; }

        [Required, StringLength(30)]
        public required string Author { get; set; }

        [Required, RegularExpression("^(?:ISBN(?:-13)?:?\\ )?(?=[0-9]{13}$|(?=(?:[0-9]+[-\\ ]){4})[-\\ 0-9]{17}$)97[89][-\\ ]?[0-9]{1,5}[-\\ ]?[0-9]+[-\\ ]?[0-9]+[-\\ ]?[0-9]$")]
        public required string IBSN { get; set; }

        [Required]
        public bool IsAvailable { get; set; } = true;
    }
}
