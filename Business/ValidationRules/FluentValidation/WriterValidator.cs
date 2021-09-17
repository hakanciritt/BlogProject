using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen doğru bir email formatı giriniz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(x => x.About).NotEmpty().WithMessage("Hakkımda alanı boş geçilemez");
        }
    }
}
