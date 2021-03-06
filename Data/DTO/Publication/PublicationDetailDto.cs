using System;
using System.Collections.Generic;
using Library.Data.DTO.Author;
using Library.Data.DTO.Genre;
using Library.Data.DTO.Publisher;

namespace Library.Data.DTO.Publication
{
    public class PublicationDetailDto
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public AuthorDetailDto Author { get; set; }
        public PublisherDetailDto Publisher { get; set; }
        public int Pages { get; set; }
        public string Language { get; set; }
        public int Quantity { get; set; }
        public ICollection<GenreDetailDto> PublicationGenres { set; get; }
        public DateTime PublishedAt { get; set; }
    }
}