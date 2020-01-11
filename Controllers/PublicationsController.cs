using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Data.DTO.Publication;
using Library.Data.Repository;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicationsController : Controller
    {
        private readonly PublicationRepository _repository;
        private readonly IMapper _mapper;

        public PublicationsController(PublicationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var publications = await _repository.List();
            
            return Ok(_mapper.Map<IEnumerable<PublicationListDto>>(publications));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var publication = _mapper.Map(await _repository.Get(id), new PublicationDetailDto());

            if (publication == null)
            {
                return NotFound();
            }
            
            return Ok(publication);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(PublicationUpdateDto publicationUpdate)
        {
            try
            {
                var publicationToCreate = _mapper.Map(publicationUpdate, new Publication());
                var publication = await _repository.Create(publicationToCreate);
                
                return Created($"/api/publications/{publication.Id}", publication);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(PublicationCreateDto publicationCreate)
        {
            try
            {
                var publication = _mapper.Map(publicationCreate, new Publication());
                await _repository.Update(publication);
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