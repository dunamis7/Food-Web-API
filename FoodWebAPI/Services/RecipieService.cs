using FoodWebAPI.DTOs;
using FoodWebAPI.Models;
using FoodWebAPI.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWebAPI.Services
{
    public class RecipieService : IRecipieService
    {
        private readonly AppDbContext _context;

        public RecipieService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RecipieDTO>> GetAllRecipieAsync()
        {
            var recipies = await _context.Recipies.ToListAsync();

            var recipieView = recipies.Select(x => new RecipieDTO
            {
                RecipieId = x.RecipieId,
                Name = x.Name,
                TimeToCook = x.TimeToCook,
                Method = x.Method,
                isVeganFood = x.isVeganFood
            });
            return recipieView;
        }

        public async Task<Recipie> AddRecipieAsync(Recipie recipie)
        {
            await _context.Recipies.AddAsync(recipie);
            await _context.SaveChangesAsync();
            return recipie;
        }

      
        public async Task<RecipieDTO> GetRecipieAsync(int id)
        {
            var recipie = await _context.Recipies.Select(r => 
                           new RecipieDTO()
                          {
                              RecipieId = r.RecipieId,
                              Name = r.Name,
                              TimeToCook = r.TimeToCook,
                              Method = r.Method,
                              isVeganFood = r.isVeganFood

                          }).SingleOrDefaultAsync(r=>r.RecipieId == id);
         
            return  recipie;
        }

        public async Task UpdateRecipieAsync(Recipie recipie)
        {
          _context.Entry(recipie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Recipie> DeleteRecipieAsync(int id)
        {
           var recipie = await _context.Recipies.SingleOrDefaultAsync(n =>n.RecipieId==id);
           _context.Recipies.Remove(recipie);
           await _context.SaveChangesAsync();


            return recipie;
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsForRecipie(int id)
        {
            var ingredients = await _context.Ingredients.Where(n => n.RecipieId == id).ToListAsync();

            return ingredients;
        }

    }
}
