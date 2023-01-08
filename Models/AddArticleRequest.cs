using System.ComponentModel.DataAnnotations;

namespace Beautyst_backend.Models
{
    public class AddArticleRequest
    {
        [Required]
        public string Category {get; set;} = string.Empty;

        [Required]
        public string ArticleTitle {get; set;} = string.Empty;


        [Required]
        public string Date {get; set;}

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
        public List<MyList>? MyList {get; set;} 
    }
}