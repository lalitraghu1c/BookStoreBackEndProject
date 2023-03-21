using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreBackEndProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        IFeedbackBL iFeedbackBL;
        public FeedbackController(IFeedbackBL iFeedbackBL)
        {
            this.iFeedbackBL = iFeedbackBL;
        }

        [Authorize]
        [HttpPost]
        [Route("Add FeedBack")]
        public IActionResult AddFeedback(FeedbackModel feedbackModel)
        {
            int Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
            var result = iFeedbackBL.AddFeedback(feedbackModel, Id);
            if (result != null)
            {
                return Ok(new { success = true, Message = "Thank you for your Feedback", data = result });
            }
            else
            {
                return BadRequest(new { success = false, message = "Try Again", data = result });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("Get Feedback")]
        public IActionResult GetFeedback(int Book_Id)
        {
            try
            {
                int Id = Convert.ToInt32(User.Claims.FirstOrDefault(g => g.Type == "Id").Value);
                var result = iFeedbackBL.GetFeedback(Book_Id);

                if (result != null)
                {
                    return Ok(new { Success = true, Message = "Feedback Retrieved Successfully", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Try Again" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}