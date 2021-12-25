using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dtos.Category;
using Entities.Concrete;
using WebModels.Category;

namespace Business.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap(typeof(Category), typeof(CategoryAddViewModel));
            CreateMap(typeof(CategoryAddViewModel), typeof(CategoryAddDto));
            CreateMap(typeof(CategoryAddViewModel), typeof(Category));

            CreateMap(typeof(CategoryUpdateDto), typeof(CategoryUpdateViewModel));
            CreateMap(typeof(CategoryUpdateViewModel), typeof(CategoryUpdateDto));
        }
    }
}
