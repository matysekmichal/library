using System.Collections.Generic;
using System.Linq;
using Bogus;
using Library.Data.Repository;
using Library.Models;

namespace Library.Data.Seed
{
    public class AuthorFactory : IFactory<Author>
    {
        private readonly AuthorRepository _repository;
        private readonly Faker<Author> _faker = new Faker<Author>()
            .RuleFor(f => f.Name, f => $"{f.Person.FirstName} {f.Person.LastName}");

        public AuthorFactory(AuthorRepository repository)
        {
            _repository = repository;
        }
        
        public Author Create()
        {
            return _repository.Create(_faker.Generate()).Result;
        }
    }
}