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

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Action"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Fantasy"
                });

            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "Avengers, Infinity War",
                    Year = 2018,
                    Director = "Anthony and Joe Russo",
                    Rating = "PG-13",
                    Edited = true
                },
                new Movie
                {
                    MovieId = 2,
                    CategoryId = 2,
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
                    CategoryId = 3,
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
