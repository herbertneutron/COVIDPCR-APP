using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Contracts.Domain.DTO
{
    public class RegisterResponse
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }
    }
}