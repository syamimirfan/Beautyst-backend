using Beautyst_backend.Data;
using Beautyst_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Beautyst_backend.Controllers
{
    [ApiController]
    [Route("api/Article")]
    public class ArticleController : ControllerBase
    {
        private readonly DataContext _context;
        public ArticleController(DataContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Article>>> getArticle(){
            return Ok(await _context.Article.ToListAsync());
        }

        [HttpGet("{id}" , Name = "GetArticle")]
        //get a specific article
        public async Task<ActionResult<Article>> getArticle(int id){
            var article =  await _context.Article.FindAsync(id);
            if(article == null){
                return  BadRequest("Article not found!");
            }
            return Ok(article);
           
        }

        [HttpGet("total")]
        public async Task<ActionResult<int>> getTotalArticle() {
            return Ok(await _context.Article.CountAsync());
        }

        [HttpGet("view")]
        public async Task<ActionResult<List<Article>>> getSpecificArticle() {
          
             var result = (from a in _context.Article
             select new{
                
                ArticleTitle = a.ArticleTitle,
                Category = a.Category,
                AuthorName = a.AuthorName,
                Date = a.Date
             }).Take(3).ToList();

             return Ok(result);
        }

        [HttpGet("homepage")]
        public async Task<ActionResult<List<Article>>> getArticleHomepage() {
            var result = from a in _context.Article where a.AuthorName.StartsWith("a")
            select new {
                ArticleID = a.ArticleID,
                Image = a.Image,
                Category = a.Category,
                ArticleTitle = a.ArticleTitle
            };  
            return Ok(result);
        }
        [HttpGet("fashion")]
        public async Task<ActionResult<List<Article>>> getArticleFashion() {
            var result = from a in _context.Article where a.Category.Equals("Fashion")
            select new {
                ArticleID = a.ArticleID,
                Image = a.Image,
                Category = a.Category,
                ArticleTitle = a.ArticleTitle
            };  
            return Ok(result);
        }

          [HttpGet("makeup")]
        public async Task<ActionResult<List<Article>>> getArticleMakeup() {
            var result = from a in _context.Article where a.Category.Equals("Makeup")
            select new {
                ArticleID = a.ArticleID,
                Image = a.Image,
                Category = a.Category,
                ArticleTitle = a.ArticleTitle
            };  
            return Ok(result);
        }

          [HttpGet("skincare")]
        public async Task<ActionResult<List<Article>>> getArticleSkincare() {
            var result = from a in _context.Article where a.Category.Equals("Skincare") 
            select new {
                ArticleID = a.ArticleID,
                Image = a.Image,
                Category = a.Category,
                ArticleTitle = a.ArticleTitle
            };  
            return Ok(result);
        }

        [HttpGet("grooming")]
        public async Task<ActionResult<List<Article>>> getArticleGrooming() {
            var result = from a in _context.Article where a.Category.Equals("Grooming")
            select new {
                ArticleID = a.ArticleID,
                Image = a.Image,
                Category = a.Category,
                ArticleTitle = a.ArticleTitle
            };  
            return Ok(result);
        }

        [HttpGet("popularArticle")]
        public async Task<ActionResult<List<Article>>> getPopularArticle() {
            // var result = from a in _context.Article where a.
            var result = (from a in _context.Article 
            select new {
                Date = a.Date,
              ArticleTitle = a.ArticleTitle
            }).Take(4).ToList();
            // return (await _context.Article.ToListAsync());
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Article>> addArticle(AddArticleRequest addArticleRequest){
            var article = new Article() {
                Category = addArticleRequest.Category,
                ArticleTitle = addArticleRequest.ArticleTitle,
                 Date = addArticleRequest.Date,
                AuthorName = addArticleRequest.AuthorName,
                Image  = addArticleRequest.Image,
                Video = addArticleRequest.Video,
                ArticleParagraph1 = addArticleRequest.ArticleParagraph1,
                ArticleParagraph2 = addArticleRequest.ArticleParagraph2,
                CreatedRecordImage = addArticleRequest.CreatedRecordImage,
                CreatedRecordVideo = addArticleRequest.CreatedRecordVideo
            };

            await _context.Article.AddAsync(article);
            await _context.SaveChangesAsync();
            return Ok(article);
        }
    

        [HttpPatch("{id:int}", Name = "UpdateArticle")] 
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> updateArticle ([FromRoute] int id, UpdateArticleRequest updateArticleRequest) {
            var article = await _context.Article.FindAsync(id);

            if(article != null) {
                article.Category = updateArticleRequest.Category;
                article.ArticleTitle = updateArticleRequest.ArticleTitle;
                article.Date = updateArticleRequest.Date;
                article.AuthorName = updateArticleRequest.AuthorName;
                article.Image  = updateArticleRequest.Image;
                article.Video = updateArticleRequest.Video;
                article.ArticleParagraph1 = updateArticleRequest.ArticleParagraph1;
                article.ArticleParagraph2 = updateArticleRequest.ArticleParagraph2;
                article.CreatedRecordImage = updateArticleRequest.CreatedRecordImage;
                article.CreatedRecordVideo = updateArticleRequest.CreatedRecordVideo;
                
                await _context.SaveChangesAsync();  
                return Ok(article);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}" , Name = "DeleteArticle")]

        public async Task<ActionResult<List<Article>>> deleteArticle([FromRoute] int id) {
            var article = await _context.Article.FindAsync(id);

            if(article == null) {
                return BadRequest("Article not found!");
            }

            _context.Article.Remove(article);
            await _context.SaveChangesAsync();
            return Ok(await _context.Article.ToListAsync());
        }
       
    }
}