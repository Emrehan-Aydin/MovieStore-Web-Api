using System;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
namespace WebApi.Tests.TestSetup
{
    public static class Orders
    {
        public static void AddRange (this MovieStoreDbContext context)
        {
            context.Orders.AddRange(
                new Order
                {
                    CustomerId = 1,
                    MovieId = 1,
                    TotalPrice = 10,
                    OrderDate = new DateTime(2001,5,21)
                },
                new Order
                {
                    CustomerId = 1,
                    MovieId = 2,
                    TotalPrice = 10,
                    OrderDate = new DateTime(2010,5,20)
                },
                new Order
                {
                    CustomerId = 2,
                    MovieId = 1,
                    TotalPrice = 10,
                    OrderDate = new DateTime(2021,5,20)
                }
            );
        }
    }
}