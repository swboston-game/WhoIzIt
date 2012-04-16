using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIzIt.Model
{
    public interface IWhoIzItDbContext
    {
        DbSet<Game> Games { get; set; }
        DbSet<Player> Players { get; set; }
        DbSet<Invite> Invites { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<GamePiece> GamePieces { get; set; }
        DbSet<StockGamePiece> StockGamePieces { get; set; }
        DbSet<Badge> Badges { get; set; }

        int SaveChanges();
    }
}
