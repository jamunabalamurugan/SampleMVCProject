namespace RainbowEntertainment.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RainbowEntertainment.DatabaseContext.MovieDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RainbowEntertainment.DatabaseContext.MovieDbContext context)
        {
            context.Genres.AddOrUpdate(m => m.strGenre, new Models.Genre { strGenre = "Action" }, new Models.Genre { strGenre = "Drama" }, new Models.Genre { strGenre = "Romance" }, new Models.Genre { strGenre = "Adventure" }, new Models.Genre { strGenre = "Comedy" }, new Models.Genre { strGenre = "Animation" }, new Models.Genre { strGenre = "Documentary" });
           
        }
    }
}
