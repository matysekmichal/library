using System.Collections.Generic;
using System.Linq;
using Bogus;
using Library.Data.Repository;
using Library.Models;

namespace Library.Data.Seed
{
    public class BorrowerFactory : IFactory<Borrower>
    {
        private readonly BorrowerRepository _repository;

        private readonly Faker<Borrower> _faker = new Faker<Borrower>();

        public BorrowerFactory(BorrowerRepository repository)
        {
            _repository = repository;
        }
        
        public Borrower Create()
        {
            Rules();
            return _repository.Create(_faker.Generate()).Result;
        }

        private void Rules()
        {
            _faker.RuleFor(f => f.Name, f => f.Person.FirstName)
                .RuleFor(f => f.LastName, f => f.Person.LastName);
        }
    }
}