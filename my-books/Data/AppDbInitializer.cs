using my_books.Data.Models;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "Initial1",
                        Description = "Initial1",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-1),
                        Rate = 5,
                        Genre = "Initial1",
                        Author = "Initial1",
                        CoverUrl = "Initial1",
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
