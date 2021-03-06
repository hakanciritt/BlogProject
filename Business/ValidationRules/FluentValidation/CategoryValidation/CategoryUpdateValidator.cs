using Dtos.Category;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CategoryValidation
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Kategori Id alanı boş geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Kategori adı minimum 3 karakter uzunluğunda olabilir");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Kategori adı maximum 50 karakter uzunluğunda olabilir");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Kategori hakkında açıklama yapınız");
        }
    }
}
