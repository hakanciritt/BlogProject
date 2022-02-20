using AutoMapper;
using Dtos.Category;
using Dtos.Writer;
using Entities.Concrete;
using WebModels.Category;
using WebModels.Writer;

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
            CreateMap<WriterUpdateDto, WriterProfileUpdateViewModel>().ReverseMap();
            CreateMap<WriterDto, WriterProfileUpdateViewModel>().ReverseMap();
        }
    }
}
