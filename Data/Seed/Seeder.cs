using Library.Models;

namespace Library.Data.Seed
{
    public class Seeder
    {
        public Seeder(
            DataContext dataContext,
            AuthorFactory authorFactory,
            GenreFactory genreFactory,
            PublicationFactory publicationFactory,
            ReservationFactory reservationFactory
        )
        {
            var author = authorFactory.Create();
            var genre = genreFactory.Create();
            var publication = publicationFactory.Create();
            var reservation = reservationFactory.Create();
            
            var authorGenre = new AuthorGenre()
            {
                AuthorId = author.Id,
                GenreId = genre.Id
            };
            dataContext.AuthorGenres.Add(authorGenre);

            var publicationGenre = new PublicationGenre
            {
                PublicationId = publication.Id,
                GenreId = genre.Id
            };
            dataContext.PublicationGenres.Add(publicationGenre);
            
            var reservedPublication = new ReservedPublication()
            {
                PublicationId = publication.Id,
                ReservationId = reservation.Id
            };
            dataContext.ReservedPublications.Add(reservedPublication);

            dataContext.SaveChanges();
        }
    }
}