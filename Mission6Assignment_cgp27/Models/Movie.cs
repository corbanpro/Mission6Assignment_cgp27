using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Assignment_cgp27.Models
{
    public class Movie
    {
        [Required]
        [Key]
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Please Enter a Movie Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter the Release Year")]
        [Range(1900, 2023, ErrorMessage = "Invalid Year")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Please Enter the Director(s)")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Please Enter the Rating")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        [MaxLength(50)]
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }

        [Required(ErrorMessage = "Please Enter the Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
