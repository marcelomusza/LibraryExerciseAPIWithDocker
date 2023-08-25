using LibraryExercise.Domain.Entities;
using LibraryExercise.Domain.Interfaces;

namespace LibraryExercise.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public void Add(Book item)
        {
            _context.Add(item);
        }

        public void Edit(Book item)
        {
            _context.Update(item);
        }

        public Book GetById(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id)!;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public void Remove(Book item)
        {
            _context.Remove(item);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
