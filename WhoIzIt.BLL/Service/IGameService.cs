using System.Collections.Generic;
using WhoIzIt.BLL.Model;
using WhoIzIt.Model;

namespace WhoIzIt.BLL.Service
{
    public interface IGameService
    {
        void Invite(int challengerId, int opponentId);

        Game AcceptInvite(int challengerId, int opponentId);

        void DeclineInvite(int challengerId, int opponentId);

        Game CreateGame(Player challenger, Player opponent);

        void SelectGamePiece(int playerId, int gameId, int gamePieceId);

        void AskQuestion(int gameId, int playerId, string questionText);

        void AnswerQuestion(int questionId, Answer answer);

        bool Guess(int gameId, int playerId, int gamePieceId);

        IEnumerable<Friend> GetFriends(string id);

        IEnumerable<Game> GetGames(string id);
    }
}
