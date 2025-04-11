﻿using SWP391_CareSkin_BE.DTOs.Requests.BlogNews;
using SWP391_CareSkin_BE.DTOs.Responses.BlogNews;
using SWP391_CareSkin_BE.Mappers;
using SWP391_CareSkin_BE.Models;
using SWP391_CareSkin_BE.Repositories.Implementations;
using SWP391_CareSkin_BE.Repositories.Interfaces;
using SWP391_CareSkin_BE.Services.Interfaces;

namespace SWP391_CareSkin_BE.Services.Implementations
{
    public class BlogNewsService : IBlogNewsService
    {
        private readonly IBlogNewsRepository _newsRepository;

        public BlogNewsService(IBlogNewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<List<BlogNewsDTO>> GetAllNewsAsync()
        {
            var blog = await _newsRepository.GetAllNewsAsync();
            return blog.Select(BlogNewsMapper.ToDTO).ToList();
        }

        public async Task<BlogNewsDTO> GetNewsByIdAsync(int blogId)
        {
            var blog = await _newsRepository.GetNewsByIdAsync(blogId);
            return BlogNewsMapper.ToDTO(blog);
        }


        public async Task<BlogNewsDTO> AddNewsAsync(BlogNewsCreateRequest request, DateTime date, string pictureUrl, int? adminId, int? staffId)
        {
            var blogEntity = BlogNewsMapper.ToEntity(request, date, pictureUrl, adminId, staffId);
            await _newsRepository.AddNewsAsync(blogEntity);

            return BlogNewsMapper.ToDTO(blogEntity);
        }

        public async Task<BlogNewsDTO> UpdateNewsAsync(int blogId, BlogNewsUpdateRequest request, string pictureUrl)
        {
            var existedNews = await _newsRepository.GetNewsByIdAsync(blogId);
            if (existedNews == null) return null;

            BlogNewsMapper.UpdateEntity(existedNews, request, pictureUrl);
            await _newsRepository.UpdateNewsAsync(existedNews);

            var updateNews = await _newsRepository.GetNewsByIdAsync(blogId);
            return BlogNewsMapper.ToDTO(updateNews);
        }

        public async Task<bool> DeleteNewsAsync(int blogId)
        {
            await _newsRepository.DeleteNewsAsync(blogId);
            return true;
        }


    }
}
