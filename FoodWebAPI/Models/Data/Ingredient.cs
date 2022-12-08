namespace FoodWebAPI.Models.Data
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public int RecipieId { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }    
    }
}
