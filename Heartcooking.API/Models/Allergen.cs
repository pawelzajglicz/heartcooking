using System.Collections.Generic;

namespace Heartcooking.API.Models
{
    public class Allergen : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductAllergen> ProductsAllergens { get; set; }
    }
}