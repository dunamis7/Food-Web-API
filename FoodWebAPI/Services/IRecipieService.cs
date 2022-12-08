
using FoodWebAPI.DTOs;
using FoodWebAPI.Models.Data;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodWebAPI.Services
{
    public interface IRecipieService
    {
        //Returns all recipies
        Task<IEnumerable<RecipieDTO>> GetAllRecipieAsync();

        //Return a single recipie
        Task<RecipieDTO> GetRecipieAsync(int id);

        //Adds a new recipie
        Task<Recipie> AddRecipieAsync(Recipie recipie);

        //Delete a recipie
        Task<Recipie> DeleteRecipieAsync(int id);

        //Updates a recipie
        Task UpdateRecipieAsync(Recipie recipie);

        //Returns all ingredients for a recipie
        Task<IEnumerable<Ingredient>> GetIngredientsForRecipie(int id);


    }
}
