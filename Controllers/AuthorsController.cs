using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Data.DTO.Author;
using Library.Data.Repository;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly AuthorRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AuthorsController(AuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var authors = await _repository.List();
            
            return Ok(_mapper.Map<IEnumerable<AuthorListDto>>(authors));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var author = _mapper.Map(await _repository.Get(id), new AuthorDetailDto());

            if (author == null)
            {
                return NotFound();
            }
            
            return Ok(author);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(AuthorCreateDto authorCreate)
        {
            try
            {
                var publicationToCreate = _mapper.Map(authorCreate, new Author());
                var author = await _repository.Create(publicationToCreate);
                
                return Created($"/api/authors/{author.Id}", author);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(AuthorUpdateDto authorUpdate)
        {
            try
            {
                var publication = _mapper.Map(authorUpdate, new Author());
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