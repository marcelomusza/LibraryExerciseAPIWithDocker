using LibraryExercise.API.Models;
using LibraryExercise.Application.Services;
using LibraryExercise.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace LibraryExercise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        //No interfase for this example in particular for simplicity
        private readonly BookService _bookService;
        
        public LibraryController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] BookDto dto)
        {
            //We will assume that the dto data is correct, feel free to explore Validation opportunities here ;)

            //We will also, for simplicity, map the dto to the Book object here. We can achieve this using different tools
            //For this exercise, and knowing that we are breaking a clean architecture rule here, we'll just map the dto to the domain object here
            //This way we don't have to adapt nor change anything structural from this existing solution
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Rating = dto.Rating
            };

            _bookService.AddBook(book);

            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult EditBook(int id, [FromBody] BookDto dto)
        {
            //We will assume that the incoming parameters are correct, feel free to explore Validation opportunities here ;)
            var existingBook = _bookService.GetBookById(id);

            //We will also, for simplicity, map the dto to the Book object here. We can achieve this using different tools
            //For this exercise, and knowing that we are breaking a clean architecture rule here, we'll just map the dto to the domain object here
            //This way we don't have to adapt nor change anything structural from this existing solution

            if (existingBook == null)
            {
                return BadRequest("Invalid Id...");
            }

            //Let's update the book - Again for simplicity we are doing it here in the Controller, we should operate this on the Application layer
            //Using a Mapping feature, but since we are not modifying the existing BookService, we'll leave this as is Here
            existingBook.Title = dto.Title;
            existingBook.Author = dto.Author;
            existingBook.Rating = dto.Rating;

            _bookService.EditBook(existingBook);

            return Ok(existingBook);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            //We will assume that the incoming parameters are correct, feel free to explore Validation opportunities here ;)
            var book = _bookService.GetBookById(id);

            if (book == null)
            {
                return BadRequest("Invalid Id...");
            }

            return Ok(book);
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            //We will assume that the incoming parameters are correct, feel free to explore Validation opportunities here ;)
            var books = _bookService.GetAllBooks();

            if (books == null)
            {
                return BadRequest("Invalid Id...");
            }

            return Ok(books);
        }

        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            //We will assume that the incoming parameters are correct, feel free to explore Validation opportunities here ;)
            var book = _bookService.GetBookById(id);

            if (book == null)
            {
                return BadRequest("Invalid Id...");
            }

            _bookService.RemoveBook(book);           

            return Ok($"Book: {book.Title} removed from the database");
        }
    }
}