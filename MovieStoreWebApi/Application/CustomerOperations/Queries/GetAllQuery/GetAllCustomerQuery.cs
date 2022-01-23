using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Customer.CustomerViews;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreWebApi.Application.CustomerOperations.Queries.GetAllQuery
{
    public class GetAllCustomerQuery
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GetAllCustomerQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<CustomerViewModel> Handle()
        {
            var obj = _context.Customers
            .Include(M=>M.Customer_Movie_Lib)
                .ThenInclude(C=>C.Movie)
            .Include(G=>G.Customer_Genre_Lib)
                .ThenInclude(C=>C.Genre)
            .OrderBy(C=>C.Id);
            if(obj is null)
                throw new InvalidOperationException("Hiçbir Kayıt Bulunamadı!");
                
            return _mapper.Map<List<CustomerViewModel>>(obj);
        }
    }
}