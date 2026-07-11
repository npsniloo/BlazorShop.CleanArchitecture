using eShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Interfaces.Services.Shared
{
    public interface IPasswordHashService
    {
        PasswordDto GetPasswordHash(string password);
        bool VerifyPassword(string password, string storedHash, string storedSalt);
    }
}
