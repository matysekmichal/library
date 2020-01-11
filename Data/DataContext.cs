using System.ComponentModel.DataAnnotations.Schema;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorGenre>()
                .HasKey(sc => new { sc.AuthorId, sc.GenreId });
            modelBuilder.Entity<AuthorGenre>()
                .HasOne(sc => sc.Author)
                .WithMany(sc => sc.AuthorGenres)
                .HasForeignKey(sc => sc.AuthorId);
            modelBuilder.Entity<AuthorGenre>()
                .HasOne(sc => sc.Genre)
                .WithMany(sc => sc.AuthorGenres)
                .HasForeignKey(sc => sc.GenreId);
            
            modelBuilder.Entity<ReservedPublication>()
                .HasKey(sc => new { sc.PublicationId, sc.ReservationId });
            modelBuilder.Entity<ReservedPublication>()
                .HasOne(sc => sc.Reservation)
                .WithMany(sc => sc.ReservedPublications)
                .HasForeignKey(sc => sc.ReservationId);
            modelBuilder.Entity<ReservedPublication>()
                .HasOne(sc => sc.Publication)
                .WithMany(sc => sc.ReservedPublications)
                .HasForeignKey(sc => sc.PublicationId);

            modelBuilder.Entity<PublicationGenre>()
                .HasKey(sc => new { sc.PublicationId, sc.GenreId });
            modelBuilder.Entity<PublicationGenre>()
                .HasOne(sc => sc.Publication)
                .WithMany(sc => sc.PublicationGenres)
                .HasForeignKey(sc => sc.PublicationId);
            modelBuilder.Entity<PublicationGenre>()
                .HasOne(sc => sc.Genre)
                .WithMany(sc => sc.PublicationGenres)
                .HasForeignKey(sc => sc.GenreId);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<AuthorGenre> AuthorGenres { get; set; }
        public DbSet<PublicationGenre> PublicationGenres { get; set; }
        public DbSet<ReservedPublication> ReservedPublications { get; set; }
    }
}