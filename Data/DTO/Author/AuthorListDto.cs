using System;
using System.Collections.Generic;
using Library.Data.DTO.Genre;

namespace Library.Data.DTO.Author
{
    public class AuthorListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}