using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RainbowEntertainment.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Genre")]
        public string strGenre { get; set; }
        //Navigational property
        public virtual ICollection<Movie> movies { get; set; }
    }
}