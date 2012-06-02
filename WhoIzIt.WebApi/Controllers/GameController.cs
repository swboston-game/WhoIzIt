using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using WhoIzIt.BLL.Service;
using WhoIzIt.Model;

namespace WhoIzIt.WebApi.Controllers
{
    public class GameController : ApiController
    {
        //
        // GET: /api/game
        public IEnumerable<Game> Get(long facebookId, string token)
        {
            var context = new WhozitEntities();
            var notificationService = new FacebookNotificationService(token);
            var gamePiecesService = new GamePiecesService();
            var gameService = new GameService(context, notificationService, gamePiecesService);
            return gameService.GetGames(facebookId);
        }

        //
        // POST: /api/game
        public void Post(long facebookId, string token)
        {
            var context = new WhozitEntities();
            var notificationService = new FacebookNotificationService(token);
            var gamePiecesService = new GamePiecesService();
            var gameService = new GameService(context, notificationService, gamePiecesService);
            var invited = gameService.InviteRandomOpponent(facebookId);

            if (!invited) //no one was found, throw a not found exception
                throw new HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.NotFound));

        }

    }
}
