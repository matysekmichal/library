using System.Collections.Generic;
using System.Linq;
using Bogus;
using Library.Data.Repository;
using Library.Models;

namespace Library.Data.Seed
{
    public class GenreFactory : IFactory<Genre>
    {
        private readonly GenreRepository _repository;

        private readonly Faker<Genre> _faker = new Faker<Genre>();

        public GenreFactory(GenreRepository repository)
        {
            _repository = repository;
        }
        
        public Genre Create()
        {
            Rules();
            return _repository.Create(_faker.Generate()).Result;
        }

        private void Rules()
        {
            _faker.RuleFor(f => f.Name, f => f.Lorem.Sentence(2).Replace(".", ""))
                .RuleFor(f => f.Description, f => f.Lorem.Sentence().ToString());
        }
    }
}