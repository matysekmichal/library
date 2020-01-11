using System;
using System.Collections.Generic;
using Library.Data.DTO.Author;
using Library.Data.DTO.Publication;

namespace Library.Data.DTO.Genre
{
    public class GenreDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<AuthorDetailDto> AuthorGenres { get; set; }
        public ICollection<PublicationDetailDto> PublicationGenres { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}