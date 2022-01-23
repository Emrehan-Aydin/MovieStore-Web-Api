using MovieStoreWebApi.Application.OrderOperations.Queries.GetAllQuery;
using MovieStoreWebApi.Application.OrderOperation.Command.AddOrderCommand;
using MovieStoreWebApi.Application.OrderOperation.Command.DeleteOrderCommand;
using MovieStoreWebApi.Application.OrderOperation.Command.UpdateOrderCommand;
using MovieStoreWebApi.Application.OrderOperation.Queries.GetByIdOrderQuery;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Order.OrderCrudModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public OrderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            GetAllOrderQuery query = new GetAllOrderQuery(_context,_mapper);
            var result = query.Handle(); 
           
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public IActionResult GetByName(int Id)
        {   
            GetByIdOrderQuery query = new GetByIdOrderQuery(_context,_mapper);
            query.Id=Id;
            GetByIdOrderQueryValidator Validator = new GetByIdOrderQueryValidator();
            Validator.ValidateAndThrow(query);
            var result = query.Handle();
            
            return Ok(result);
        }  
        [HttpPost("/AddNewOrder")] 
        public IActionResult AddNewActor([FromBody] CreateOrderModel newOrder)
        {
            CreateOrderCommand Cmc = new CreateOrderCommand(_context,_mapper);
            CreateOrderCommandValidator Validator = new CreateOrderCommandValidator();
            Cmc.createOrderModel = newOrder;
            Validator.ValidateAndThrow(Cmc);
            Cmc.Handle();
            return Ok();
        }
        [HttpPut("{Id}")] 
        public IActionResult UpdateOrder(int Id, [FromBody] UpdateOrderModel updatedModel)  
        {
            UpdateOrderCommand Umc = new UpdateOrderCommand(_context);
            UpdateOrderCommandValidator Validator = new UpdateOrderCommandValidator();
            Umc.Id = Id;
            Umc.updatedData = updatedModel;
            Validator.ValidateAndThrow(Umc);
            Umc.Handle();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteOrder(int Id)
        {
            DeleteOrderCommand Dmc = new DeleteOrderCommand(_context);
            DeleteOrderCommandValidator Validator = new DeleteOrderCommandValidator();
            Dmc.Id=Id;
            Validator.ValidateAndThrow(Dmc);
            Dmc.Handle();
            return Ok();
        }       
    }
}