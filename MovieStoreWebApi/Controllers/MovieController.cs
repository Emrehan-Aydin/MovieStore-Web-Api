using MovieStoreWebApi.Application.MovieOperations.Queries.GetAllQuery;
using MovieStoreWebApi.Application.MovieOperation.Command.AddActorToMovie;
using MovieStoreWebApi.Application.MovieOperation.Command.AddMovieCommand;
using MovieStoreWebApi.Application.MovieOperation.Command.DeleteMovieCommand;
using MovieStoreWebApi.Application.MovieOperation.Command.UpdateMovieCommand;
using MovieStoreWebApi.Application.MovieOperation.Queries.GetByNameMovieQuery;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Movie.MovieCrudModels;
using MovieStoreWebApi.DTo.MovieAndActor.MoviesActorCrudModels;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public MovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            GetAllMovieQuery query = new GetAllMovieQuery(_context,_mapper);
            var result = query.Handle(); 
           
            return Ok(result);
        }
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            GetByNameMovieQuery query = new GetByNameMovieQuery(_context,_mapper);
            query.name = name;

            var result = query.Handle();
            return Ok(result);
        }
        [HttpPost("/AddNewActorToMovie")] 
        public IActionResult AddNewActorToMovie([FromBody] CreateNewMoviesActor newMovieToActor)
        {
            AddActorToMovieCommand Cmc = new AddActorToMovieCommand(_context,_mapper);
            Cmc.newMoviesActor = newMovieToActor;
            
            Cmc.Handle();
            return Ok();
        }  
        [HttpPost("/AddNeMovie")] 
        public IActionResult AddNewMovie([FromBody] CreateMovieModel newMovie)
        {
            CreateMovieCommand Cmc = new CreateMovieCommand(_context,_mapper);
            Cmc.createMovieModel=newMovie;
            
            Cmc.Handle();
            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateMovie(int Id, [FromBody] UpdateMovieModel updatedModel)  
        {
            UpdateMovieCommand Umc = new UpdateMovieCommand(_context);
            Umc.Id = Id;
            Umc.updatedData = updatedModel;
            Umc.Handle();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteMovie(int Id)
        {
            DeleteMovieCommand Dmc = new DeleteMovieCommand(_context);
            Dmc.Id = Id;
            Dmc.Handle();
            return Ok();
        }
    }

    
}