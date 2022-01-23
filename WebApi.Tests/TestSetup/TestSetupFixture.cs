using AutoMapper;

using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Common;
using MovieStoreWebApi.DbOperations;

namespace WebApi.Tests.TestSetup
{
    public class TestSetupFixture
    {
        public IMovieStoreDbContext context ;
        public IMapper mapper;
        public TestSetupFixture()
        {
            var options = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase(databaseName:"BookStoreTestDb").Options;
            context = new MovieStoreDbContext(options);
            mapper = new MapperConfiguration(cfg=>{cfg.AddProfile<MappingProfile>();}).CreateMapper();
        }
    }
}