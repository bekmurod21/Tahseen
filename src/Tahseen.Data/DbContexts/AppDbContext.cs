using Microsoft.EntityFrameworkCore;
using Tahseen.Domain.Entities;
using Tahseen.Domain.Entities.Books;
using Tahseen.Domain.Entities.Events;
using Tahseen.Domain.Entities.Feedback;
using Tahseen.Domain.Entities.Librarians;
using Tahseen.Domain.Entities.Users;

namespace Tahseen.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }




    //Folder Name: Books
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookReviews> BookReviews { get; set; }
    public DbSet<CompletedBooks> CompletedBooks { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Genre> Genres { get; set; }

    //Folder Name: Events
    public DbSet<Event> Events { get; set; }
    public DbSet<EventRegistration> EventsRegistration { get; set; }

    //Folder Name: Feedbacks
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<SurveyResponses> SurveyResponses { get; set; }
    public DbSet<Surveys> Surveys { get; set; }
    public DbSet<UserMessage> UserMessages { get; set; }
    public DbSet<UserRatings> UserRatings { get; set; }
    public DbSet<WishList> WishLists { get; set; }

    //Folder Name: Librarians 
    public DbSet<Librarian> Librarian { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=ProductOrderDb;Username=postgres;Password=0808080808");
    }
}
