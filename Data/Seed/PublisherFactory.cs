using System.Collections.Generic;
using System.Linq;
using Bogus;
using Library.Data.Repository;
using Library.Models;

namespace Library.Data.Seed
{
    public class PublisherFactory : IFactory<Publisher>
    {
        private readonly PublisherRepository _repository;
        private readonly Faker<Publisher> _faker = new Faker<Publisher>()
            .RuleFor(f => f.Name, f => f.Company.CompanyName());

        public PublisherFactory(PublisherRepository repository)
        {
            _repository = repository;
        }
        
        public Publisher Create()
        {
            return _repository.Create(_faker.Generate()).Result;
        }
    }
}