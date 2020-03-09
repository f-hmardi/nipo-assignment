using Movies.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Services
{
    public class ImdbService : IImdbService
    {
        readonly String TOP_MOVIES_URL = "https://imdb8.p.rapidapi.com/title/get-top-rated-movies";
        readonly String GET_MOVIE_DETAILS_URL = "https://imdb8.p.rapidapi.com/title/get-details?tconst=";
        readonly String API_HOST = "imdb8.p.rapidapi.com";
        readonly String API_KEY = "5f5e78796cmshe0bb803a6e27d6ep1a20b4jsnc4c853fe7e86";
        readonly int TOP_MOVIE_PAGE_SIZE = 10;
       
        public IList<Movie> getTopMovies()
        {
            IList<Movie> movies = new List<Movie>();

            var client = new RestClient(TOP_MOVIES_URL);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", API_HOST);
            request.AddHeader("x-rapidapi-key", API_KEY);
            IRestResponse response = client.Execute(request);
            IList<TopMovieModel> topMovies = JsonConvert.DeserializeObject<IList<TopMovieModel>>(response.Content);
            TopMovieModel[] topMoviesArray = topMovies.ToArray();
            for ( int i = 0; i < TOP_MOVIE_PAGE_SIZE; i++) {
                MovieDetails movieDetail = this.GetMovieDetails(topMoviesArray[i].Id.Split("/")[2]);
                Movie movie = new Movie();
                movie.Title = movieDetail.Title;
                movie.TitleType = movieDetail.TitleType;
                movie.Year = movieDetail.Year;
                movies.Add(movie);
            }
            return movies;
        }

        private MovieDetails GetMovieDetails(String titleId) {
            String url = GET_MOVIE_DETAILS_URL + titleId;
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", API_HOST);
            request.AddHeader("x-rapidapi-key", API_KEY);
            IRestResponse response = client.Execute(request);
            MovieDetails movie = JsonConvert.DeserializeObject<MovieDetails>(response.Content);
            return movie;
        }
    }
}
