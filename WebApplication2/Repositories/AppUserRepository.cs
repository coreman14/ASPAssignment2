using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public static class AppUserRepository
    {
        private static readonly List<AppUser> _users =
        [
            new AppUser { ID = 1, Name = "Admin", Username = "Admin", Email = "admin@lms.local", Password = "admin123" },
            new AppUser { ID = 2, Name = "Dave", Username = "d3po", Email = "d@wwwss.local", Password = "admin123" },
        ];

        public static AppUser? GetByEmail(string email) =>
            _users.FirstOrDefault(u => string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase));

        public static AppUser Create(AppUser user)
        {
            var _nextId = _users.Count > 0 ? _users.Max((x) => x.ID) + 1 : 1;
            user.ID = _nextId++;
            _users.Add(user);
            return user;
        }

        public static bool ValidateCredentials(string email, string password)
        {
            var user = GetByEmail(email);
            return user is not null && user.Password == password;
        }
    }
}
