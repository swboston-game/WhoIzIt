using System.Collections.Generic;
using WhoIzIt.Model;

namespace WhoIzIt.BLL.Service
{
    public interface IGamePiecesService
    {
        ICollection<GamePiece> GenerateGamePieces(int challengerId, int opponentId);
    }
}
