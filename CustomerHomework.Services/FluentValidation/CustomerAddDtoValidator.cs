using CustomerHomework.Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerHomework.Services.FluentValidation
{
    public class CustomerAddDtoValidator:AbstractValidator<CustomerAddDto>
    {
        public CustomerAddDtoValidator()
        {
            RuleFor(p => p.Gender).IsInEnum();
            RuleFor(p => p.Gender).NotNull().WithMessage("Cinsiyet alanı zorunludur"); 
            RuleFor(p => p.Age).GreaterThanOrEqualTo(1);
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("Ad alanı zorunludur.");
            RuleFor(p => p.FirstName).Length(2, 50).WithMessage("Ad alanı minimum 2 karakter, maksimum 50 karakter olmalıdır.");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Soyad alanı zorunludur."); ;
            RuleFor(p => p.LastName).Length(2, 50).WithMessage("Soyad alanı minimum 2 karakter, maksimum 50 karakter olmalıdır.");


        }
    }
}
