using Microsoft.EntityFrameworkCore;
using My_Books.Models;

namespace My_Books.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            DbInitializer.Initialize(this);
        }

        public DbSet<Book> Books { get; set; }


    }
}
