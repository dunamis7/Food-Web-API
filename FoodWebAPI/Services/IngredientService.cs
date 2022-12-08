using FoodWebAPI.Models;
using FoodWebAPI.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWebAPI.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly AppDbContext _context;

        public IngredientService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Ingredient> AddIngredientAsync(Ingredient ingredient)
        {
            await _context.Ingredients.AddAsync(ingredient);
            await _context.SaveChangesAsync();

            return ingredient;
        }

        public async Task<Ingredient> DeleteIngredientAsync(int id)
        {
            var ingredient =await  GetIngredientAsync(id);
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();

            return ingredient;

        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            var ingredients = await _context.Ingredients.ToListAsync();
            return ingredients;
        }

        public async Task <Recipie> GetRecipieOfIngredientAsync(int id)
        {
            var recipie = await _context.Recipies.FindAsync(id);
            return recipie;

            
        }

        //var ingredients = await _context.Ingredients.Where(n => n.RecipieId == id).ToListAsync();

        public async Task<Ingredient> GetIngredientAsync(int id)
        {
            var ingredient = await _context.Ingredients.SingleOrDefaultAsync(n => n.IngredientId == id);
            return ingredient;
        }

        public async Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient)
        {
           _context.Entry(ingredient).State = EntityState.Modified;
           await  _context.SaveChangesAsync();

            return ingredient;


        }
    }
}
