using System.Collections.Generic;

namespace Heartcooking.API.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }
        public double Fiber { get; set; }
        public double Kilocalories { get; set; }
        public double Protein { get; set; }
        public double Salt { get; set; }
        public double SaturatedFat { get; set; }
        public double Sugar { get; set; }
        public bool IsVegan { get; set; }

        public ICollection<Allergen> Allergens { get; set; }
    }
}