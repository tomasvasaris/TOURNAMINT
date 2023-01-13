using CA_API_01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CA_API_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public List<Book> books = new List<Book>
            {
                new Book { Id = 1, Name = "Times", Author = "John Doe", Published = 1994 },
                new Book { Id = 1, Name = "Places", Author = "John Doe", Published = 1995 },
                new Book { Id = 1, Name = "Space", Author = "Bill Dee", Published = 2004 }
            };

        [HttpGet("BookClub")]
        public List<Book> GetMyBooks()
        {
            return books;
        }

        [HttpGet("books/{id:int}")]
        public Book? GetBookByID(int id)
        {
            return books.FirstOrDefault(p => p.Id == id);
        }

        [HttpGet("books/{name}")]
        public Book? GetBookByName(string name)
        {
            return books.FirstOrDefault(p => p.Name == name);
        }

        [HttpGet("books")] // perdavimas per querry (ze correct way ((unless id)))
        public List<Book>? FilterBooksByNameAndAuthor(string name, string author)
        {
            return books.FindAll(p => p.Name == name && p.Author == author);
        }

        [HttpPost]
        public List<Book>? CreateBook(Book newBook)
        {
            var newBooks = books;

            newBook.Id = books
                .OrderByDescending(b => b.Id)
                .First().Id + 1;

            newBooks.Add(newBook);
            return newBooks;
        }
    }
}
Services