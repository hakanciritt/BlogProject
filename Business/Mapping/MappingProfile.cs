using AutoMapper;
using Dtos.About;
using Dtos.Blog;
using Dtos.Category;
using Dtos.Message;
using Dtos.Writer;
using Entities.Concrete;

namespace Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap(typeof(CategoryAddDto), typeof(Category)).ReverseMap();
            CreateMap(typeof(CategoryUpdateDto), typeof(Category));
            CreateMap<Blog, BlogDto>().ReverseMap();
            CreateMap<Blog, UpdateBlogDto>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<About, AboutDto>().ReverseMap();
            CreateMap<Message, MessageDto>().ReverseMap();
            CreateMap<Writer, WriterAddDto>().ReverseMap();
            CreateMap<Writer, WriterUpdateDto>().ReverseMap();
        }
    }
}
