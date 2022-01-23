using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace WebApi.Tests.TestSetup
{
    public static class CustomerGenres
    {
        public static void AddRange (this MovieStoreDbContext context)
        {
            context.CustomerGenres.AddRange(
                new CustomerGenre
                {
                    CustomerId=1,
                    GenreId = 2
                },
                new CustomerGenre
                {
                    CustomerId=1,
                    GenreId = 4
                },
                new CustomerGenre
                {
                    CustomerId=2,
                    GenreId = 1
                },
                new CustomerGenre
                {
                    CustomerId=1,
                    GenreId = 3
                });
        }
    }
}