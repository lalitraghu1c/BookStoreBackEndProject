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
    public class AddressController : ControllerBase
    {
        IAddressBL iAddressBL;
        public AddressController(IAddressBL iAddressBL)
        {
            this.iAddressBL = iAddressBL;
        }


        [Authorize]
        [HttpPost]
        [Route("AddAddress")]
        public IActionResult AddAddress(AddressModel addressModel)
        {
            try
            {
                int Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = iAddressBL.AddAddress(addressModel, Id);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Address Added Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Try Again" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        [Authorize]
        [HttpDelete]
        [Route("DeleteAddress")]
        public IActionResult DeleteAddress(AddressIdModel addressIdModel)
        {
            try
            {
                var result = iAddressBL.DeleteAddress(addressIdModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Address Deleted Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Try Again" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateAddress")]
        public IActionResult UpdateAddress(AddressModel addressModel, int AddressId)
        {
            try
            {
                int Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = iAddressBL.UpdateAddress(addressModel, AddressId, Id);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Address Updated Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Try Again" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetAllAddress")]
        public IActionResult GetAddress()
        {
            try
            {
                var result = iAddressBL.GetAddress();
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Retrieve All Address Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Unable to Retrieve Address" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}