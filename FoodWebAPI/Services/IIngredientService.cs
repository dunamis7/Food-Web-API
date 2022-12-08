using FoodWebAPI.Models.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodWebAPI.Services
{
    public interface IIngredientService
    {
        Task<IEnumerable<Ingredient>> GetAllIngredientsAsync();

        Task<Ingredient>  GetIngredientAsync(int id);
        Task<Ingredient> AddIngredientAsync(Ingredient ingredient); 
        Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient);
        Task<Ingredient> DeleteIngredientAsync (int id);

        Task <Recipie> GetRecipieOfIngredientAsync(int id);
    }
}
