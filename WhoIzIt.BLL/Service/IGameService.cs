using System.Collections.Generic;
using WhoIzIt.BLL.Model;
using WhoIzIt.Model;

namespace WhoIzIt.BLL.Service
{
    public interface IGameService
    {
        void Invite(long challengerId, long opponentId);

        bool InviteRandomOpponent(long challengetId);

        Game AcceptInvite(long challengerId, long opponentId);

        void DeclineInvite(long challengerId, long opponentId);

        Game CreateGame(Player challenger, Player opponent);

        void SelectGamePiece(int playerId, int gameId, int gamePieceId);

        void AskQuestion(int gameId, int playerId, string questionText);

        void AnswerQuestion(int questionId, string answer);

        bool Guess(int gameId, int playerId, int gamePieceId);

        IEnumerable<Friend> GetFriends(long id);

        IEnumerable<Game> GetGames(long id);
    }
}
