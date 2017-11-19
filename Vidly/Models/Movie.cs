using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Videosity.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public byte NumberInStock { get; set; }

        [Required]
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
    }
}