﻿using System.Linq;
using System;
using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreBackEndProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        ICartBL icartBL;
        public CartController(ICartBL icartBL)
        {
            this.icartBL = icartBL;
        }
        //[Authorize]
        [HttpPost]
        [Route("Add to Cart")]
        public ActionResult AddCart(CartModel cartModel)
        {
            try
            {
                var currentUser = HttpContext.User;
                long UserId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = icartBL.AddCart(cartModel, UserId);

                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Book added successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Book Not Added", data = result });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //[Authorize]
        [HttpDelete]
        [Route("Delete")]
        public ActionResult RemoveCart(int cartId)
        {
            try
            {
                var result = this.icartBL.RemoveCart(cartId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Delete Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Delete Unsuccessfull", data = result });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //[Authorize]
        [HttpPut]
        [Route("Update")]
        public ActionResult UpdateCart(int cartId, CartModel cartModel)
        {
            try
            {
                var currentUser = HttpContext.User;
                int UserId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);

                var result = icartBL.UpdateCart(cartId, cartModel, UserId);

                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Cart Updated", data = result });
                }
                return this.BadRequest(new { success = false, message = "Cart not updated", data = result });

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
