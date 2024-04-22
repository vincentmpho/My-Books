using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Books.Models.DTOs;
using My_Books.Repository;
using My_Books.Repository.Interface;
using System;

namespace My_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        // GET method to retrieve all books
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            // Retrieve all books from the repository and return them
            var books = _booksRepository.GetAllBooks();
            return Ok(books);
        }

        // POST method to add a new book
        [HttpPost]
        public IActionResult AddBook([FromBody] BookDto book)
        {
            // Add a new book to the repository
            _booksRepository.AddBook(book);
            return Ok();
        }

        // GET method to retrieve a book by id
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            // Get a specific book by its id
            var book = _booksRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // PUT method to update a book by id
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookDto book)
        {
            // Update an existing book with new data based on its id
            var existingBook = _booksRepository.GetBookById(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            _booksRepository.UpdateBook(id, book);
            return Ok();
        }

        // DELETE method to delete a book by id
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            // Delete a book from the repository by its id
            var existingBook = _booksRepository.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            _booksRepository.DeleteBook(id);
            return Ok();
        }
    }
}