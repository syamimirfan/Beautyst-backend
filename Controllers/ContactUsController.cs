using Beautyst_backend.Data;
using Microsoft.AspNetCore.Mvc;
using Beautyst_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Beautyst_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactUsController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactUsController(DataContext context) {
            _context = context;
        }

        [HttpPost("AddContactUs")]
        public async Task<ActionResult<ContactUs>> addContactUs (AddContactUsRequest addContactUsRequest){
            var contact = new ContactUs() {
                Name = addContactUsRequest.Name,
                Email = addContactUsRequest.Email,
                Subject = addContactUsRequest.Subject,
                Comment = addContactUsRequest.Comment
            };       
            
            await _context.ContactUs.AddAsync(contact);
            await _context.SaveChangesAsync();
            return Ok(contact);
        }

        [HttpGet("GetContactUs")]
        public async Task<ActionResult<List<ContactUs>>> getContactUs() {
             return Ok(await _context.ContactUs.ToListAsync());
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<ContactUs>>> deleteContactUs([FromRoute] int id) {
    
            var contact = await _context.ContactUs.FindAsync(id);
        
            if (contact == null)
            {
                return NotFound();
            }

            _context.ContactUs.Remove(contact);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
