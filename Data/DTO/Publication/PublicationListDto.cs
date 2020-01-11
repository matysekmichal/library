using System;
using System.Collections.Generic;
using Library.Data.DTO.Genre;
using Library.Models;

namespace Library.Data.DTO.Publication
{
    public class PublicationListDto
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Language { get; set; }
        public int Quantity { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}