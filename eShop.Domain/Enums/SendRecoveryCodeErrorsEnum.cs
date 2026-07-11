using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Enums
{
    public enum SendRecoveryCodeErrorsEnum
    {
        [Description("")]
        None,
        [Description("کاربر وجود ندارد")]
        UserNotExist,
        [Description("خطا در ارسال کد رخ داد")]
        SendCodeException
    }
}
