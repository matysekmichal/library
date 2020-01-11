namespace Library.Models
{
    public class PublicationGenre
    {
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}