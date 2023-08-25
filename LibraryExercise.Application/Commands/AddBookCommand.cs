using LibraryExercise.Application.Services;
using LibraryExercise.Domain.Entities;
using LibraryExercise.Domain.Interfaces;

namespace LibraryExercise.Application.Commands
{
    public class AddBookCommand : IBookCommand
    {
        private readonly BookService _service;
        public AddBookCommand(BookService service) 
        { 
            _service = service;
        }

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Add a New Book");
            Console.WriteLine("--------------");

            Console.Write("Enter a Book Title: ");
            var title = Console.ReadLine();

            Console.Write("Enter an Author: ");
            var author = Console.ReadLine();

            Console.Write("Enter Rating (ie. 4.5): ");
            if (double.TryParse(Console.ReadLine(), out double rating))
            {
                //We'll assume the data entered is valid :)
                //Feel free to implement and extra layer of validation!
                var book = new Book
                { 
                    Title = title!, 
                    Author = author!, 
                    Rating = rating
                };

                _service.AddBook(book);
                Console.WriteLine("Book added successfully");
            }
            else
            {
                Console.WriteLine("Invalid rating format. Book not added, try again");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
