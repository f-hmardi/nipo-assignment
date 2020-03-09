using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Services.impl
{
    public class YoutubeService : IYoutubeService
    {
        readonly String GOOGLE_API_KEY = "AIzaSyAHyuEVfE6W3vJkoSQp52h-HtVmaJrLmsI";
        readonly String TRAILER_SEARCH_QUERY = "trailer";
        public string GetVideoId(string title, int year)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = GOOGLE_API_KEY,
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = title+"+"+year+"+"+TRAILER_SEARCH_QUERY;
            searchListRequest.Type = "video";
            searchListRequest.MaxResults = 1;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = searchListRequest.Execute();
            return searchListResponse.Items[0].Id.VideoId;
               
        }
    }
}
