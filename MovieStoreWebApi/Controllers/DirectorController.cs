using MovieStoreWebApi.Application.DirectorOperations.Queries.GetAllQuery;
using MovieStoreWebApi.Application.DirectorOperation.Command.AddDirectorCommand;
using MovieStoreWebApi.Application.DirectorOperation.Command.DeleteDirectorCommand;
using MovieStoreWebApi.Application.DirectorOperation.Command.UpdateDirectorCommand;
using MovieStoreWebApi.Application.DirectorOperation.Queries.GetByNameDirectorQuery;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Director.DirectorCrudModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorController:ControllerBase
    {
         private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;

        public IMovieStoreDbContext Context => _context;

        public DirectorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            GetAllDirectorQuery query = new GetAllDirectorQuery(Context,_mapper);
            var result = query.Handle(); 
           
            return Ok(result);
        }
        [HttpGet("{name},{surname}")]
        public IActionResult GetByName(string name,string surname)
        {
            
            GetByNameDirectorQuery query = new GetByNameDirectorQuery(Context,_mapper);
            GetByNameDirectorQueryValidator Validator = new GetByNameDirectorQueryValidator();
            query.name = name;
            query.surname = surname;
            //var result = query.Handle(name);
            var result = query.Handle();
            
            return Ok(result);
        }  
        [HttpPost] 
        public IActionResult AddNewDirector([FromBody] CreateDirectorModel newDirector)
        {
            CreateDirectorCommand Cmc = new CreateDirectorCommand(Context,_mapper);
            Cmc.createDirectorModel = newDirector;
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            validator.ValidateAndThrow(Cmc);
            Cmc.Handle();
            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateDirector(int Id, [FromBody] UpdateDirectorModel updatedModel)  
        {
            UpdateDirectorCommand Udc = new UpdateDirectorCommand(Context);
            Udc.Id = Id;
            Udc.updatedModel = updatedModel;
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            Udc.Handle();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteDirector(int Id)
        {
            DeleteDirectorCommand Ddc = new DeleteDirectorCommand(Context);
            Ddc.Id = Id;
            DeleteDirectorCommandValidator Validator = new DeleteDirectorCommandValidator();
            Validator.ValidateAndThrow(Ddc);
            Ddc.Handle();
            return Ok();
        }       
    }
}