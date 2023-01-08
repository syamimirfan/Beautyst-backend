using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Beautyst_backend.Models;
using Beautyst_backend.Data;


namespace Beautyst_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
           [HttpPost("login")]
        public async Task<ActionResult<string>> adminLogin (AddAdmin addAdminRequest) {
              if(addAdminRequest.Password == null) {
                return BadRequest("Please enter your password");
              }
            
             if (addAdminRequest.Password != "admin123"){
                return BadRequest("Wrong password");
             }

             if (addAdminRequest.Password == "admin123"){
                return Ok(addAdminRequest);
             }

             return NoContent();
              
        } 
      
    }
}