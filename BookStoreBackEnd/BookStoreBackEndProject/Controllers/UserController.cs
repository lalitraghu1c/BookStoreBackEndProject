using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Modal;
using BookStoreCommonLayer.Model;
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
        [Route("UserRegistration")]
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
        [Route("UserLogin")]
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
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                string token = iUserBL.ForgetPassword(email);
                if (token != null)
                {
                    return this.Ok(new { success = true, message = "Check your Email, Token sent Succesfully", data = token });
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
    }
}
