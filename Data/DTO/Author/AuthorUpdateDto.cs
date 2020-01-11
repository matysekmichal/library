using System;
using System.Collections.Generic;
using Library.Data.DTO.Borrower;
using Library.Data.DTO.Genre;
using Library.Models;

namespace Library.Data.DTO.Author
{
    public class AuthorUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}