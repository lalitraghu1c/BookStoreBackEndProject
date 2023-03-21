using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Model;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Security.Claims;
using System.Linq;

namespace BookStoreBackEndProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        IOrderBL iOrderBL;
        public OrdersController(IOrderBL iOrderBL)
        {
            this.iOrderBL = iOrderBL;

        }
        [HttpPost]
        [Route("Add Order")]
        public IActionResult AddOrder(OrderModel orderModel)
        {
            try
            {   
                long Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = this.iOrderBL.AddOrder(orderModel, Id);
                if (result != null)

                {
                    return this.Ok(new { Success = true, message = "Order Placed Sucessfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Order not placed" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpGet]
        [Route("GetAllOrders")]
        public IActionResult GetOrders()
        {
            try
            {
                var result = iOrderBL.GetOrders();
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Retrieve All Orders Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Try Again!! Something Wrong" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}