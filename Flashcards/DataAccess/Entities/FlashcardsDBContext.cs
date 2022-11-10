using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Entities
{
    //DbContext class represents a session/connection with DB
    //DbSet represents the collection of entities, this is how EF Core represents the data set
    //in OnModelCreating, you can define the constraints and table relationships
    public partial class FlashcardsDBContext : DbContext
    {
        public FlashcardsDBContext()
        {
        }

        public FlashcardsDBContext(DbContextOptions<FlashcardsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FlashCard> FlashCards { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlashCard>(entity =>
            {
                entity.Property(e => e.WasCorrect).HasDefaultValueSql("((0))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}