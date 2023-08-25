using LibraryExercise.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryExercise.Infrastructure
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            :base(options)
        {                
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseInMemoryDatabase("LibraryDB");
        }

        public void SeedData()
        {
            if (!Books.Any())
            {
                Books.AddRange(
                    new Book { Id = 1, Title = "Lord of the Rings", Author = "JRR Tolkien", Rating = 9.1 },
                    new Book { Id = 2, Title = "The Hobbit", Author = "JRR Tolkien", Rating = 9.5 },
                    new Book { Id = 3, Title = "Pet Semetary", Author = "Stephen King", Rating = 7.1 },
                    new Book { Id = 4, Title = "The Code of the Extraordinary Mind", Author = "Vishen Lakhiani", Rating = 9.8 },
                    new Book { Id = 5, Title = "Estas para más", Author = "Daniela de Lucia", Rating = 9.1 }
                    );

                SaveChanges();
            }            
        }
    }
}
