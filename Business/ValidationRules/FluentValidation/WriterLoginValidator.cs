using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterLoginValidator : AbstractValidator<Writer>
    {
        public WriterLoginValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen mail adresi giriniz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
        }
    }
}
