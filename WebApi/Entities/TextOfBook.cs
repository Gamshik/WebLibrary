namespace Entities
{
    public class TextOfBook
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public BookPreview Book { get; set; }

        public string Text { get; set; }
    }
}
