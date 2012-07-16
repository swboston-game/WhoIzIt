using System;
using System.Collections.Generic;
using System.Linq;
using WhoIzIt.BLL.Model;
using WhoIzIt.Model;

namespace WhoIzIt.BLL.Service
{
    public class GameService : IGameService
    {
        //TODO: do some dependency injections (maybe for beta)
        private readonly WhozitEntities _context = null;
        private readonly INotificationService _notificationService = null;
        private readonly IGamePiecesService _gamePiecesService = null;

        public GameService(WhozitEntities context, INotificationService notificationService, IGamePiecesService gamePieceService)
        {
            _context = context;
            _notificationService = notificationService;
            _gamePiecesService = gamePieceService;
        }

        public void Invite(long challengerId, long opponentId)
        {
            //TODO: do the actual invite!
        }

        public bool InviteRandomOpponent(long challengerId)
        {
            var qry = _context.Players.Select(p => p.FaceBookId); //TODO: only get the online ones
            int count = qry.Count();
            if (count == 0)
                return false;

            int index = new Random().Next(count);
            var opponentId = qry.Skip(index).FirstOrDefault();

            if (!opponentId.HasValue)
                return false;

            Invite(challengerId, opponentId.Value);

            return true;
        }

        public Game AcceptInvite(long challengerId, long opponentId)
        {
            var challenger = _context.Players.First(p => p.Id == challengerId);
            var opponent = _context.Players.First(p => p.Id == opponentId);
            var game = CreateGame(challenger, opponent);
            return game;
        }

        public void DeclineInvite(long challengerId, long opponentId)
        {

        }

        public Game CreateGame(Player challenger, Player opponent)
        {
            var game = new Game
                           {
                               Challenger = challenger,
                               Opponent = opponent,
                               GameStatus = _context.GameStatus1.First(s => s.Status == "Create"),
                           };
            _context.Games.Attach(game);
            _context.SaveChanges();
            return game;
        }

        public void SelectGamePiece(int playerId, int gameId, int gamePieceId)
        {
            var game = _context.Games.Single(g => g.Id == gameId);
            if (game.Challenger.Id == playerId)
            {
                game.ChallengerPiece.Id = gamePieceId;
            }
            else
            {
                game.OpponentsPiece.Id = gamePieceId;
            }
            if (game.ChallengerPiece != null && game.OpponentsPiece != null)
            {
                game.GameStatus.Status = "InProgress";
                game.PlayersMove = game.Opponent;
            }
            game.UpdatedOn = DateTime.Now;
            _context.SaveChanges();
        }

        public void AskQuestion(int gameId, int playerId, string questionText)
        {
            var question = new Question { QuestionText = questionText };
            var game = _context.Games.Single(g => g.Id == gameId);
            game.QuestionsAskeds.Add(question);
            _context.SaveChanges();
            _notificationService.QuestionAsked(question.Id);
        }

        public void AnswerQuestion(int questionId, string answer)
        {
            var question = _context.Questions.Single(q => q.Id == questionId);
            question.UpdatedOn = DateTime.Now;
            _context.SaveChanges();
            _notificationService.QuestionAnswered(questionId);
        }

        public bool Guess(int gameId, int playerId, int gamePieceId)
        {
            var game = _context.Games.Single(g => g.Id == gameId);
            var won = false;
            if (game.Opponent.Id == playerId)
            {
                if (game.ChallengerPiece.Id == gamePieceId)
                {
                    game.Winner = game.Opponent;
                    won = true;
                }
                game.Winner = game.Challenger;
            }
            else
            {
                if (game.OpponentsPiece.Id == gamePieceId)
                {
                    game.Winner = game.Challenger;
                    game.GameStatus.Status = "Completed";
                    won = true;
                }
                game.Winner = game.Opponent;
            }
            game.GameStatus.Status = "Completed";
            game.UpdatedOn = DateTime.Now;
            _context.SaveChanges();
            _notificationService.GameOver(gameId);
            return won;
        }

        public IEnumerable<Friend> GetFriends(long id)
        {
            return null;
        }

        public IEnumerable<Game> GetGames(long id)
        {
            return _context.Games.Where(g => g.Opponent.FaceBookId == id || g.Challenger.FaceBookId == id).AsEnumerable();
        }
    }
}
