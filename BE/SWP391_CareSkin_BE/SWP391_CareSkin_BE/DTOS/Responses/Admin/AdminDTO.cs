﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_CareSkin_BE.DTOs.Responses
{
    public class AdminDTO
    {
        public int AdminId { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateOnly? DoB { get; set; }

        public string PictureUrl { get; set; }
        public string? token { get; set; }

        public string Role { get; set; }
    }
}
