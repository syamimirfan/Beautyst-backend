using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Beautyst_backend.Models
{
    public class ContactUs
    {
        [Key]
        public int ContactID {get; set;}
        [Required]
        public string Name {get; set;} = string.Empty;

        [Required]
        public string Email {get; set;} = string.Empty;

        [Required]
        public string Subject {get; set;} = string.Empty;

        [Required]
        public string Comment {get; set;} = string.Empty;
    }
}