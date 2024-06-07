using Book_store.Data.Entities;
using Book_Store.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext Context;

        public BooksController(ApplicationDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = Context.Books.ToList();
            return Ok(books);
        }

        [HttpGet]
        [Route("{id: Guid}")]
        public IActionResult GetBookById(Guid id)
        {
            var book = Context.Books.Find(id);
            if (book == null)
            {
                return BadRequest("Book not found");
            }
            return Ok(book);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]

        public IActionResult PostBook(BooksDto book)
        {
            var Book = new Book()
            {
                Author = book.Author,
                Genre = book.Genre,
                ISBN = book.ISBN,
                Title = book.Title,
                PublishedDate = book.PublishedDate,
                Description = book.Description,
                price = book.price,
                numberOfBooks = book.numberOfBooks
            };
            Context.Books.Add(Book);
            Context.SaveChanges();
            return Ok(Book);
        }

        [HttpPut]
        [Route("{id: Guid}")]
        [Authorize(Roles ="Admin")]
        public IActionResult updatePost(Guid Id, BooksDto book)
        {
            var Book = Context.Books.Find(Id);
            if (Book == null)
            {
                return BadRequest("Book not found");
            }
            Book.ISBN = book.ISBN;
            Book.Title = book.Title;
            Book.PublishedDate = book.PublishedDate;
            Book.Description = book.Description;
            Book.Genre = book.Genre;
            Book.Author = book.Author;
            Book.numberOfBooks = book.numberOfBooks;
            Book.price = book.price;
            Context.SaveChanges();
            return Ok(Book);
        }

        [HttpDelete]
        [Route("{id: Guid}")]
        [Authorize(Roles ="Admin")]
        public IActionResult deleteBook(Guid id)
        {
            var Book = Context.Books.Find(id);
            if (Book == null)
            {
                return BadRequest("Book not found");
            }
            Context.Books.Remove(Book);
            Context.SaveChanges();
            return Ok(Book);
        }

        [HttpGet]
        [Route("search")]
        public IActionResult searchBook([FromQuery] string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return NotFound("query is empty");
            }
            var Books = Context.Books.Where(b => b.Title.Contains(query) || b.Author.Contains(query)|| b.Genre.Contains(query)).ToListAsync();
            if (Books == null)
            {
                return NotFound("No books found as per query");
            }
            return Ok(Books);
        }
    }
}
