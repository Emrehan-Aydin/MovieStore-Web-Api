using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace WebApi.Tests.TestSetup
{
    public static class CustomerMovies
    {
        public static void AddRange (this MovieStoreDbContext context)
        {
            context.CustomerMovies.AddRange(
                new CustomerMovie
                {
                    CustomerId = 1,
                    MovieId = 1
                },
                new CustomerMovie
                {
                    CustomerId = 1,
                    MovieId = 3
                },
                new CustomerMovie
                {
                    CustomerId = 1,
                    MovieId = 2
                },
                new CustomerMovie
                {
                    CustomerId = 2,
                    MovieId = 1
                },
                new CustomerMovie
                {
                    CustomerId = 2,
                    MovieId = 3
                }
            );        
        }
    }
}