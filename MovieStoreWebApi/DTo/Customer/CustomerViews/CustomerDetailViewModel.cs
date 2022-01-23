using System.Collections.Generic;
using MovieStoreWebApi.DTo.Genre.GenreViews;
using MovieStoreWebApi.DTo.Movie.MovieViews;

namespace MovieStoreWebApi.DTo.Customer.CustomerViews

{
    public class CustomerDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<MovieTemplateViewModel> Customer_Movie_Library { get; set; }
        public List<GenreViewModel> Customer_Genre_Library { get; set; }

    }
}