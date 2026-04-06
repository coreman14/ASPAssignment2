using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class BorrowingRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly BookRepository _books;
        private readonly ReaderRepository _readers;

        public BorrowingRepository(ApplicationDbContext context, ReaderRepository readers, BookRepository books)
        {
            _context = context;
            _books = books;
            _readers = readers;
        }

        public IEnumerable<Borrowing> GetAll() => _context.Borrowings.OrderBy(b => b.ID).ToList();

        public IEnumerable<Borrowing> GetQuery(string includesText){
            var bookIds = _books.GetQuery(includesText).Select((x) => x.ID);
            var readerIds = _readers.GetQuery(includesText).Select((x) => x.ID);
            return _context.Borrowings.Where((x) =>
                bookIds.Contains(x.BookId) || readerIds.Contains(x.ReaderId)
            )
            .OrderBy(b => b.ID).ToList();
            
        } 
        public Borrowing? GetById(int id) => _context.Borrowings.FirstOrDefault(b => b.ID == id);

        public Borrowing Create(Borrowing borrowing)
        {
            _context.Borrowings.Add(borrowing);
            _context.SaveChanges();
            return borrowing;
        }

        public bool Update(Borrowing borrowing)
        {
            var existing = GetById(borrowing.ID);
            if (existing is null)
            {
                return false;
            }

            existing.BookId = borrowing.BookId;
            existing.ReaderId = borrowing.ReaderId;
            existing.DaysToBorrow = borrowing.DaysToBorrow;
            existing.BorrowedDate = borrowing.BorrowedDate;
            existing.ReturnedDate = borrowing.ReturnedDate;
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

            _context.Borrowings.Remove(existing);
            _context.SaveChanges();
            return true;
        }
    }
}
