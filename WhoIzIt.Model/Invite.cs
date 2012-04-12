namespace WhoIzIt.Model
{
    public class Invite : BaseEntity
    {
        public Player Challenger { get; set; }
        public Player Opponent { get; set; }
        public InviteStatus Status { get; set; }
    }
}
