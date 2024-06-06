namespace Book_store.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateOnly DateofBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
