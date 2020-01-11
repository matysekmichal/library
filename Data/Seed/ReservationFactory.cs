using System.Collections.Generic;
using System.Linq;
using Bogus;
using Library.Data.Repository;
using Library.Models;

namespace Library.Data.Seed
{
    public class ReservationFactory : IFactory<Reservation>
    {
        private readonly BorrowerFactory _borrowerFactory;
        private readonly ReservationRepository _repository;

        private readonly Faker<Reservation> _faker = new Faker<Reservation>();

        public ReservationFactory(ReservationRepository repository, BorrowerFactory borrowerFactory)
        {
            _repository = repository;
            _borrowerFactory = borrowerFactory;
        }
        
        public Reservation Create()
        {
            Rules();
            return _repository.Create(_faker.Generate()).Result;
        }

        private void Rules()
        {
            _faker.RuleFor(f => f.BorrowerId, f => _borrowerFactory.Create().Id);
        }
    }
}