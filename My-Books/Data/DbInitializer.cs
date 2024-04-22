using My_Books.Models;

namespace My_Books.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Books.Any())
            {
                return; // Data is already seeded
            }

            var books = new Book[]
            {
                new Book {
                    Title = "Book 1",
                    Description = "Description 1", 
                    IsRead = true,
                    DateRead = DateTime.Now, 
                    Rate = 4,
                    Genre = "Fiction",
                    Author = "Author 1",
                    CoverUrl = "url1",
                    DateAdded = DateTime.Now 
                },
                new Book { 
                    Title = "Book 2",
                    Description = "Description 2", 
                    IsRead = false,
                    DateRead = null, 
                    Rate = null,
                    Genre = "Non-Fiction",
                    Author = "Author 2",
                    CoverUrl = "url2",
                    DateAdded = DateTime.Now 
                }
               
            };

            foreach (var b in books)
            {
                context.Books.Add(b);
            }

            context.SaveChanges();
        }
    }
}
