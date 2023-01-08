using System.ComponentModel.DataAnnotations;

namespace Beautyst_backend.Models
{
    public class AddToUserMyList
    {
        public User? User {get; set;}
        public int UserID {get; set;}
        public Article? Article {get; set;}
        public int ArticleID {get; set;}
    }
}