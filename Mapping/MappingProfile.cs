using ACR2.Models;
using ACR2.Models.Resources;
using AutoMapper;

namespace ACR2.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Category, CategoryResource>();
            CreateMap<Week, WeekResource>();
            CreateMap<WeekEntry, WeekEntryResource>()
                .ForPath(wer => wer.Category.Id, opt => opt.MapFrom(we => we.CategoryId))
                .ForPath(wer => wer.Week.Id, opt => opt.MapFrom(we => we.WeekId));
            CreateMap<WeekNumber, WeekNumberResource>();

            //API Resource to Domain
            CreateMap<WeekEntryResource, WeekEntry>()
                .ForMember(we => we.CategoryId, opt => opt.MapFrom(wer => wer.Category.Id))
                .ForMember(we => we.WeekId, opt => opt.MapFrom(wer => wer.Week.Id));

        }
    }
}