using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Data.DTO.Genre;
using Library.Data.Repository;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : Controller
    {
        private readonly GenreRepository _repository;
        private readonly IMapper _mapper;

        public GenresController(GenreRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var genres = await _repository.List();
            
            return Ok(_mapper.Map<IEnumerable<GenreListDto>>(genres));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var genre = _mapper.Map(await _repository.Get(id), new GenreDetailDto());

            if (genre == null)
            {
                return NotFound();
            }
            
            return Ok(genre);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(GenreCreateDto genreCreate)
        {
            try
            {
                var genreToCreate = _mapper.Map(genreCreate, new Genre());
                var genre = await _repository.Create(genreToCreate);
                
                return Created($"/api/genres/{genre.Id}", genre);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(GenreUpdateDto genreUpdate)
        {
            try
            {
                var genre = _mapper.Map(genreUpdate, new Genre());
                await _repository.Update(genre);
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