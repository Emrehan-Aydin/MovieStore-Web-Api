using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DTo.Actor.ActorCrudModels;
using MovieStoreWebApi.DTo.Actor.ActorViews;
using MovieStoreWebApi.DTo.Customer.CustomerCrudModels;
using MovieStoreWebApi.DTo.Customer.CustomerViews;
using MovieStoreWebApi.DTo.Director.DirectorCrudModels;
using MovieStoreWebApi.DTo.Director.DirectorViews;
using MovieStoreWebApi.DTo.Genre.GenreCrudModels;
using MovieStoreWebApi.DTo.Genre.GenreViews;
using MovieStoreWebApi.DTo.Movie.MovieCrudModels;
using MovieStoreWebApi.DTo.Movie.MovieViews;
using MovieStoreWebApi.DTo.MovieAndActor.MoviesActorCrudModels;
using MovieStoreWebApi.DTo.Order.OrderCrudModels;
using MovieStoreWebApi.DTo.Order.OrderViews;
using MovieStoreWebApi.Entities;
using MovieStoreWebApi.Application.UserOperations.Command.CreateUser;

namespace MovieStoreWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Movie,MovieDetailViewModel>()
            .ForMember(Dest=>Dest.Director, opt => opt.MapFrom(src=>src.Director.Name +" "+src.Director.Surname))
            .ForMember(Dest=>Dest.Actor, opt=>opt.
                MapFrom(src=>src.Actor.Select(Ma=>Ma.Actor).ToList()))
            .ForMember(Dest=>Dest.Genre, opt => opt.MapFrom(src=>src.Genre.Name));

            CreateMap<Movie,MovieViewModel>()
            .ForMember(Dest=>Dest.Director, opt => opt.MapFrom(src=>src.Director.Name +" "+src.Director.Surname))
            .ForMember(Dest=>Dest.Actor, opt=>opt.
                MapFrom(src=>src.Actor.Select(Ma=>Ma.Actor).ToList()))
            .ForMember(Dest=>Dest.Genre, opt => opt.MapFrom(src=>src.Genre.Name));

            CreateMap<Movie,MovieTemplateViewModel>();
            
            CreateMap<Actor,ActorViewModel>()
            .ForMember(Dest=>Dest.Name, opt=>opt.MapFrom(src=>src.Name))
            .ForMember(Dest=>Dest.Surname, opt=>opt.MapFrom(src=>src.Surname));

            CreateMap<CreateMovieModel,Movie>();
            
            CreateMap<CreateUserModel,User>();
            CreateMap<CreateActorModel,Actor>();
            CreateMap<Actor,ActorViewModel>();
            CreateMap<Actor,ActorDetailViewModel>();
            CreateMap<CreateNewMoviesActor,MoviesActor>();

            
            CreateMap<CreateGenreModel,Genre>();
            CreateMap<Genre,GenreViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();

            CreateMap<CreateDirectorModel,Director>();
            CreateMap<Director,DirectorViewModel>();
            CreateMap<Director,DirectorDetailViewModel>()
            .ForMember(Dest=>Dest.Movies,opt=>opt.MapFrom(src=>src.DiretoredMovies.Select(M=>M.Movie).ToList()));

            CreateMap<CreateCustomerModel,Customer>();

            CreateMap<Customer,CustomerDetailViewModel>()
            .ForMember(Dest=>Dest.Customer_Movie_Library,
            opt=>opt.MapFrom(src=>src.Customer_Movie_Lib.Select(M=>M.Movie).ToList()))
            .ForMember(Dest=>Dest.Customer_Genre_Library,
            opt=>opt.MapFrom(src=>src.Customer_Genre_Lib.Select(G=>G.Genre).ToList()));

            CreateMap<Customer,CustomerViewModel>();
            
            CreateMap<Order,OrderViewModel>()
            .ForMember(Dest=>Dest.Movie,opt=>opt.MapFrom(src=>src.Movie))
            .ForMember(Dest=>Dest.Customer,opt=>opt.MapFrom(src=>src.Customer));
            CreateMap<Order,OrderDetailViewModel>()
            .ForMember(Dest=>Dest.Movie,opt=>opt.MapFrom(src=>src.Movie))
            .ForMember(Dest=>Dest.Customer,opt=>opt.MapFrom(src=>src.Customer));;
            CreateMap<UpdateOrderModel,Order>();
            CreateMap<CreateOrderModel,Order>();
        }
        
    }
}