using AutoMapper;
using DataAccess.Model;
using IntuitiveTest.ViewModels;
using IntuitiveTest.Requests;
using Route = DataAccess.Model.Route;

namespace IntuitiveTest
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Country, CreateCountryRequest>().ReverseMap();
            CreateMap<CountryViewModel,Country>()
                .ForMember(d=>d.GeographyLevel1Id,o=>o.MapFrom(s=>s.CountryId))
                .ReverseMap();
            CreateMap<AirportInfoMinimalViewModel,Airport>()
                .ForMember(d => d.AirportId, o => o.MapFrom(s => s.Id)).ReverseMap();
            CreateMap<AirportInfoViewModel, Airport>()
                .ForMember(d=>d.AirportId, o=>o.MapFrom(s=>s.Id))
                .ForMember(d => d.GeographyLevel1Id, o => o.MapFrom(s => s.CountryId))
                .ForMember(d => d.Country, o => o.MapFrom(s => s.CountryViewModel))
                .ForMember(d=>d.Type, o=>o.MapFrom(s=>s.Type)).ReverseMap();
                

            CreateMap<CreateRouteRequest, Route>().ReverseMap();
            CreateMap<RouteViewModel, Route>()
                 .ForMember(d => d.RouteId, o => o.MapFrom(s => s.Id))
                 .ReverseMap();
        }
    }
}
