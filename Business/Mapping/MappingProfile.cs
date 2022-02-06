﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dtos.About;
using Dtos.Blog;
using Dtos.Category;
using Dtos.Message;
using Entities.Concrete;
using WebModels.Category;

namespace Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap(typeof(CategoryAddDto), typeof(Category)).ReverseMap();
            CreateMap(typeof(CategoryUpdateDto), typeof(Category));
            CreateMap<Blog, BlogDto>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<About, AboutDto>().ReverseMap();
            CreateMap<Message, MessageDto>().ReverseMap();
        }
    }
}
