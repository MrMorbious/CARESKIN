﻿namespace SWP391_CareSkin_BE.DTOs.Requests.BlogNews
{
    public class BlogNewsUpdateRequest
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public IFormFile? PictureFile { get; set; }

    }
}
