using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
namespace WebApi.Tests.TestSetup
{
    public static class MoviesActors
    {
        public static void AddRange (this MovieStoreDbContext context)
        {
            context.MoviesActors.AddRange(
                new MoviesActor
                {
                    MovieId = 1,
                    ActorId =1
                },
                new MoviesActor
                {
                    MovieId = 2,
                    ActorId =2
                }
            );
        }
    }
}