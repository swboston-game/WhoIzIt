using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WhoIzIt.BLL.Model;
using WhoIzIt.BLL.Service;

namespace WhoIzIt.WebApi.Controllers
{
    public class FriendsController : ApiController
    {
        // GET /api/friends?facebookID={0}&token={1}
        public IEnumerable<Friend> Get(string facebookID, string token)
        {
            PlayerService playerService = new PlayerService();
            var x = playerService.GetFriends(facebookID, token);

            return x.AsEnumerable();
        }

    }
}
