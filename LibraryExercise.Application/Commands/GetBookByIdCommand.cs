using LibraryExercise.Application.Services;
using LibraryExercise.Domain.Interfaces;

namespace LibraryExercise.Application.Commands
{
    public class GetBookByIdCommand : IBookCommand
    {
        private readonly BookService _bookService;

        public GetBookByIdCommand(BookService bookService)
        {
            _bookService = bookService;
        }
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Find Book by ID");
            Console.WriteLine("---------------");
            Console.Write("Enter Book ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var book = _bookService.GetBookById(id);
                if (book != null)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Rating: {book.Rating}");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
