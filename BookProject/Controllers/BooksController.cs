using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly List<Book> _books;
        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sortByPublisherAuthorTitle")]
        public IActionResult GetBooksSortedByPublisherAuthorTitle()
        {
            try
            {
                var sortedBooks = _books.OrderBy(b => b.Publisher).ThenBy(b => b.AuthorLastName).ThenBy(b => b.AuthorFirstName).ThenBy(b => b.Title);
                return Ok(sortedBooks);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("sortByAuthorTitle")]
        public IActionResult GetBooksSortedByAuthorTitle()
        {
            try
            {
                var sortedBooks = _books.OrderBy(b => b.AuthorLastName).ThenBy(b => b.AuthorFirstName).ThenBy(b => b.Title);
                return Ok(sortedBooks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("totalPrice")]
        public IActionResult GetTotalPrice()
        {
            try
            {
                var totalPrice = _books.Sum(b => b.Price);
                return Ok(totalPrice);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
