using Dtos.Writer;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.WriterValidation
{
    internal class WriterUpdateValidator : AbstractValidator<WriterUpdateDto>
    {
        public WriterUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen doğru bir email formatı giriniz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(x => x.About).NotEmpty().WithMessage("Hakkımda alanı boş geçilemez");
            RuleFor(d => d.WriterId).GreaterThan(0).WithMessage("Yazar Id boş olamaz");
        }
    }
}
