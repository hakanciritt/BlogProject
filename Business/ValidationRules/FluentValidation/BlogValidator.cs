using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez");
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Kategori alanı boş geçilemez");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik alano boş geçilemez");
            RuleFor(x => x.Content).MinimumLength(100).WithMessage("İçerik minimum 100 karakter uzunluğunda olmalıdır");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Resim alanı boş geçilemez");
        }
    }
}
