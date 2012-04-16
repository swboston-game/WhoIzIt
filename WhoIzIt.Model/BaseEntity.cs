using System;

namespace WhoIzIt.Model
{
    public abstract class BaseEntity
    {
        internal BaseEntity()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}