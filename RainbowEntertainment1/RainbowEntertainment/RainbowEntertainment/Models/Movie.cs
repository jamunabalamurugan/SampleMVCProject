using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RainbowEntertainment.Models
{
    public class Movie
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "Please provide the Movie name.")]
        [StringLength(255, ErrorMessage = "The name of the Movie cannot have more than 255 characters.")]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Required(ErrorMessage = "Please provide the Director name.")]
        [StringLength(50, ErrorMessage = "The name of the movie Director cannot have more than 50 characters.")]
        [Display(Name = "Director")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Please provide the Producer name.")]
        [StringLength(50, ErrorMessage = "The Producer name cannot have more than 50 characters.")]
        [Display(Name = "Producer")]
        public string Producer { get; set; }

        [Required(ErrorMessage = "Please provide the star cast.")]
        [StringLength(255, ErrorMessage = "Star cast cannot have more than 255 characters.")]
        [Display(Name = "Star Cast")]
        public string Cast { get; set; }

        [Required(ErrorMessage = "Please provide the duration of a movie.")]
        [Range(1, 240, ErrorMessage = "The duration of a movie should be between 1 and 240 minutes.")]
        [Display(Name = "Duration (minutes)")]
        public int Duration { get; set; }

        [StringLength(255, ErrorMessage = "The movie description can not have more than 255 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description;


        //Navigational Property
        public virtual Genre genre { get; set; }

        //Foreign Key
        public int GenreID { get; set; }

    }
}