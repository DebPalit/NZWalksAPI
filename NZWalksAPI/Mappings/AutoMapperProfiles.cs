using AutoMapper;
using NZWalksAPI.Models;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Mappings
{
    public class AutoMapperProfiles: Profile 
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Region, RegionDto>().ReverseMap();
        }
    }
}
