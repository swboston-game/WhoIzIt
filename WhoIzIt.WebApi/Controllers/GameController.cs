using System.Collections.Generic;
using System.Web.Http;
using WhoIzIt.BLL.Service;
using WhoIzIt.Model;

namespace WhoIzIt.WebApi.Controllers
{
    public class GameController : ApiController
    {
        //
        // GET: /Game/
        public IEnumerable<Game> Get(long facebookId, string token)
        {
            var context = new WhozitEntities();
            var notificationService = new FacebookNotificationService(token);
            var gamePiecesService = new GamePiecesService();
            var gameService = new GameService(context, notificationService, gamePiecesService);
            return gameService.GetGames(facebookId);
        }

    }
}
