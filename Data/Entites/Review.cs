using System.ComponentModel.DataAnnotations;

namespace Book_store.Data.Entities
{
    public class Review
    {
        public Guid ReviewId { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } 

        public Guid BookId { get; set; } 
        public Book Book { get; set; }

        [Range(1, 6)]
        public int Rating { get; set; } 
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
