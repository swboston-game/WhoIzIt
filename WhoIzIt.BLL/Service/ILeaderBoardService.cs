
using System.Collections.Generic;
using WhoIzIt.BLL.Model;
namespace WhoIzIt.BLL.Service
{
    public interface ILeaderBoardService
    {
        IEnumerable<LeaderBoard> GetLeaderBoardByPoints(int totalRecords);
    }
}
