using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Model;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace BookStoreBackEndProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookBL bookBL;
        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;

        }
        [HttpPost("Add Book")]
        public IActionResult AddBook(BookModel bookModel)
        {
            try
            {
                var result = this.bookBL.AddBook(bookModel);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Book Added Sucessfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Book not added" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpPost("Update Book")]
        public IActionResult UpdateBook(BookModel bookModel, long bookid)
        {
            try
            {
                var result = this.bookBL.UpdateBook(bookModel, bookid);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Book Updated Sucessfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Book details not updated" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteBook(long bookid)
        {
            try
            {
                var result = this.bookBL.DeleteBook(bookid);
                if (result != null)

                {
                    return this.Ok(new { Success = true, message = "Book Deleted Sucessfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to delete" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpGet("Get all Books")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var result = bookBL.GetAllBooks();
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "All Book Details", data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to get details" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("Get single Book")]
        public IActionResult GetBookDetail(long bookid)
        {
            try
            {
                var result = this.bookBL.GetBookDetail(bookid);
                if (result != null)

                {
                    return this.Ok(new { Success = true, message = "Book Details", data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to get details" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
