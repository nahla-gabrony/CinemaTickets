using CinemaTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaTickets.Data
{
    public class CinemaTicketsContext : IdentityDbContext<ApplicationUser>
    {
        public CinemaTicketsContext(DbContextOptions<CinemaTicketsContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Crew Movie
            modelBuilder.Entity<Crew_Movie>().HasKey(x => new
            {
                x.CrewId,
                x.MovieId
            });
            modelBuilder.Entity<Crew_Movie>().HasOne(m => m.Movie).WithMany(x => x.Crew_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Crew_Movie>().HasOne(c => c.Crew).WithMany(x => x.Crew_Movies).HasForeignKey(c => c.CrewId);

            // Genres Movie
            modelBuilder.Entity<Genre_Movie>().HasKey(x => new
            {
                x.GenreId,
                x.MovieId
            });
            modelBuilder.Entity<Genre_Movie>().HasOne(m => m.Movie).WithMany(x => x.Genres_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Genre_Movie>().HasOne(w => w.Genre).WithMany(x => x.Genres_Movies).HasForeignKey(w => w.GenreId);

            // Show Time
            modelBuilder.Entity<Show_Time>().HasKey(x => new
            {
                x.ShowId,
                x.TimeId
            });
            modelBuilder.Entity<Show_Time>().HasOne(m => m.Show).WithMany(x => x.Show_Time).HasForeignKey(m => m.ShowId);
            modelBuilder.Entity<Show_Time>().HasOne(w => w.Time).WithMany(x => x.Show_Time).HasForeignKey(w => w.TimeId);
            
            // Movie
            modelBuilder.Entity<Movie>().HasOne(x => x.Country).WithMany().HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Movie>().HasOne(x => x.Language).WithMany().HasForeignKey(x => x.LanguageId).OnDelete(DeleteBehavior.SetNull);

            //Crew 
            modelBuilder.Entity<Crew>().HasOne(x => x.Nationality).WithMany().HasForeignKey(x => x.NationalityId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Crew>().HasOne(x => x.CrewRole).WithMany().HasForeignKey(x => x.CrewRoleId).OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Crew_Movie> Crew_Movies { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<Crew_Gallery> Crew_Gallery { get; set; }
        public DbSet<Crew_Role> Crews_Roles { get; set; } 
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Movie_Gallery> Movie_Gallery { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Show_Time> Show_Times { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Genre_Movie> Genres_Movies { get; set; }


    }
}
