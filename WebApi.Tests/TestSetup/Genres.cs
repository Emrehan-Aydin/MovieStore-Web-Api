using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
namespace WebApi.Tests.TestSetup
{
    public static class Genres
    {
        public static void AddRange (this MovieStoreDbContext context)
        {
            context.Genres.AddRange(
                new Genre()
                {
                    Name ="Action"
                },
                new Genre()
                {
                    Name ="Dram"
                },
                new Genre()
                {
                    Name ="Comedy"
                },
                new Genre()
                 {
                    Name ="Documentary"
                },
                new Genre()
                 {
                    Name ="Horror"
                }
            );
        }
    }
}