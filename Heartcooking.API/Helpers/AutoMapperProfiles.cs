using AutoMapper;

using Heartcooking.API.Dtos;
using Heartcooking.API.Models;

namespace Heartcooking.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductForDetailedDto>();
            CreateMap<Product, ProductForListDto>();
        }
    }
}