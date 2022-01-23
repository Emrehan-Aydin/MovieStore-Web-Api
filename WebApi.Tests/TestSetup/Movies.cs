using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
namespace WebApi.Tests.TestSetup
{
    public static class Movies
    {
        public static void AddRange(this MovieStoreDbContext context)
        {
            context.Movies.AddRange(
                new Movie 
                {
                    Name = "A",
                    MovieYear = 2020,
                    Price = 15,
                    DirectorId = 1,
                    GenreId = 1,
                },
                new Movie 
                {
                    Name = "B",
                    MovieYear = 2000,
                    Price = 15,
                    DirectorId = 2,
                    GenreId = 3,
                },
                new Movie 
                {
                    Name = "C",
                    MovieYear = 2019,
                    Price = 5,
                    DirectorId = 2,
                    GenreId = 2,
                },
                new Movie 
                {
                    Name = "D",
                    MovieYear = 2021,
                    Price = 70,
                    DirectorId = 4,
                    GenreId = 2,
                },
                new Movie 
                {
                    Name = "E",
                    MovieYear = 2020,
                    Price = 15,
                    DirectorId = 1,
                    GenreId = 1,
                }
                );
        }
    }
}