using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Business.Mapping
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> Map = new Lazy<IMapper>(() =>
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfiles(new List<Profile>() { new MappingProfile(), new WebMappingProfile() });
            });

            IMapper mapper = mapperConfig.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper = Map.Value;
    }
}
