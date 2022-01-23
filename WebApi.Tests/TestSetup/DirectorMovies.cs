using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
namespace WebApi.Tests.TestSetup
{
    public static class DirectorMovies
    {
        public static void AddRange (this MovieStoreDbContext context)
        {
            context.DirectorMovies.AddRange(
                new DirectorMovie
                {
                    DirectorId=1,
                    MovieId=1
                },
                new DirectorMovie
                {
                    DirectorId=1,
                    MovieId=2
                },
                new DirectorMovie
                {
                    DirectorId=2,
                    MovieId=4
                },
                new DirectorMovie
                {
                    DirectorId=2,
                    MovieId=3
                }
            );
        }
    }
}