using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Modal;
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
    }
}
