using ACR2.Core.Models;
using ACR2.Core.Models.Resources;
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
            CreateMap<Week, WeekResource>()
                .ForMember(wr => wr.Entries, opt => opt.Ignore());
            CreateMap<WeekEntry, WeekEntryResource>()
                .ForMember(wer => wer.Category, opt => opt.MapFrom(we => we.Category))
                .ForMember(wer => wer.Week, opt => opt.MapFrom(we => we.Week));
            CreateMap<WeekNumber, WeekNumberResource>();

            //API Resource to Domain
            CreateMap<WeekEntryQueryResource, WeekEntryQuery>();
            CreateMap<WeekEntryResource, WeekEntry>()
                .ForMember(we => we.Id, opt => opt.Ignore())
                .ForMember(we => we.Category, opt => opt.MapFrom(wer => wer.Category))
                .ForMember(we => we.Week, opt => opt.MapFrom(wer => wer.Week));
            CreateMap<CategoryResource, Category>();
            CreateMap<WeekResource, Week>();
            CreateMap<SaveWeekEntryResource, WeekEntry>()
                 .ForMember(we => we.Id, opt => opt.Ignore());
                // .ForMember(we => we.Mon, opt => opt.MapFrom(swe => swe.Mon))
                // .ForMember(we => we.Tue, opt => opt.MapFrom(swe => swe.Tue))
                // .ForMember(we => we.Wed, opt => opt.MapFrom(swe => swe.Wed))
                // .ForMember(we => we.Thurs, opt => opt.MapFrom(swe => swe.Thurs))
                // .ForMember(we => we.Fri, opt => opt.MapFrom(swe => swe.Fri))
                // .ForMember(we => we.CategoryId, opt => opt.MapFrom(swe => swe.CategoryId))
                // .ForMember(we => we.WeekId, opt => opt.MapFrom(swe => swe.WeekId));

                

        }
    }
}