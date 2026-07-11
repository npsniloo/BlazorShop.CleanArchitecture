using FluentValidation;
using OnlineShopBlazor.Models.ViewModels;

namespace OnlineShopBlazor.Validation
{
    public class RecoveryValidator : AbstractValidator<RecoveryViewModel>
    {
        public RecoveryValidator()
        {
            RuleFor(p => p.Email)
           .NotEmpty().WithMessage("Please enter your email address.")
           .EmailAddress().WithMessage("Please enter a valid email address.")
           .MaximumLength(50).WithMessage("Email can not be longer than 50 character.");

        }
    }
}
