using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Data.DTO.Publisher;
using Library.Data.Repository;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : Controller
    {
        private readonly PublisherRepository _repository;
        private readonly IMapper _mapper;

        public PublisherController(PublisherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var publishers = await _repository.List();
            
            return Ok(_mapper.Map<IEnumerable<PublisherListDto>>(publishers));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var publisher = _mapper.Map(await _repository.Get(id), new PublisherDetailDto());

            if (publisher == null)
            {
                return NotFound();
            }
            
            return Ok(publisher);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(PublisherCreateDto publisherCreate)
        {
            try
            {
                var publisherToCreate = _mapper.Map(publisherCreate, new Publisher());
                var publisher = await _repository.Create(publisherToCreate);
                
                return Created($"/api/publishers/{publisher.Id}", publisher);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(PublisherUpdateDto publisherUpdate)
        {
            try
            {
                var publisher = _mapper.Map(publisherUpdate, new Publisher());
                await _repository.Update(publisher);
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