using LibraryExercise.Domain.Entities;

namespace LibraryExercise.Domain.Interfaces
{
    public interface IBookRepository
    {
        void Add(Book item);
        void Edit(Book item);
        void Remove(Book item);
        IEnumerable<Book> GetAll();
        Book GetById(int id);

        void SaveChanges();
    }
}
