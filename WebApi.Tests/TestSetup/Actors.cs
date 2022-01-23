using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace WebApi.Tests.TestSetup
{
    public static class Actors
    {
        public static void AddRange(this MovieStoreDbContext context)
        {
            context.Actors.AddRange(
                new Actor
                {
                    Name = "Ali",
                    Surname = "Kemal",
                },
                new Actor
                {
                    Name = "Yamaç",
                    Surname = "Koçavalı:)",
                },
                new Actor
                {
                    Name = "Utku",
                    Surname = "Demir", 
                },
                new Actor
                {
                    Name = "Işıl",
                    Surname = "Ceviz",  
                }
            );
        }
    }
}