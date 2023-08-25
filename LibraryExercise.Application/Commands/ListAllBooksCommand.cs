using LibraryExercise.Application.Services;
using LibraryExercise.Domain.Interfaces;

namespace LibraryExercise.Application.Commands
{
    public class ListAllBooksCommand : IBookCommand
    {
        private readonly BookService _bookService;
        public ListAllBooksCommand(BookService bookService)
        {
            _bookService = bookService;
        }
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("List of All Books");
            Console.WriteLine("-----------------");
            var books = _bookService.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Rating: {book.Rating}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }    
}
