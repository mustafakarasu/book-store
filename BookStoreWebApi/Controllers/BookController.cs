using System;
using System.Linq;
using BookStoreWebApi.BookOperations.CreateBook;
using BookStoreWebApi.BookOperations.GetBookById;
using BookStoreWebApi.BookOperations.GetBooks;
using BookStoreWebApi.BookOperations.UpdateBook;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This action get all books.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksCommand command = new GetBooksCommand(_context);
            var obj = command.Handle();
            return Ok(obj);
        }

        /// <summary>
        /// This action method get one book by book id.
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            BookViewModel result;
            try
            {
                var command = new GetBookByIdCommand(_context);
                result = command.Handle(id);
            }
            catch ( Exception ex )
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        /// <summary>
        /// This action method updates book entity by id.
        /// </summary>
        /// <param name="id">Updated book id value.</param>
        /// <param name="updatedBookModel">Updated book model value.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBookModel)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.Handle(id, updatedBookModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// This action method creates book entity.
        /// </summary>
        /// <param name="newBook"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            try
            {
                CreateBookCommand command = new CreateBookCommand(_context);
                command.Handle(newBook);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}