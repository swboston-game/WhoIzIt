﻿using System;
using System.Collections.Generic;
using System.Linq;
using WhoIzIt.Model;

namespace WhoIzIt.BLL.Service
{
    //TODO: if in the future we want to have multiple social networks or our own, this should be implemented per social network
    public class GamePiecesService : IGamePiecesService
    {
        //TODO: do some dependency injections (maybe for beta)
        private readonly WhozitEntities _context = null;

        public GamePiecesService()
        {
            _context = new WhozitEntities();
        }

        public GamePiecesService(WhozitEntities context)
        {
            _context = context;
        }

        public IEnumerable<GamePiece> GenerateGamePieces(int challengerId, int opponentId)
        {
            var challenger = _context.Players.Single(p => p.Id == challengerId);
            var opponent = _context.Players.Single(p => p.Id == opponentId);
            var challengerFacebookFriends = GetFaceBrookFriends((long)challenger.FaceBookId).ToList();
            var opponentFaceBookFriends = GetFaceBrookFriends((long)opponent.FaceBookId).ToList();
            challengerFacebookFriends.AddRange(opponentFaceBookFriends);
            var friends = challengerFacebookFriends.Distinct();
            var gamePieces = friends.Select(friend => new GamePiece
                                                          {
                                                              Id = _context.GamePieces.Count() + 1,
                                                              ImageUrl = GetImageUrlFromFaceBook(friend)
                                                          }).ToList();
            if (gamePieces.Count < 15)
            {
                var howManyNeeded = 15 - gamePieces.Count;
                gamePieces.AddRange(GetRandomGamePieces(howManyNeeded));
            }
            return gamePieces;
        }

        private IEnumerable<GamePiece> GetRandomGamePieces(int howManyNeeded)
        {
            var stockPieces = _context.GamePieces.ToList();
            var pieces = new List<GamePiece>();
            for (var i = 0; i < howManyNeeded; i++)
            {
                var random = new Random();
                var randomNumber = random.Next(0, stockPieces.Count);
                var gamePiece = stockPieces[randomNumber];
                pieces.Add(gamePiece);
                stockPieces.RemoveAt(randomNumber);
            }
            return pieces;
        }

        private string GetImageUrlFromFaceBook(long friend)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<long> GetFaceBrookFriends(long faceBookId)
        {
            throw new NotImplementedException();
        }
    }
}
