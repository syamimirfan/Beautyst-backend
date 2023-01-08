using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Beautyst_backend.Models
{
    public class MyList
    {   
        [Key]
        public int ListID {get; set;}

        //Relationships
        [ForeignKey("userid")]
        public int userid {get; set;}
        public User? User {get; set;} = new User();
       [ForeignKey("articleid")]
        public int articleid {get; set;}
        public Article? Article {get; set;} = new Article();
    }
}
