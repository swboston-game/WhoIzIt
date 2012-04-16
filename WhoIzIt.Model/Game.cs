using System.Collections.Generic;

namespace WhoIzIt.Model
{
    public class Game : BaseEntity
    {
        public Player Challenger { get; set; }
        public Player Opponent { get; set; }
        public virtual ICollection<GamePiece> GamePieces { get; set; }
        public GameStatus Status { get; set; }
        public GamePiece ChallengerSelection { get; set; }
        public GamePiece OpponenetSelection { get; set; }
        public Player Winner { get; set; }
        public Player PlayersMove { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}