using MovieStoreWebApi.Application.GenreOperations.Queries.GetAllQuery;
using MovieStoreWebApi.Application.GenreOperation.Command.AddGenreCommand;
using MovieStoreWebApi.Application.GenreOperation.Command.DeleteGenreCommand;
using MovieStoreWebApi.Application.GenreOperation.Command.UpdateGenreCommand;
using MovieStoreWebApi.Application.GenreOperation.Queries.GetByNameGenreQuery;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Genre.GenreCrudModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class GenreController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GenreController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            GetAllGenreQuery query = new GetAllGenreQuery(_context,_mapper);
            var result = query.Handle(); 
           
            return Ok(result);
        }
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            
            GetByNameGenreQuery query = new GetByNameGenreQuery(_context,_mapper);
            query.name = name;
            GetByNameGenreQueryValidator Validator = new GetByNameGenreQueryValidator();
            Validator.ValidateAndThrow(query);
            //var result = query.Handle(name);
            var result = query.Handle();
            
            return Ok(result);
        }  
        [HttpPost] 
        public IActionResult AddNewGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand Cgc = new CreateGenreCommand(_context,_mapper);
            Cgc.createGenreModel = newGenre;
            CreateGenreCommandValidator Validator = new CreateGenreCommandValidator();
            Validator.ValidateAndThrow(Cgc);
            Cgc.Handle();
            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateGenre(int Id, [FromBody] UpdateGenreModel updatedModel)  
        {
            UpdateGenreCommand Ugc = new UpdateGenreCommand(_context);
            Ugc.Id = Id;
            Ugc.updatedData = updatedModel;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(Ugc);
            Ugc.Handle();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteGenre(int Id)
        {
            DeleteGenreCommand Dmc = new DeleteGenreCommand(_context);
            Dmc.Id = Id;
            DeleteGenreCommandValidator Validator = new DeleteGenreCommandValidator();
            Validator.ValidateAndThrow(Dmc);
            Dmc.Handle();
            return Ok();
        }
    }
}