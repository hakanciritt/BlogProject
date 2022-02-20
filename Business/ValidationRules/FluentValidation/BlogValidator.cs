using Dtos.Blog;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BlogValidator : AbstractValidator<AddBlogDto>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez");
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Kategori alanı boş geçilemez");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori alanı boş geçilemez");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik alanı boş geçilemez");
            RuleFor(x => x.Content).MinimumLength(100).WithMessage("İçerik minimum 100 karakter uzunluğunda olmalıdır");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Resim alanı boş geçilemez");
            RuleFor(x => x.WriterId).NotEmpty().WithMessage("Yazar id alanı boş olamaz");
            RuleFor(x => x.WriterId).GreaterThan(0).WithMessage("yazar Id 0 dan büyük olmalıdır");
        }
    }
}
