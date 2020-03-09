using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Services
{
    public interface IMovieService
    {
        public IList<Movie> getTopMoviesWithTrailer();
    }
}
