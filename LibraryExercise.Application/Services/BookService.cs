using LibraryExercise.Domain.Entities;
using LibraryExercise.Domain.Interfaces;

namespace LibraryExercise.Application.Services
{
    public class BookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }


        //Service methods
        public void AddBook(Book book)
        {
            _repository.Add(book);
            _repository.SaveChanges();
        }

        public void EditBook(Book book)
        {
            _repository.Edit(book);
            _repository.SaveChanges();
        }

        public void RemoveBook(Book book)
        {
            _repository.Remove(book);
            _repository.SaveChanges();
        }

        public Book GetBookById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _repository.GetAll();
        }
    }
}
