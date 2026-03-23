using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class AppUser
    {
        public int ID { get; set; }

        [Required, StringLength(30)]
        public required string Name { get; set; }
        [Required, StringLength(15)]
        public required string Username { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
