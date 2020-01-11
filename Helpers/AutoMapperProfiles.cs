using System.Linq;
using AutoMapper;
using Library.Data.DTO.Author;
using Library.Data.DTO.Borrower;
using Library.Data.DTO.Genre;
using Library.Data.DTO.Publication;
using Library.Data.DTO.Publisher;
using Library.Data.DTO.Reservation;
using Library.Models;
using BorrowerDetailDto = Library.Data.DTO.Borrower.BorrowerDetailDto;

namespace Library.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Reservation, ReservationListDto>()
                .ForMember(dest => dest.ReservedPublications,
                    opt => opt.MapFrom(
                        src => src.ReservedPublications.Select(x => x.Publication)
                    )
                );
            
            CreateMap<Author, AuthorListDto>();
            CreateMap<Borrower, BorrowerListDto>();
            CreateMap<Genre, GenreListDto>();
            CreateMap<Publication, PublicationListDto>();
            CreateMap<Publisher, PublisherListDto>();

            CreateMap<Author, AuthorDetailDto>();
            CreateMap<Borrower, BorrowerDetailDto>();
            CreateMap<Genre, GenreDetailDto>();
            CreateMap<Publication, PublicationDetailDto>();
            CreateMap<Publisher, PublisherDetailDto>();
            CreateMap<Reservation, ReservationDetailDto>();
            
            CreateMap<AuthorCreateDto, Author>();
            CreateMap<BorrowerCreateDto, Borrower>();
            CreateMap<GenreCreateDto, Genre>();
            CreateMap<PublicationCreateDto, Publication>();
            CreateMap<PublisherCreateDto, Publisher>();
            CreateMap<ReservationCreateDto, Reservation>();
            
            CreateMap<AuthorUpdateDto, Author>();
            CreateMap<BorrowerUpdateDto, Borrower>();
            CreateMap<GenreUpdateDto, Genre>();
            CreateMap<PublicationUpdateDto, Publication>();
            CreateMap<PublisherUpdateDto, Publisher>();
        }
    }
}