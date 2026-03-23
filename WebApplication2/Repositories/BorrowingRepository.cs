using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public static class BorrowingRepository
    {
        private static readonly List<Borrowing> _borrowings = [];

        public static IEnumerable<Borrowing> GetAll() => _borrowings.OrderBy(b => b.ID);

        public static Borrowing? GetById(int id) => _borrowings.FirstOrDefault(b => b.ID == id);

        public static Borrowing Create(Borrowing borrowing)
        {
            var _nextId = _borrowings.Count > 0 ? _borrowings.Max((x) => x.ID) + 1 : 1;
            borrowing.ID = _nextId++;
            _borrowings.Add(borrowing);
            return borrowing;
        }

        public static bool Update(Borrowing borrowing)
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
            return true;
        }

        public static bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing is null)
            {
                return false;
            }

            _borrowings.Remove(existing);
            return true;
        }
    }
}
