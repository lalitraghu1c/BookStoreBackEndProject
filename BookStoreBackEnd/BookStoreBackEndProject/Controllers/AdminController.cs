using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreBackEndProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdminBL iAdminRL;
        public AdminController(IAdminBL iAdminRL)
        {
            this.iAdminRL = iAdminRL;

        }

        [HttpPost]
        [Route("Admin Login")]
        public IActionResult AdminLogin(AdminLogin adminLogin)
        {
            try
            {
                var result = iAdminRL.AdminLogin(adminLogin);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Admin Login Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Admin Login UnSuccessfull" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
