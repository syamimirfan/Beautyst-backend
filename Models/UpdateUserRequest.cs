using System.ComponentModel.DataAnnotations;

namespace Beautyst_backend.Models
{
    public class UpdateUserRequest
    {
        [Required]
        public string FirstName {get; set;} = string.Empty;
        [Required]
        public string LastName {get; set;} = string.Empty;
        [Required]
        public string Username {get; set;} = string.Empty;

          [Required]
        public string Email {get; set;} = string.Empty;
        
  
    }
}