using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.BlogId).GreaterThan(0).WithMessage("Blog id alanı boş geçilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Başlık alanı maximum 100 karakter uzunluğunda olabilir");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Yorum alanı boş geçilemez");
        }
    }
}
