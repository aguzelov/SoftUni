using System.Data.Entity;

namespace AnimeList.Models
{
    public class AnimeListDbContext : DbContext
    {
        public virtual IDbSet<Anime> Animes { get; set; }

        public AnimeListDbContext() : base("AnimeList")
        {
        }
    }
}