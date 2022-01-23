using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Actor.ActorCrudModels;
using MovieStoreWebApi.DTo.MovieAndActor.MoviesActorCrudModels;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Application.ActorOperation.Command.AddActorCommand;
using MovieStoreWebApi.Application.ActorOperation.Command.AddMovieToActorCommand;
using MovieStoreWebApi.Application.ActorOperation.Command.DeleteActorCommand;
using MovieStoreWebApi.Application.ActorOperation.Command.UpdateActorCommand;
using MovieStoreWebApi.Application.ActorOperation.Queries.GetByNameActorQuery;
using MovieStoreWebApi.Application.ActorOperations.Queries.GetAllQuery;

namespace MovieStoreWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ActorController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            GetAllActorQuery query = new GetAllActorQuery(_context,_mapper);
            var result = query.Handle(); 
           
            return Ok(result);
        }
        [HttpGet("{name},{surname}")]
        public IActionResult GetByName(string name,string surname)
        {
            
            GetByNameActorQuery query = new GetByNameActorQuery(_context,_mapper);
            query.name = name;
            query.surname=surname;
            GetByNameActorQueryValidator validator = new GetByNameActorQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            
            return Ok(result);
        }  
        [HttpPost("/AddNewActor")] 
        public IActionResult AddNewActor([FromBody] CreateActorModel newActor)
        {
            CreateActorCommand Cmc = new CreateActorCommand(_context,_mapper);
            Cmc.Model = newActor;

            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            validator.ValidateAndThrow(Cmc);

            Cmc.Handle();

            return Ok();
        }
        [HttpPost("/AddMovieToActor")] 
        public IActionResult AddNewMovieToActor([FromBody] CreateNewMoviesActor newMovieToActor)
        {
            AddMovieToActorCommand Cmc = new AddMovieToActorCommand(_context,_mapper);
            Cmc.newMoviesActorModel = newMovieToActor;
            AddMovieToActorCommandValidator validator = new AddMovieToActorCommandValidator();

            validator.ValidateAndThrow(Cmc);
            Cmc.Handle();

            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateActor(int Id, [FromBody] UpdateActorModel updatedModel)  
        {
            UpdateActorCommand Umc = new UpdateActorCommand(_context);
            Umc.Id = Id;
            Umc.updatedData = updatedModel;
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            validator.ValidateAndThrow(Umc);
            Umc.Handle();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteActor(int Id)
        {
            DeleteActorCommand Dmc = new DeleteActorCommand(_context);
            Dmc.Id = Id;
            DeleteActorCommandValdiator valdiator = new DeleteActorCommandValdiator();
            valdiator.ValidateAndThrow(Dmc);
            Dmc.Handle();
            return Ok();
        }       
    }
}