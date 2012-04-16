using System.Collections.Generic;

namespace WhoIzIt.Model
{
    public class Player : BaseEntity
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string FaceBookId { get; set; }
        public int Streak { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public virtual ICollection<Badge> Badges { get; set; }
        public int TotalPoints { get; set; }
        public string ImageUrl { get; set; }
    }
}
