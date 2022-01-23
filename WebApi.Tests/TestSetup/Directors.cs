using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace WebApi.Tests.TestSetup
{
    public static class Directors
    {
        public static void AddRange (this MovieStoreDbContext context)
        {
            context.Directors.AddRange(
                new Director 
                {
                    Name = "Emrehan",
                    Surname = "Aydın",
                },
                new Director 
                {
                    Name = "Burak",
                    Surname = "Biçkioğlu",
        
                },
                new Director 
                {
                    Name = "Onur",
                    Surname = "Göz",

                },
                new Director 
                {
                    Name = "Halil",
                    Surname = "Tanaç",
                });
        }
    }
}

