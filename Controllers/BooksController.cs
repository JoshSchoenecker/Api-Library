using System;
using System.Collections.Generic;
using apiLibrary.DB;
using Microsoft.AspNetCore.Mvc;

namespace apiLibrary
{

    [ApiController]
    [Route("api/[controller]")]
    
    public class BookController : ControllerBase
    {

// NOTE Get Requests
    // Get all books
    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetAll()
    {
        try
        {
            return Ok(FakeDB.Books);
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    // Get a book by Id
    [HttpGet("{bookId}")]
    public ActionResult<IEnumerable<Book>> GetOne(string bookId)
    {
        try
        {
            Book selectedBook = FakeDB.Books.Find(book => book.Id == bookId);
            // don't forget to hanle null!
            if (selectedBook == null)
            {
                throw new Exception("Invalid ID!");
            }
            return Ok(selectedBook);
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);            
        }
    }
// NOTE Post Request
    [HttpPost]
    public ActionResult<Book> Create([FromBody] Book newBook)
    {
        try
        {
            FakeDB.Books.Add(newBook);
            return Created($"api/books/{newBook.Id}", newBook);
        }
        catch (System.Exception err)
        {
         return BadRequest(err.Message);
        }
    }
// NOTE Put Request
    [HttpPut("{bookId}")]
    public ActionResult<Book> Edit(string bookId, [FromBody] Book updatedBook)
    {
        try
        {
            Book updateQueue = FakeDB.Books.Find(book => book.Id == bookId);
            if (updateQueue == null)
            {
                throw new Exception("Invalid ID!");
            }
            return Ok(updateQueue);
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }
// NOTE Delete Request
    [HttpDelete("{bookId}")]
    public ActionResult<Book> Delete(string bookId)
    {
        try
        {
            Book bookToUpdate = FakeDB.Books.Find(book => book.Id == bookId);
            if (bookToUpdate == null)
            {
                throw new Exception("Invalid ID!");
            }
            return Ok("Book Deleted");
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    }

}