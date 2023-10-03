using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _manager.bookService.GetAllBooks(false);
            return Ok(books);//200
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var book = _manager
                .bookService
                .GetOneBookById(id, false);


                if (book is null)
                {
                    return NotFound();//404
                }

                return Ok(book);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();//400

                _manager.bookService.CreateOneBook(book);
                

                return StatusCode(201, book);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }




        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {

            try
            {
                //check  book:güncellenecek olan kitabın bilgisini çekiyoruz
                if (book is null)
                    return BadRequest();//400

                _manager.bookService.UpdateOneBook(id, book, true);

                return NoContent();//204

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBooks([FromRoute(Name = "id")] int id)
        {
            try
            {

                _manager.bookService.DeleteOneBook(id, false);
                return NoContent();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            try
            {

                //check Entity bir tane kitap al
                var entity = _manager
                    .bookService
                    .GetOneBookById(id, true);//Değişiklikleri izle


                if (entity is null)
                    return NotFound();//404


                bookPatch.ApplyTo(entity);
                _manager.bookService.UpdateOneBook(id, entity, true);

                return NoContent();//204
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

    }
}
