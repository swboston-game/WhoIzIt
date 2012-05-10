using System.Collections.Generic;
using System.Linq;
using WhoIzIt.BLL.Model;
using WhoIzIt.Model;

namespace WhoIzIt.BLL.Service
{
    public class LeaderBoardService : ILeaderBoardService
    {
        private readonly IWhoIzItDbContext _context;

        public LeaderBoardService(IWhoIzItDbContext context)
        {
            _context = context;
        }

        public IEnumerable<LeaderBoard> GetLeaderBoardByPoints(int totalRecords)
        {
            var players = _context.Players.OrderBy(p => p.TotalPoints).Take(totalRecords).ToList();
            return players.Select(player => new LeaderBoard
                                                {
                                                    DisplayName = player.DisplayName,
                                                    ImageUrl = player.ImageUrl,
                                                    TotalPoints = player.TotalPoints
                                                });
        }
    }
}
