using MovieStoreWebApi.Application.CustomerOperations.Queries.GetAllQuery;
using AutoMapper;
using MovieStoreWebApi.DTo.Customer.CustomerCrudModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Application.CustomerOperations.Command.AddCustomerCommand;
using MovieStoreWebApi.Application.CustomerOperations.Command.DeleteCustomerCommand;
using MovieStoreWebApi.Application.CustomerOperations.Command.UpdateCustomerCommand;
using MovieStoreWebApi.Application.CustomerOperation.Queries.GetByIdCustomerQuery;
using MovieStoreWebApi.DbOperations;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public CustomerController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            GetAllCustomerQuery query = new GetAllCustomerQuery(_context,_mapper);
            var result = query.Handle(); 
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            GetByIdCustomerQuery query = new GetByIdCustomerQuery(_context,_mapper);
            query.Id = Id;

            GetByIdCustomerQueryValidator validator = new GetByIdCustomerQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            
            return Ok(result);
        }  
        [HttpPost] 
        public IActionResult AddNewActor([FromBody] CreateCustomerModel newCustomer)
        {
            CreateCustomerCommand Cmc = new CreateCustomerCommand(_context,_mapper);
            Cmc.createCustomerModel = newCustomer;
            CreateCustomerCommandValidator Validator = new CreateCustomerCommandValidator();
            Validator.ValidateAndThrow(Cmc);
            Cmc.Handle(newCustomer);
            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateActor(int Id, [FromBody] UpdateCustomerModel updatedModel)  
        {
            UpdateCustomerCommand Umc = new UpdateCustomerCommand(_context);
            Umc.Id = Id;
            Umc.updatedData = updatedModel;
            UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
            Umc.Handle();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteActor(int Id)
        {
            DeleteCustomerCommand Dmc = new DeleteCustomerCommand(_context);
            Dmc.Id = Id;
            DeleteCustomerCommandValidator Validator = new DeleteCustomerCommandValidator();
            Validator.ValidateAndThrow(Dmc);
            Dmc.Handle();
            return Ok();
        }       
    }
}