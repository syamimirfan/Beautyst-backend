using Microsoft.EntityFrameworkCore;
using Beautyst_backend.Models;


namespace Beautyst_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        //DbSet<User> is from the model
        //User is the table name for db
        public DbSet<User> User {get; set;}
        public DbSet<Article> Article {get; set;}
        public DbSet<MyList> MyList {get; set;}
        public DbSet<ContactUs> ContactUs {get; set;}
    }
}