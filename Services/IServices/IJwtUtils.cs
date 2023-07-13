﻿using WebApi.Models;
namespace WebApi.Services.IServices
{
    public interface IJwtUtils
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
    }
}
