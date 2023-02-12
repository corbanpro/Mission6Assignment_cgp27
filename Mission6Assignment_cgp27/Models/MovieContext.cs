using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Assignment_cgp27.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Category = "Action",
                    Title = "Avengers, Infinity War",
                    Year = 2018,
                    Director = "Anthony and Joe Russo",
                    Rating = "PG-13",
                    Edited = true
                },
                new Movie
                {
                    MovieId = 2,
                    Category = "Fantasy",
                    Title = "The Lord of the Rings: The Return of the King",
                    Year = 2003,
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Jacob",
                    Notes = "My Favorite Movie Ever"
                },
                new Movie
                {
                    MovieId = 3,
                    Category = "Comedy",
                    Title = "Napoleon Dynamite",
                    Year = 2004,
                    Director = "Jared Hess",
                    Rating = "PG",
                    LentTo = "Rachel",
                    Notes = "Funniest Movie Ever"
                }
            );
        }
    }
}
