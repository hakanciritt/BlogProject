using Dtos.Writer;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<WriterAddDto>
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
