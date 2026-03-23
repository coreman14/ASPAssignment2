using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public static class ReaderRepository
    {
        private static readonly List<Reader> _readers =
        [
            new Reader { ID = 1, Name = "Alice Johnson", Email = "alice@lms.com" },
            new Reader { ID = 2, Name = "Bob Smith", Email = "bob@cws.com" }
        ];

        public static IEnumerable<Reader> GetAll() => _readers.OrderBy(r => r.ID);

        public static Reader? GetById(int id) => _readers.FirstOrDefault(r => r.ID == id);
        public static bool IdExist(int id) => _readers.FirstOrDefault(r => r.ID == id) != null;

        public static Reader Create(Reader reader)
        {
            var _nextId = _readers.Count > 0 ? _readers.Max((x) => x.ID) + 1 : 1;
            reader.ID = _nextId++;
            _readers.Add(reader);
            return reader;
        }

        public static bool Update(Reader reader)
        {
            var existing = GetById(reader.ID);
            if (existing is null)
            {
                return false;
            }

            existing.Name = reader.Name;
            existing.Email = reader.Email;
            return true;
        }

        public static bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing is null)
            {
                return false;
            }

            _readers.Remove(existing);
            return true;
        }
    }
}
