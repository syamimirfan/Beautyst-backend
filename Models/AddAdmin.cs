using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Beautyst_backend.Models
{
    public class AddAdmin
    {
      
      [Required]
      public string Password {get; set;} = "admin123"; 
   
    }
}