using AutoMapper;
using CoronaNyScaper.Data;
using CoronaNyScaper.Model;

namespace CoronaScraper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<NyBoroughEntity, NyBorough>();
            CreateMap<NyBoroughDeathsEntity, NyBorough>();
            CreateMap<NyBoroughHospitalizationsEntity, NyBorough>();

            CreateMap<NyCountyEntity, NyCounty>();
        }
    }
}