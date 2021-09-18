using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Details1).NotEmpty().WithMessage("Detay1 alanı boş geçilemez");
            RuleFor(x => x.Details2).NotEmpty().WithMessage("Detay2 alanı boş geçilemez");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Resim1 alanı boş geçilemez");
            RuleFor(x => x.Image2).NotEmpty().WithMessage("Resim2 alanı boş geçilemez");
            RuleFor(x => x.MapLocation).NotEmpty().WithMessage("Location alanı boş geçilemez");
        }
    }
}
