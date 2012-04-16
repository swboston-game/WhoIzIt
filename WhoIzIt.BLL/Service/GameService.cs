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
        private readonly IWhoIzItDbContext _context = null;
        private readonly INotificationService _notificationService = null;
        private readonly IGamePiecesService _gamePiecesService = null;

        public GameService(IWhoIzItDbContext context, INotificationService notificationService, IGamePiecesService gamePieceService)
        {
            _context = context;
            _notificationService = notificationService;
            _gamePiecesService = gamePieceService;
        }

        public void Invite(int challengerId, int opponentId)
        {
            var invite = new Invite
                             {
                                 Challenger = { Id = challengerId },
                                 Opponent = { Id = opponentId },
                                 Status = InviteStatus.Waiting
                             };
            _context.Invites.Add(invite);
            _context.SaveChanges();
            _notificationService.Invite(invite.Id);
        }

        public Game AcceptInvite(int challengerId, int opponentId)
        {
            var invite =
                _context.Invites.Single(
                    i =>
                    i.Challenger.Id == challengerId && i.Opponent.Id == opponentId && i.Status == InviteStatus.Waiting);
            invite.Status = InviteStatus.Accepted;
            invite.UpdatedOn = DateTime.Now;
            _context.SaveChanges();
            _notificationService.InviteAccepted(challengerId);
            var game = CreateGame(invite.Challenger, invite.Opponent);
            return game;
        }

        public void DeclineInvite(int challengerId, int opponentId)
        {
            var invite =
                _context.Invites.Single(
                    i =>
                    i.Challenger.Id == challengerId && i.Opponent.Id == opponentId && i.Status == InviteStatus.Waiting);
            invite.Status = InviteStatus.Declined;
            invite.UpdatedOn = DateTime.Now;
            _context.SaveChanges();
            _notificationService.InviteDeclined(challengerId);
        }

        public Game CreateGame(Player challenger, Player opponent)
        {
            var game = new Game
                           {
                               Challenger = challenger,
                               Opponent = opponent,
                               Status = GameStatus.SettingUp,
                               GamePieces = _gamePiecesService.GenerateGamePieces(challenger.Id, opponent.Id)
                           };
            _context.Games.Add(game);
            _context.SaveChanges();
            return game;
        }

        public void SelectGamePiece(int playerId, int gameId, int gamePieceId)
        {
            var game = _context.Games.Single(g => g.Id == gameId);
            if (game.Challenger.Id == playerId)
            {
                game.ChallengerSelection.Id = gamePieceId;
            }
            else
            {
                game.OpponenetSelection.Id = gamePieceId;
            }
            if (game.ChallengerSelection != null && game.OpponenetSelection != null)
            {
                game.Status = GameStatus.InProgress;
                game.PlayersMove = game.Opponent;
            }
            game.UpdatedOn = DateTime.Now;
            _context.SaveChanges();
        }

        public void AskQuestion(int gameId, int playerId, string questionText)
        {
            var question = new Question { QuestionText = questionText, Status = QuestionStatus.UnAnswered };
            var game = _context.Games.Single(g => g.Id == gameId);
            game.Questions.Add(question);
            _context.SaveChanges();
            _notificationService.QuestionAsked(question.Id);
        }

        public void AnswerQuestion(int questionId, Answer answer)
        {
            var question = _context.Questions.Single(q => q.Id == questionId);
            question.Answer = answer;
            question.Status = QuestionStatus.Answered;
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
                if (game.ChallengerSelection.Id == gamePieceId)
                {
                    game.Winner = game.Opponent;
                    won = true;
                }
                game.Winner = game.Challenger;
            }
            else
            {
                if (game.OpponenetSelection.Id == gamePieceId)
                {
                    game.Winner = game.Challenger;
                    game.Status = GameStatus.Completed;
                    won = true;
                }
                game.Winner = game.Opponent;
            }
            game.Status = GameStatus.Completed;
            game.UpdatedOn = DateTime.Now;
            _context.SaveChanges();
            _notificationService.GameOver(gameId);
            return won;
        }

        public ICollection<Friend> GetFriends(string id)
        {
            return null;
        }
    }
}
