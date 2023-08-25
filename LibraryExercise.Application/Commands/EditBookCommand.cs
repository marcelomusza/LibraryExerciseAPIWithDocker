using LibraryExercise.Application.Services;
using LibraryExercise.Domain.Entities;
using LibraryExercise.Domain.Interfaces;

namespace LibraryExercise.Application.Commands
{
    public class EditBookCommand : IBookCommand
    {
        private readonly BookService _service;
        public EditBookCommand(BookService service) 
        { 
            _service = service;
        }

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Update Book Information");
            Console.WriteLine("-----------------------");

            Console.Write("Enter Book ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var existingBook = _service.GetBookById(id);
                if (existingBook != null)
                {
                    Console.Write("Enter new Book Title (blank to keep existing): ");
                    var newTitle = Console.ReadLine();

                    Console.Write("Enter new Author (blank to keep existing): ");
                    var newAuthor = Console.ReadLine();

                    Console.Write("Enter new Rating (blank to keep existing): ");
                    if (double.TryParse(Console.ReadLine(), out double newRating))
                    {
                        if (!string.IsNullOrEmpty(newTitle))
                        {
                            existingBook.Title = newTitle;
                        }

                        if (!string.IsNullOrEmpty(newAuthor))
                        {
                            existingBook.Author = newAuthor;
                        }

                        existingBook.Rating = newRating;

                        _service.EditBook(existingBook);
                        Console.WriteLine("Book updated successfully");
                    }
                    else
                    {
                        Console.WriteLine("Invalid rating format. Book not updated, try again");
                    }
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
