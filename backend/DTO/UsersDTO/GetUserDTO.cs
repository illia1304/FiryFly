using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace backend.DTO.UserDTO
{
    public class GetUserDTO
    {
        public int Id{get;set;}
        public string? Nickname{get;set;}
        public int Followers_count{get;set;}
    }
}