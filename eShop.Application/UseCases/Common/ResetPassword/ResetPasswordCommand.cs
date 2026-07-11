using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Common.ResetPassword
{
    public class ResetPasswordCommand
    {
        public ResetPasswordCommand(string email, string newPassword, int recoveryCode)
        {
            Email = email;
            NewPassword = newPassword;
            RecoveryCode = recoveryCode;
        }

        public string Email { get; }
        public string NewPassword { get; }
        public int RecoveryCode { get; }
    }
}
