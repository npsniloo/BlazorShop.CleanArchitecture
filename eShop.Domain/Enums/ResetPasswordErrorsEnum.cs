using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Enums
{
    public enum ResetPasswordErrorsEnum
    {
        None = 0,
        [Description("نام کاربری وجود ندارد")]
        UserNotExists = 1,
        [Description("کد بازیابی اشتباه است")]
        WrongRecovryCode = 2,
        [Description(" خطا در تغییر رمز عبور رخ داد")]
        ResetPasswordError = 3,
    }
}
