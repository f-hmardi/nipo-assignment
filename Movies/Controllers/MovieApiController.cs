using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Movies.Services;
using Movies.Services.impl;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieApiController : ControllerBase
    {

        private IMovieService movieService;

        public MovieApiController(IMovieService movieService) {
            this.movieService = movieService;
        }

        // GET: api/MovieApi
        [HttpGet]
        public IEnumerable<Movie> GetMovie()
        {
            IList<Movie> movies = movieService.getTopMoviesWithTrailer();
            
            return (movies);
        }
    }
}
