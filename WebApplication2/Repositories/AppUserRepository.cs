using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class AppUserRepository
    {
        private readonly ApplicationDbContext _context;

        public AppUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public AppUser? GetByEmail(string email) =>
            _context.AppUsers.FirstOrDefault(u => string.Equals(u.Email, email));

        public AppUser Create(AppUser user)
        {
            _context.AppUsers.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool ValidateCredentials(string email, string password)
        {
            var user = GetByEmail(email);
            return user is not null && user.Password == password;
        }
    }
}
