using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Kategori adı minimum 3 karakter uzunluğunda olabilir");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Kategori adı maximum 50 karakter uzunluğunda olabilir");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Kategori hakkında açıklama yapınız");
        }
    }
}
