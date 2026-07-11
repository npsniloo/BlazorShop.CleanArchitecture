using eShop.Domain.Entities;
using FluentValidation;

namespace eShop.Web.CustomerPanel.Validation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(p => p.FirstName)
          .NotEmpty().WithMessage("نام خود را وارد کنید")
          .MaximumLength(50).WithMessage("نام وارد شده طولانی تر از حد مجاز است");

            RuleFor(p => p.LastName)
          .NotEmpty().WithMessage("نام خانوادگی خود را وارد کنید")
          .MaximumLength(50).WithMessage("نام‌خانوادگی وارد شده طولانی تر از حد مجاز است");

            RuleFor(p => p.Phone)
          .NotEmpty().WithMessage("شماره موبایل خود را وارد کنید")
          .MaximumLength(12).WithMessage("شماره موبایل وارد شده حداکثر 12 عدد میتواند باشد");

            RuleFor(p => p.Address)
          .NotEmpty().WithMessage("آدرس خود را وارد کنید")
          .MaximumLength(1000).WithMessage("آدرس وارد شده طولانی تر از حد مجاز است");

          //  RuleFor(p => p.Country)
          //.NotEmpty().WithMessage("Please enter your country")
          //.MaximumLength(50).WithMessage("Country can not be longer than 50 characters");

            RuleFor(p => p.City)
          .NotEmpty().WithMessage("شهر خود را وارد کنید")
          .MaximumLength(50).WithMessage("نام شهر وارد شده طولانی تر از حد مجاز است");

            RuleFor(p => p.Email)
          .NotEmpty().WithMessage("ایمیل خود را وارد کنید")
          .EmailAddress().WithMessage("لطفا یک ایمیل معتبر وارد نمایید")
          .MaximumLength(50).WithMessage("ایمیل وارد شده طولانی تر از حد مجاز است");
        }
    }
}
