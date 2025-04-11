﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SWP391_CareSkin_BE.Data;
using SWP391_CareSkin_BE.DTOS;
using SWP391_CareSkin_BE.Helpers;
using SWP391_CareSkin_BE.Models;
using SWP391_CareSkin_BE.Repositories.Interfaces;
using SWP391_CareSkin_BE.Services;

namespace SWP391_CareSkin_BE.Repositories.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly MyDbContext _context;
        private readonly JwtHelper _jwtHelper;

        public AdminRepository(MyDbContext context, JwtHelper jwtHelper)
        {
            _context = context;
            _jwtHelper = jwtHelper;
        } 
        public async Task<List<Admin>> GetAdmin()
        {
            return await _context.Admins.ToListAsync();
        }

        public Task<Admin> GetAdminByIdAsync(int adminId)
        {
            return _context.Admins.FirstOrDefaultAsync(aId => aId.AdminId == adminId);
        }

        public async Task<Admin> LoginAdmin(LoginDTO request)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.UserName == request.UserName && a.Password == request.Password);
            

            if(admin == null)
            {
                return null;
                throw new Exception("Invalid admin name or password");
            }

            string role = "Admin";
            var token = _jwtHelper.GenerateToken(request.UserName, role, admin.AdminId);
            admin.Token = token;
            admin.Role = role;
            return admin;
        }
        public async Task UpdateAdminAsync(Admin admin)
        {
            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();
        }

        public async Task<string> UploadImageAsync(IFormFile image)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine("wwwroot/uploads", fileName);

            Directory.CreateDirectory("wwwroot/uploads");

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return "/uploads/" + fileName;
        }

        public void DeleteOldImage(string imageUrl)
        {
            var filePath = Path.Combine("wwwroot", imageUrl.TrimStart('/'));

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
