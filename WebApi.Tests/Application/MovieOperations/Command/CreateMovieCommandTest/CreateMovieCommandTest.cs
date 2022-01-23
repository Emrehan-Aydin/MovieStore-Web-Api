using System;
using System.Collections.Generic;
using System.Linq;
using MovieStoreWebApi.Application.MovieOperation.Command.AddMovieCommand;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Movie.MovieCrudModels;
using MovieStoreWebApi.Entities;
using FluentAssertions;
using WebApi.Tests.TestSetup;
using Xunit;

namespace WebApi.Tests.Application.MovieOperations.Command.CreateMovieCommandTest
{
    
    public class CreateMovieCommandTest:IClassFixture<TestSetupFixture>
    {
        IMovieStoreDbContext _context;
        IMapper _mapper;
        public CreateMovieCommandTest(TestSetupFixture testFixture)
        {
            _context =testFixture.context;
            _mapper = testFixture.mapper;
        }
        [Fact]
        public void WhenAlreadyHaveMovie_CreateNewMovie_ThrowInvalidOperationException()
        {
            //Arrange
            var newMovie = new Movie{
                Name = " WhenAlreadyHaveMovie_CreateNewMovie_ThrowInvalidOperationException",
                MovieYear = 2020,
                DirectorId = 1,
                GenreId = 2,
                Price = 3,
                
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
            //Act
            var newmovie = new CreateMovieModel()
            {
                Name = newMovie.Name,
                MovieYear = newMovie.MovieYear, 
            };
            CreateMovieCommand command = new CreateMovieCommand(_context,_mapper);
            command.createMovieModel = newmovie;

            FluentActions.Invoking(()=>command.Handle())
            // Assert
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir film zaten mevcut!");
            
        } 
        [Fact]
        public void WhenGivenValidInput_CreateNewMovie_SuccesResult()
        {
            var newmovies = new CreateMovieModel(){
                Name = "WhenGivenValidInput_CreateNewMovie_SuccesResult",
                MovieYear = 2020,
                DirectorId = 1,
                GenreId = 2,
                Price = 3,
                ActorId = new List<int>(){1}
            };
            CreateMovieCommand command = new CreateMovieCommand(_context,_mapper);
            //Arrange
            command.createMovieModel = newmovies;
            FluentActions.Invoking(()=>command.Handle()).Invoke();
            // Assert
            var movie = _context.Movies.FirstOrDefault(
                M=>M.GenreId == command.createMovieModel.GenreId && 
                M.MovieYear == command.createMovieModel.MovieYear &&
                M.Name == command.createMovieModel.Name &&
                M.Price==command.createMovieModel.Price &&
                M.DirectorId == command.createMovieModel.DirectorId &&
                M.GenreId == command.createMovieModel.GenreId);
            movie.Should().NotBeNull();            
        }
    }
    
}