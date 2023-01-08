using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Beautyst_backend.Models
{
    public class AddUserRequest
    {
        
        [Required]
        public string FirstName {get; set;} = string.Empty;
        [Required]
        public string LastName {get; set;} = string.Empty;
        [Required]
        public string Email {get; set;} = string.Empty;
        [Required]
        public string Username {get; set;} = string.Empty;
        [Required]
        public string Password {get; set;} = string.Empty; 
        
       
       
    }
}