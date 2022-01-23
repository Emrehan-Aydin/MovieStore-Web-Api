using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Director.DirectorViews;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreWebApi.Application.DirectorOperation.Queries.GetByNameDirectorQuery
{
    public class GetByNameDirectorQuery
    {
        public string name,surname;
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GetByNameDirectorQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public DirectorDetailViewModel Handle()
        {
            var obj = _context.Directors.Include(M=>M.DiretoredMovies)
                .ThenInclude(M=>M.Movie)
                    .FirstOrDefault(M=>M.Name == name);
    
            if(obj is null)
                throw new InvalidOperationException("Belirtilen İsimde Bir tür Bulunamadı!");
                
            return _mapper.Map<DirectorDetailViewModel>(obj);
        }
    }
    
}