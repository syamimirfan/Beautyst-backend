using Beautyst_backend.Data;
using Microsoft.AspNetCore.Mvc;
using Beautyst_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Beautyst_backend.Controllers
{
    [ApiController]
  [Route("api/[controller]")]
    public class MyListController : ControllerBase
    {
         private readonly DataContext _context;

        public MyListController(DataContext context) {
            _context = context;
        }

         [HttpGet("{id}")]
        //get a specific article
        public async Task<ActionResult<MyList>> getMyList(int id){
            var list =  await _context.MyList.FindAsync(id);
            if(list == null){
                return  BadRequest("List not found!");
            }
            return Ok(list);
           
        }
        
        [HttpPost("AddMyList")]
        public async Task<ActionResult<MyList>> AddMyList (AddToUserMyList addToUserMyList) {
            var myList = new MyList() {
                userid = addToUserMyList.UserID,
                articleid = addToUserMyList.ArticleID,
                Article = addToUserMyList.Article,
                User = addToUserMyList.User
            }; 
            
            await _context.MyList.AddAsync(myList);
            await _context.SaveChangesAsync();
            return Ok(myList);
        }

        [HttpGet ("GetList")]
         public async Task<ActionResult<List<MyList>>> getAllList (int id){ 
              var result = from t1 in _context.MyList
               join t2 in _context.User on t1.userid equals t2.UserID
               join t3 in _context.Article on t1.articleid equals t3.ArticleID 
               where t1.userid == id
               select new {
                 ListID = t1.ListID,
                 UserID = t2.UserID,
                 ArticleID = t3.ArticleID,
                 Image = t3.Image,
                 Category = t3.Category,
                 ArticleTitle = t3.ArticleTitle
               };

               return Ok(result);
         }

        [HttpDelete("DeleteList")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<MyList>>> DeleteList(int id)
        {
            var list = await _context.MyList.FindAsync(id);

            if (list == null)
            {
                return NotFound();
            }

            _context.MyList.Remove(list);
            await _context.SaveChangesAsync();

            return Ok();
        }



    }
}