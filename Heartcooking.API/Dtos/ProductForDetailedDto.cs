using System.Collections.Generic;
using Heartcooking.API.Models;

namespace Heartcooking.API.Dtos
{
    public class ProductForDetailedDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }
        public double Fiber { get; set; }
        public double Kilocalories { get; set; }
        public double Protein { get; set; }
        public double? Salt { get; set; }
        public double SaturatedFat { get; set; }
        public double Sugar { get; set; }
        public bool IsVegan { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<ProductAllergen> ProductsAllergens { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}