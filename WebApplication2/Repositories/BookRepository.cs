using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public static class BookRepository
    {
        private static readonly List<Book> _books =
        [
            new() {
                Title = "The little Mermaid",
                Author = "Someone",
                IBSN = "20",
                ID = 1,
                IsAvailable = false
            },
            new() {
                Title = "The Undertake",
                Author = "Anyone",
                IBSN = "30",
                ID = 2
            }
        ];


        public static IEnumerable<Book> GetAll() => _books.OrderBy(b => b.ID);

        public static Book? GetById(int id) => _books.FirstOrDefault(b => b.ID == id);
        public static bool IdExist(int id) => _books.FirstOrDefault(r => r.ID == id) != null;

        public static Book Create(Book book)
        {
            var _nextId = _books.Count > 0 ? _books.Max((x) => x.ID) + 1 : 1;
            book.ID = _nextId++;
            _books.Add(book);
            return book;
        }

        public static bool Update(Book book)
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
            return true;
        }

        public static bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing is null)
            {
                return false;
            }

            return _books.Remove(existing);
        }

    }
}
