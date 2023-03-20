using System;
using System.Security.Claims;
using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Modal;
using BookStoreCommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreBackEndProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL iUserBL;
        public UserController(IUserBL iUserBL)
        {
            this.iUserBL = iUserBL;
        }
        //Entring the data in the database
        [HttpPost]
        [Route("User Registration")]
        public IActionResult UserRegister(UserRegistration userRegistration)
        {
            try
            {
                var result = iUserBL.UserRegister(userRegistration);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Registration Done Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Registration Unsuccessfull" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("User Login")]
        public IActionResult LoginUser(UserLogin userLogin)
        {
            try
            {
                var result = iUserBL.LoginUser(userLogin);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Login Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Login Unsuccessfull" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("Forgot Password")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                string result = iUserBL.ForgetPassword(email);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Check your Email, Token has been sent Succesfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Email Unregistered" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPut]
        [Route("Reset Password")]
        public IActionResult ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var data = iUserBL.ResetPassword(email, resetPasswordModel);
                if (data != null)
                {
                    return this.Ok(new { Success = true, message = "Your password has been changed sucessfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to reset password. Please try again" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("Update Detail for User")]
        public IActionResult UpdateUserDetail(UserRegistration userRegistration, long Id)
        {
            try
            {
                var result = this.iUserBL.UpdateUserDetail(userRegistration, Id);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "User Detail Updated Sucessfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "BUser details not updated" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
