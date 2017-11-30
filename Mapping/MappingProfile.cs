using ACR2.Models;
using ACR2.Models.Resources;
using AutoMapper;

namespace ACR2.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Week, WeekResource>();
            CreateMap<WeekEntry, WeekEntryResource>();
            CreateMap<WeekNumber, WeekNumberResource>();
        }
    }
}