using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Beautyst_backend.Models
{
    public class LoginUserRequest
    {
     [Required]
      public string Email {get; set;} = string.Empty;
      
      [Required]
      public string Password {get; set;} = string.Empty; 
   
    }
}