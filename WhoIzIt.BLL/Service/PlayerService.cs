using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Facebook;
using WhoIzIt.BLL.Model;
using WhoIzIt.Model;

namespace WhoIzIt.BLL.Service
{
    public class PlayerService
    {
        readonly WhoIzItDbContext _context = new WhoIzItDbContext();

        public void CreatePlayer(string email, string displayName, string faceBookId)
        {
            var player = new Player
            {
                DisplayName = displayName,
                Email = email,
                FaceBookId = faceBookId
            };
            player.TotalPoints += 1000;
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public void Won(int playerId)
        {
            var player = _context.Players.Single(p => p.Id == playerId);
            player.Wins += 1;
            player.Streak += 1;
            player.TotalPoints += 500;
            _context.SaveChanges();
        }

        public void Lost(int playerId)
        {
            var player = _context.Players.Single(p => p.Id == playerId);
            player.Loses += 1;
            player.Streak = 0;
            player.TotalPoints += 100;
            _context.SaveChanges();
        }

        public void IncreasePoints(int playerId, int points)
        {
            var player = _context.Players.Single(p => p.Id == playerId);
            player.TotalPoints += points;
            _context.SaveChanges();
        }

        public ICollection<Friend> GetFriends(string facebookId, string token)
        {
            FacebookClient client = new FacebookClient(token);
            var query = String.Format("SELECT uid, name, pic_square, online_presence FROM user WHERE uid IN (SELECT uid2 FROM friend WHERE uid1 = {0}) and online_presence in ('idle', 'active') order by online_presence", facebookId);
            dynamic parameters = new ExpandoObject();
            parameters.q = query;
            dynamic results = client.Get("/fql", parameters);

            var friends = results.data;
            ICollection<Friend> friendResult = new List<Friend>();
            if (friends != null)
            {
                foreach (dynamic friend in friends)
                {
                    friendResult.Add(new Friend { ID = friend.uid.ToString(), Name = friend.name, Status = (friend.online_presence == "active" ? FriendStatus.Online : FriendStatus.Idle) });
                }
            }
            return friendResult;
        }
    }
}
