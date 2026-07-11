using FluentValidation;
using OnlineShopBlazor.Models.ViewModels;

namespace OnlineShopBlazor.Validation
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordViewModel>
    {
        public ResetPasswordValidator()
        {
            RuleFor(p => p.Email)
           .NotEmpty().WithMessage("Please enter your email address.")
           .EmailAddress().WithMessage("Please enter a valid email address.")
           .MaximumLength(50).WithMessage("Email can not be longer than 50 character.");

            RuleFor(p => p.NewPassword)
                .NotEmpty().WithMessage("Please enter a password.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
                .MaximumLength(50).WithMessage("Password can not be longer than 50 character.");

            RuleFor(p => p.RecoveryCode)
                .NotEmpty().WithMessage("Please enter a recovery code.");
        }
    }
}
