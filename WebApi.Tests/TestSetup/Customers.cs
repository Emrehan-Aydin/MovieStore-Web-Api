using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace WebApi.Tests.TestSetup
{
    public static class Customers
    {
        public static void AddRange (this MovieStoreDbContext context)
        {
            context.Customers.AddRange(
                new Customer
                {
                    Name = "Z",
                    Surname = "x",   
                },
                new Customer
                {
                    Name = "Y",
                    Surname = "A",   
                },
                new Customer
                {
                    Name = "H",
                    Surname = "O",   
                }
            );
        }
    }
}