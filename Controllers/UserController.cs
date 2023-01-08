using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Beautyst_backend.Models;
using Beautyst_backend.Data;
using Microsoft.AspNetCore.Http;

namespace Beautyst_backend.Controllers
{
    [ApiController]
    [Route("api/User")]
    
    public class UserController : ControllerBase
    {  
        public static User user = new User();
        private readonly DataContext _context;
        public UserController(DataContext context) {
            _context = context;
        }
        
        //to get users data
        [HttpGet]
        public async Task<ActionResult<List<User>>> getUser() {
            return Ok(await _context.User.ToListAsync());
        }
          [HttpGet("{id}" , Name = "GetUser")]
        //get a specific user
        public async Task<ActionResult<User>> getUser(int id){
            var user =  await _context.User.FindAsync(id);
            if(user == null){
                return  BadRequest("User not found!");
            }
            return Ok(user);
        }

         [HttpGet("getUserId")]
        //get a specific user with email
        public async Task<ActionResult<User>> getUserId(int id){
           var  user = from u in _context.User where u.UserID.Equals(id) 
           select new {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Username = u.Username,
                UserID = u.UserID
           };
           return Ok(user);
        }

        [HttpGet("view")]
        public async Task<ActionResult<List<User>>> getSpecificUser() {

         var result = (from u in _context.User
                 select new
                 {
                 FirstName = u.FirstName,
                 LastName = u.LastName,
                 Email = u.Email,
                 Username = u.Username,     
                 Password = u.Password
                 }).Take(3).ToList();
           return Ok(result);
        }

        [HttpGet("total")] 
        public async Task<ActionResult<int>> getTotalUser() {
          var totalUser = await _context.User.CountAsync();

            return Ok(totalUser);
        }
       
        [HttpPost("register")] //to create a users data
        public async Task<ActionResult<User>> addUser(AddUserRequest addUserRequest) {
             var user = new User() {
                FirstName = addUserRequest.FirstName,
                LastName = addUserRequest.LastName,
                Email = addUserRequest.Email,
                Username = addUserRequest.Username,     
                Password = addUserRequest.Password
             };

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return  Ok(user);
        }


        [HttpPost("login")]
        public async Task<ActionResult> userLogin([FromBody] LoginUserRequest loginUserRequest){
            var dbUser =  _context.User.Where(u => u.Email == loginUserRequest.Email && 
            u.Password == loginUserRequest.Password).Select(
                u => new {
                    u.UserID,
                    u.Email,
                    u.Password
                }
            ).FirstOrDefault();
            
            if(dbUser == null) {
                return BadRequest("Email or password is incorrect");
            }

            return Ok(dbUser);
        }
      

       [HttpPatch("{id:int}", Name = "UpdateUser")]//to update a users data

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> updateUser([FromRoute] int id, UpdateUserRequest updateUserRequest)
        {
            var user = await _context.User.FindAsync(id);
      
            if(user != null) {
                
                user.FirstName = updateUserRequest.FirstName;
                user.LastName = updateUserRequest.LastName;
                user.Username = updateUserRequest.Username;
                user.Email = updateUserRequest.Email;

                await _context.SaveChangesAsync();
                return Ok(user);
            }
            return NoContent();
        }

        [HttpDelete("{id:int}", Name = "DeleteUser")]
        public async Task<ActionResult<List<User>>> deleteUser([FromRoute] int id){
              var user = await _context.User.FindAsync(id);
            if(user == null){
                return BadRequest("User not found!");
            }
            _context.User.Remove(user);
             await _context.SaveChangesAsync();
             return Ok(await _context.User.ToListAsync());
        }
        
    }
}