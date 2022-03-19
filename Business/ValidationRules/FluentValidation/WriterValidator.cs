using Dtos.Writer;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<WriterAddDto>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Ad alanı boş geçilemez");
            RuleFor(x => x.Mail).NotEmpty().NotNull().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen doğru bir email formatı giriniz");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(x => x.About).NotEmpty().NotNull().WithMessage("Hakkımda alanı boş geçilemez");
            RuleFor(d => d.WriterId).GreaterThan(0).WithMessage("Yazar Id boş olamaz");
        }
    }
}
