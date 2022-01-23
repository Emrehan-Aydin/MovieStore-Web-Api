using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Movie.MovieViews;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreWebApi.Application.MovieOperation.Queries.GetByNameMovieQuery
{
    public class GetByNameMovieQuery
    {
        public string name;
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GetByNameMovieQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public MovieDetailViewModel Handle()
        {
            var obj = _context.Movies
            .Include(M=>M.Director)
            .Include(M=>M.Genre)
            .Include(M=>M.Actor)
                .ThenInclude(Ma=>Ma.Actor)
            .FirstOrDefault(M=>M.Name == name);
    
            if(obj is null)
                throw new InvalidOperationException("Belirtilen İsimde Bir Film Bulunamadı!");
                
            return _mapper.Map<MovieDetailViewModel>(obj);
        }
    }
    
}