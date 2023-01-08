using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Beautyst_backend.Models
{
    public class Article
    {
        [Key]
        public int ArticleID {get; set;}

        [Required]
        public string Category {get; set;} = string.Empty;

        [Required]
        public string ArticleTitle {get; set;} = string.Empty;

        [Required]
        public string Date {get; set;} = string.Empty;

        [Required]
        public string AuthorName {get; set;} = string.Empty;
        
        [Required]
        public string Image {get; set;} = string.Empty;

        [Required]
        public string Video {get; set;} = string.Empty;

        [Required]
        public string ArticleParagraph1 {get; set;} = string.Empty;

        [Required]
        public string ArticleParagraph2 {get; set;} = string.Empty;

        [Required]
        public string CreatedRecordImage {get; set;} = string.Empty;

          [Required]
        public string CreatedRecordVideo {get; set;} = string.Empty;
        //Relationships 
        public List<MyList>? MyList {get; set;} = new List<MyList>();
      
    }
}