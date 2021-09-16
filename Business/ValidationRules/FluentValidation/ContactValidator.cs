using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen doğru bir email formatı giriniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj alanı boş geçilemez");
            RuleFor(x => x.Message).MinimumLength(10).WithMessage("Mesaj minimum 10 karakter uzunluğunda olabilir");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Başlık alanı boş geçilemez");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu minimum 5 karakter uzunluğunda olabilir");
        }
    }
}
