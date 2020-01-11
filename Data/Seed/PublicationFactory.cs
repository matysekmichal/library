using System.Collections.Generic;
using Bogus;
using Library.Data.Repository;
using Library.Models;

namespace Library.Data.Seed
{
    public class PublicationFactory : IFactory<Publication>
    {
        private readonly PublicationRepository _repository;
        private readonly AuthorFactory _authorFactory;
        private readonly PublisherFactory _publisherFactory;

        private readonly Faker<Publication> _faker = new Faker<Publication>();

        public PublicationFactory(PublicationRepository repository, AuthorFactory authorFactory, PublisherFactory publisherFactory)
        {
            _repository = repository;
            _authorFactory = authorFactory;
            _publisherFactory = publisherFactory;
        }
        
        public Publication Create()
        {
            Rules();
            return _repository.Create(_faker.Generate()).Result;
        }

        private void Rules()
        {
            _faker.RuleFor(f => f.ISBN, f => f.Random.Replace("###-##-######-#-#"))
                .RuleFor(f => f.Name, f => f.Lorem.Sentence().Replace(".", ""))
                .RuleFor(f => f.AuthorId, f => _authorFactory.Create().Id)
                .RuleFor(f => f.PublisherId, f => _publisherFactory.Create().Id)
                .RuleFor(f => f.Language, f => f.PickRandom(new List<string>(){"pl", "en", "fr", "de", "ru"}))
                .RuleFor(f => f.Pages, f => f.Random.Int(50, 1400))
                .RuleFor(f => f.Quantity, f => f.Random.Int(0, 10))
                .RuleFor(f => f.PublishedAt, f => f.Date.Past());
        }
    }
}