using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class BookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Book> GetAll() => _context.Books.OrderBy(b => b.ID).ToList();

        public IEnumerable<Book> GetQuery(string includesText) => _context.Books.Where((x) =>
            x.Author.ToLower().Contains(includesText.ToLower()) || x.IBSN.ToLower().Contains(includesText.ToLower()) || x.Title.ToLower().Contains(includesText.ToLower())
        )
        .OrderBy(b => b.ID).ToList();

        public Book? GetById(int id) => _context.Books.FirstOrDefault(b => b.ID == id);
        public bool IdExist(int id) => _context.Books.Any(r => r.ID == id);

        public Book Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public bool Update(Book book)
        {
            var existing = GetById(book.ID);
            if (existing is null)
            {
                return false;
            }

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.IBSN = book.IBSN;
            existing.IsAvailable = book.IsAvailable;
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

            _context.Books.Remove(existing);
            _context.SaveChanges();
            return true;
        }

    }
}
