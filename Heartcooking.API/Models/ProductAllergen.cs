namespace Heartcooking.API.Models
{
    public class ProductAllergen
    {
        public int AllergenId { get; set; }
        public Allergen Allergen { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}