using System;
using FluentAssertions;
using MovieStoreWebApi.Application.MovieOperation.Command.DeleteMovieCommand;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using WebApi.Tests.TestSetup;
using Xunit;

namespace Application.MovieOperations.Command.DeleteMovieCommandTest
{
    public class DeleteMovieCommandTest:IClassFixture<TestSetupFixture>
    {
        IMovieStoreDbContext _context;
        public DeleteMovieCommandTest(TestSetupFixture testSetupFixture)
        {
            _context = testSetupFixture.context;
        }
        [Fact]
        public void InvalidInputGiven_DeleteMovie_ThrowInvalidException()
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.Id = 404;

            FluentActions.Invoking(()=>command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film Bulunamadı.");
        }
        [Fact]
        public void ValidInputGiven_DeleteMovie_SuccesResult()
        {
            _context.Movies.Add(new Movie{Id=200});
            _context.SaveChanges();
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.Id = 200;            
            FluentActions.Invoking(()=>command.Handle())
            .Should().NotThrow<InvalidOperationException>();

        }
    }
    
}