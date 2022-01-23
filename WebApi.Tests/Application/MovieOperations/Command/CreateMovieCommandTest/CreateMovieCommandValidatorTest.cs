using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Application.MovieOperation.Command.AddMovieCommand;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Movie.MovieCrudModels;
using WebApi.Tests.TestSetup;
using Xunit;

namespace WebApi.Tests.Application.MovieOperations.Command.CreateMovieCommandTest{
    public class CreateMovieCommandValidatorTest:IClassFixture<TestSetupFixture>
    {
        IMovieStoreDbContext _context;
        IMapper _mapper;
        public CreateMovieCommandValidatorTest(TestSetupFixture testSetupFixture)
        {
            _context = testSetupFixture.context;
            _mapper = testSetupFixture.mapper;
        }
        
        [Theory]
        [InlineData(""      ,1  ,1  ,1999   ,20)]
        [InlineData("ABCD"  ,0  ,1  ,1999   ,20)]
        [InlineData("ABCD"  ,1  ,0  ,1999   ,20)]
        [InlineData("ABCD"  ,1  ,1  ,1889   ,20)]
        [InlineData("ABCD"  ,1  ,1  ,1999   ,0)]
        public void InvalidInput_CreateMovie_ReturnBeValidationException(string MovieName, int DId, int GId,int Year,double Mp)
        {
            var InvalidModel = new CreateMovieModel()
            {
                DirectorId =DId,
                GenreId = GId,
                MovieYear = Year,
                Name = MovieName,
                Price = Mp
            };
            CreateMovieCommand command = new CreateMovieCommand(_context,_mapper);
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            command.createMovieModel = InvalidModel;
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(1);
        }
        [Theory]
        [InlineData("a",1,1,1901,20)]
        public void ValidInput_CreateMovie_ReturnBeSucces(string MovieName, int DId, int GId,int Year,double Mp)
        {
            var InvalidModel = new CreateMovieModel()
            {
                DirectorId =DId,
                GenreId = GId,
                MovieYear = Year,
                Name = MovieName,
                Price = Mp
            };
            CreateMovieCommand command = new CreateMovieCommand(_context,_mapper);
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            command.createMovieModel = InvalidModel;
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeLessThan(1);
        }
    }
}