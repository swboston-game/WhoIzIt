using System.Data.Entity;

namespace WhoIzIt.Model
{
    public class WhoIzItDbContext : DbContext, IWhoIzItDbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<GamePiece> GamePieces { get; set; }
        public DbSet<StockGamePiece> StockGamePieces { get; set; }
        public DbSet<Badge> Badges { get; set; }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
