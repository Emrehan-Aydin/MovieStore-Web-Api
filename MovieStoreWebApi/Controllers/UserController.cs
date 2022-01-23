using MovieStoreWebApi.Application.UserOperations.Command.CreateToken;
using MovieStoreWebApi.Application.UserOperations.Command.CreateUser;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieStoreWebApi.TokenOperations.Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        readonly IConfiguration _configuration;
        public UserController(IMovieStoreDbContext context,IConfiguration configuration , IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_context,_mapper);
            command.model = newUser;
            command.Handle();

            return Ok();
        }
        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel Login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context,_mapper,_configuration);
            command.model = Login;
            var token = command.Handle();
            return token;
        }
    }
}