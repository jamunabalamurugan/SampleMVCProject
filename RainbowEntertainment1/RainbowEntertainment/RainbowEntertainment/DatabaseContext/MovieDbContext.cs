using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RainbowEntertainment.DatabaseContext
{
    public class MovieDbContext : System.Data.Entity.DbContext
    {
        public MovieDbContext()
            : base("DefaultConnection")
        {

        }
        public System.Data.Entity.DbSet<RainbowEntertainment.Models.Movie> Movies { get; set; }
        public System.Data.Entity.DbSet<RainbowEntertainment.Models.Genre> Genres { get; set; }
    }
}