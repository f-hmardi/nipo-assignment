using Movies.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Services.impl
{
    public class MovieService : IMovieService
    {
        private IImdbService imdbService;

        private IYoutubeService youtubeService;

        public MovieService(IImdbService imdbService, IYoutubeService youtubeService) {
            this.imdbService = imdbService;
            this.youtubeService = youtubeService;
        }
        public IList<Movie> getTopMoviesWithTrailer()
        {
            IList<Movie> topMovies = new List<Movie>();
            topMovies = imdbService.getTopMovies();
            foreach (Movie movie in topMovies) {
                String videoId = youtubeService.GetVideoId(movie.Title, movie.Year);
                movie.VideoId = videoId;
            }

            return topMovies;
        }
    }
}
