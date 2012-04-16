using System;

namespace WhoIzIt.BLL.Service
{
    public class FacebookNotificationService : INotificationService
    {
        private string _token;
        public FacebookNotificationService(string token)
        {
            _token = token;
        }

        public void InviteAccepted(int challengerId)
        {
            throw new NotImplementedException();
        }

        public void InviteDeclined(int challengerId)
        {
            throw new NotImplementedException();
        }

        public void QuestionAsked(int p)
        {
            throw new NotImplementedException();
        }

        public void QuestionAnswered(int questionId)
        {
            throw new NotImplementedException();
        }

        public void GameOver(int gameId)
        {
            throw new NotImplementedException();
        }

        public void Invite(int id)
        {
            throw new NotImplementedException();
        }

        //public void GetFriends(string id)
        //{
        //    FacebookClient client = new FacebookClient(_token);
        //    dynamic friends = client.Get(String.Format("{0}/friends", id));

        //}
    }
}
