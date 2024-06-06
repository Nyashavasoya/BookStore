using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_store.Data.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey("Book")]
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string ShippingAddress { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
