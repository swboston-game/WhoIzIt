using System.ComponentModel.DataAnnotations;

namespace WhoIzIt.Model
{
    public class Badge : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int WinsNeeded { get; set; }
        public int StreakNeeded { get; set; }
        public int LosesNeeded { get; set; }
    }
}
