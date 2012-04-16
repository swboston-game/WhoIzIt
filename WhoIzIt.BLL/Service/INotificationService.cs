
namespace WhoIzIt.BLL.Service
{
    public interface INotificationService
    {
        void InviteAccepted(int challengerId);
        void InviteDeclined(int challengerId);
        void QuestionAsked(int p);
        void QuestionAnswered(int questionId);
        void GameOver(int gameId);
        void Invite(int id);
    }
}
