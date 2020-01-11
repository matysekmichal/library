using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Data.DTO.Borrower;
using Library.Data.Repository;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowerController : Controller
    {
        private readonly BorrowerRepository _repository;
        private readonly IMapper _mapper;

        public BorrowerController(BorrowerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var borrowers = await _repository.List();
            
            return Ok(_mapper.Map<IEnumerable<BorrowerListDto>>(borrowers));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var borrower = _mapper.Map(await _repository.Get(id), new BorrowerDetailDto());

            if (borrower == null)
            {
                return NotFound();
            }
            
            return Ok(borrower);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(BorrowerCreateDto borrowerCreate)
        {
            try
            {
                var borrowerToCreate = _mapper.Map(borrowerCreate, new Borrower());
                var borrower = await _repository.Create(borrowerToCreate);
                
                return Created($"/api/borrowers/{borrower.Id}", borrower);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(BorrowerUpdateDto borrowerUpdate)
        {
            try
            {
                var borrower = _mapper.Map(borrowerUpdate, new Borrower());
                await _repository.Update(borrower);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            
            return NoContent();
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