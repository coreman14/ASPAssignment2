using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class ReaderRepository
    {
        private readonly ApplicationDbContext _context;

        public ReaderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Reader> GetAll() => _context.Readers.OrderBy(r => r.ID).ToList();

        public IEnumerable<Reader> GetQuery(string includesText) => _context.Readers.Where((x) =>
            x.Email.ToLower().Contains(includesText.ToLower()) || x.Name.ToLower().Contains(includesText.ToLower())
        )
        .OrderBy(b => b.ID).ToList();
        public Reader? GetById(int id) => _context.Readers.FirstOrDefault(r => r.ID == id);
        public bool IdExist(int id) => _context.Readers.Any(r => r.ID == id);

        public Reader Create(Reader reader)
        {
            _context.Readers.Add(reader);
            _context.SaveChanges();
            return reader;
        }

        public bool Update(Reader reader)
        {
            var existing = GetById(reader.ID);
            if (existing is null)
            {
                return false;
            }

            existing.Name = reader.Name;
            existing.Email = reader.Email;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing is null)
            {
                return false;
            }

            _context.Readers.Remove(existing);
            _context.SaveChanges();
            return true;
        }
    }
}
