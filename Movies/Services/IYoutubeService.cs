﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Services
{
    public interface IYoutubeService
    {
        public String GetVideoId(String title, int year);
    }
}
