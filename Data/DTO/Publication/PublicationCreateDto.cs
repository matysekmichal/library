using System;

namespace Library.Data.DTO.Publication
{
    public class PublicationCreateDto
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int Pages { get; set; }
        public string Language { get; set; }
        public int Quantity { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}