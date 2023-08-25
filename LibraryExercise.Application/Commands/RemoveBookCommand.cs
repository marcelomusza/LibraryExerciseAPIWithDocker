using LibraryExercise.Application.Services;
using LibraryExercise.Domain.Interfaces;

namespace LibraryExercise.Application.Commands
{
    public class RemoveBookCommand : IBookCommand
    {
        private readonly BookService _bookService;

        public RemoveBookCommand(BookService bookService)
        {
            _bookService = bookService;
        }
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Remove a Book");
            Console.WriteLine("-------------");
            Console.Write("Enter Book ID to remove: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var book = _bookService.GetBookById(id);
                if (book != null)
                {
                    _bookService.RemoveBook(book);
                    Console.WriteLine($"Book '{book.Title}' removed successfully!");
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
