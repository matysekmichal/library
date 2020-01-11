using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Data;
using Library.Data.DTO;
using Library.Data.DTO.Reservation;
using Library.Data.Repository;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ReservationRepository _repository;

        public ReservationsController(DataContext dataContext, IMapper mapper, ReservationRepository repository)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var reservations = await _repository.List();
            
            return Ok(_mapper.Map<IEnumerable<ReservationListDto>>(reservations));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var reservation = _mapper.Map(await _repository.Get(id), new ReservationDetailDto());

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationCreateDto reservationStore)
        {
            try
            {
                var storeBorrower = await _repository.Create(new Reservation {BorrowerId = reservationStore.BorrowerId});

                foreach (var publication in reservationStore.PublicationsToReserve)
                {
                    _dataContext.ReservedPublications.Add(new ReservedPublication()
                    {
                        ReservationId = storeBorrower.Id,
                        PublicationId = publication
                    });
                }

                return Created($"/api/reservations/{storeBorrower.Id}", storeBorrower);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repository.Remove(id);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}