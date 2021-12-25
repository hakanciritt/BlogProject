using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dtos.Category;
using Entities.Concrete;
using WebModels.Category;

namespace Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap(typeof(CategoryAddDto), typeof(Category));
            CreateMap(typeof(CategoryDeleteDto), typeof(Category));
            CreateMap(typeof(CategoryUpdateDto), typeof(Category));

            

        }
    }
}
