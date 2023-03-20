using BookStoreBusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreBackEndProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        IWishlistBL iWishlistBL;
        public WishlistController(IWishlistBL iWishlistBL)
        {
            this.iWishlistBL = iWishlistBL;
        }

        [Authorize]
        [HttpPost]
        [Route("AddToWishList")]
        public IActionResult AddWishList(int Book_Id)
        {
            try
            {

                int Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);

                var result = iWishlistBL.AddWishList(Book_Id, Id);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Add Book To WishList Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Try Again" });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPost]
        [Route("RemoveWishList")]
        public IActionResult DeleteWishList(int WishListId)
        {
            try
            {

                int Id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

                var result = iWishlistBL.DeleteWishList(WishListId, Id);

                if (result != false)
                {
                    return Ok(new { success = true, message = "Remove WishList Successfully" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Try Again" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("GetWishList")]
        public IActionResult GetAllWishList()
        {
            try
            {
                int Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = iWishlistBL.GetAllWishList(Id);
                if (result != null)
                {
                    return Ok(new { Success = true, Message = "Wishlist Retrieved Successfully", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "TryAgain" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}