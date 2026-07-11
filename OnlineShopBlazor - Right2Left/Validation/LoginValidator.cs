using FluentValidation;
using OnlineShopBlazor.Models.ViewModels;

namespace OnlineShopBlazor.Validation
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(p => p.Email)
           .NotEmpty().WithMessage("ایمیل خود را وارد کنید")
           .EmailAddress().WithMessage("لطفا یک ایمیل معتبر وارد نمایید")
          .MaximumLength(50).WithMessage("ایمیل وارد شده طولانی تر از حد مجاز است");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("رمز عبور را وارد نمایید")
                .MaximumLength(50).WithMessage("پسورد وارد شده طولانی تر از حد مجاز است");
        }
    }
}
