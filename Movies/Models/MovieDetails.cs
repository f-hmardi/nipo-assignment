using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class MovieDetails
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string TitleType { get; set; }
        public int Year { get; set; }
    }
}
