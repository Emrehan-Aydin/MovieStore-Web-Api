using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Customer.CustomerViews;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreWebApi.Application.CustomerOperation.Queries.GetByIdCustomerQuery
{
    public class GetByIdCustomerQuery
    {
        public int Id;
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GetByIdCustomerQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public CustomerDetailViewModel Handle()
        {
            var obj = _context.Customers.
            Include(M=>M.Customer_Movie_Lib)
                .ThenInclude(C=>C.Movie)
            .Include(G=>G.Customer_Genre_Lib)
                .ThenInclude(C=>C.Genre)
            .SingleOrDefault(M=>M.Id == Id);
    
            if(obj is null)
                throw new InvalidOperationException("Belirtilen İsimde Bir Müşteri Bulunamadı!");
                
            return _mapper.Map<CustomerDetailViewModel>(obj);
        }
    }
    
}