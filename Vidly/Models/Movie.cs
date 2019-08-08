using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }
        [Display(Name = "Release Date")]
        [Column(TypeName = "DateTime2")]
        public DateTime? ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
    }

    // /movies/random
}