using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess;


public class FlashcardsCodeFirstDBContext : DbContext
{
    public FlashcardsCodeFirstDBContext() {}

    public FlashcardsCodeFirstDBContext(DbContextOptions<FlashcardsCodeFirstDBContext> options)
            : base(options) {}

    public DbSet<FlashCard> CodeFirstFlashCards { get; set; } = null!;
}