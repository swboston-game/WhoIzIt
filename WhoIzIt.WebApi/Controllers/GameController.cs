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
        public IEnumerable<Game> Get(string facebookId, string token)
        {
            IWhoIzItDbContext context = new WhoIzItDbContext();
            INotificationService notificationService = new FacebookNotificationService(token);
            IGamePiecesService gamePiecesService = new GamePiecesService();
            IGameService gameService = new GameService(context, notificationService, gamePiecesService);
            return gameService.GetGames(facebookId);
        }

    }
}
