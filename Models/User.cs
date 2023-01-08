using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace Beautyst_backend.Models
{
    public class User
    {
        [Key]
        public int UserID {get; set;}
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
        
        //Relationships
        public List<MyList>? MyList {get; set;} = new List<MyList>();

 
    }
}