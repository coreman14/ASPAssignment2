using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Reader
    {
        public int ID { get; set; }

        [Required, StringLength(30)]
        public required string Name { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
    }
}
