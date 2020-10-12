using AutoMapper;
using System.Linq;

using Heartcooking.API.Dtos;
using Heartcooking.API.Models;

namespace Heartcooking.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        
        public AutoMapperProfiles()
        {
            CreateMap<Allergen, AllergenForDetailedDto>();
            CreateMap<Photo, PhotoForDetailedDto>();

            CreateMap<Product, ProductForDetailedDto>()
                .ForMember(destination => destination.PhotoUrl, options => 
                    options.MapFrom(source => source.Photos.FirstOrDefault(photo => photo.IsMain).Url))
                .ForMember(destination => destination.Allergens, options =>
                    options.MapFrom(source => source.ProductsAllergens.Select(pa => pa.Allergen).ToList()));
                    
            CreateMap<Product, ProductForListDto>()
                .ForMember(destination => destination.PhotoUrl, options => 
                    options.MapFrom(source => source.Photos.FirstOrDefault(photo => photo.IsMain).Url));
        }
    }
}