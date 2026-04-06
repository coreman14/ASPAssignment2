using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Book entity
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Author).IsRequired().HasMaxLength(30);
                entity.Property(e => e.IBSN).IsRequired();
                entity.Property(e => e.IsAvailable).IsRequired();
            });

            // Configure Reader entity
            modelBuilder.Entity<Reader>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Email).IsRequired();
            });

            // Configure AppUser entity
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(15);
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                
                // Add unique constraint on Username
                entity.HasIndex(e => e.Username).IsUnique();
            });

            // Configure Borrowing entity and relationships
            modelBuilder.Entity<Borrowing>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.BookId).IsRequired();
                entity.Property(e => e.ReaderId).IsRequired();
                entity.Property(e => e.DaysToBorrow).IsRequired();
                entity.Property(e => e.BorrowedDate).IsRequired();
                entity.Property(e => e.ReturnedDate).IsRequired(false);

                // Configure relationship with Book
                entity.HasOne<Book>()
                    .WithMany()
                    .HasForeignKey(e => e.BookId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Configure relationship with Reader
                entity.HasOne<Reader>()
                    .WithMany()
                    .HasForeignKey(e => e.ReaderId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            //Default data
            modelBuilder.Entity<Book>().HasData(
                new Book { ID = 1, Title = "Clean Code", Author = "Robert C. Martin", IBSN = "9780132350884", IsAvailable = true },
                new Book { ID = 2, Title = "Refactoring", Author = "Martin Fowler", IBSN = "9780201485677", IsAvailable = true }
            );

            modelBuilder.Entity<Reader>().HasData(
                new Reader { ID = 1, Name = "Alice Johnson", Email = "alice@lms.com" },
                new Reader { ID = 2, Name = "Bob Smith", Email = "bob@cws.com" }
            );

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser { ID = 1, Name = "Admin", Username = "Admin", Email = "admin@lms.local", Password = "admin123" },
                new AppUser { ID = 2, Name = "Dave", Username = "d3po", Email = "d@wwwss.local", Password = "admin123" }
            );

        }
    }
}
