using System.Collections.Generic;
using System.Web.Http;
using WhoIzIt.BLL.Model;
using WhoIzIt.BLL.Service;
using WhoIzIt.Model;

namespace WhoIzIt.WebApi.Controllers
{
    public class LeaderBoardController : ApiController
    {
        //
        // GET: /LeaderBoard/

        public IEnumerable<LeaderBoard> Get()
        {
            IWhoIzItDbContext context = new WhoIzItDbContext();
            ILeaderBoardService leaderBoardService = new LeaderBoardService(context);
            return leaderBoardService.GetLeaderBoardByPoints(10);
        }

    }
}
