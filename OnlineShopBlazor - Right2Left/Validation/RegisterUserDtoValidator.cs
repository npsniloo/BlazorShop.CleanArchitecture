using FluentValidation;
using OnlineShopBlazor.Models.Dtos;

namespace OnlineShopBlazor.Validation
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
        {
            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("نام کامل خود را وارد نمایید")
                .MaximumLength(200).WithMessage("نام وارد شده طولانی تر از حد مجاز است");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("ایمیل خود را وارد نمایید")
                 .EmailAddress().WithMessage("لطفا یک ایمیل معتبر وارد نمایید")
          .MaximumLength(50).WithMessage("ایمیل وارد شده طولانی تر از حد مجاز است");

            RuleFor(p => p.Password)
            .NotEmpty().WithMessage("رمز عبور را وارد نمایید")
                .MaximumLength(50).WithMessage("پسورد وارد شده طولانی تر از حد مجاز است")
                .MinimumLength(8).WithMessage("پسورد شما باید حداقل 8 حرف باشد");

        }
    }
}
