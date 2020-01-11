using System;
using System.Collections.Generic;
using Library.Data.DTO.Publication;

namespace Library.Data.DTO.Publisher
{
    public class PublisherDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PublicationDetailDto> Publications { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}