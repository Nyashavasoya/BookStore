using Microsoft.AspNetCore.Identity;

namespace Book_store.Data.Entities
{
    public class User: IdentityUser
    {
        public Guid Id { get; set; }
        public DateOnly DateofBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
