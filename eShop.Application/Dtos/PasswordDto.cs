using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Dtos
{
    public class PasswordDto
    {
        public string Hash { get; }
        public string Salt { get; }
        public PasswordDto(string hash, string salt)
        {
            Hash = hash;
            Salt = salt;
        }
    }
}
