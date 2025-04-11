﻿using System.ComponentModel.DataAnnotations;

namespace SWP391_CareSkin_BE.DTOs.Requests.Admin
{
    public class AdminUpdateRequestDTO
    {
        public string? Password { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public DateOnly DoB { get; set; }

        public IFormFile? PictureFile { get; set; }
    }
}
