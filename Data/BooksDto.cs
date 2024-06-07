namespace Book_Store.Data
{
    public class BooksDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateOnly PublishedDate { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public decimal price { get; set; }
        public int numberOfBooks { get; set; }
    }
}
