using FoodWebAPI.Models.Data;
using FoodWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodWebAPI.Controllers
{
    [ApiController]
    [Route("api/ingredients")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _service;

        public IngredientsController(IIngredientService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task <IActionResult> GetIngredients()
        {
            var ingredients = await _service.GetAllIngredientsAsync();
            return Ok(ingredients);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetIngredient(int id)
        {
            var ingredient = await _service.GetIngredientAsync(id);

            if (ingredient == null) return NotFound();

            return Ok(ingredient);
        }

        [HttpPost]
        public async Task <IActionResult> AddIngredient([FromBody] Ingredient ingredient)
        {
            await _service.AddIngredientAsync(ingredient);
            return Ok(ingredient);
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> UpdateIngredient(Ingredient ingredient, int id)
        {
            if (id != ingredient.IngredientId) return BadRequest();
  

            await _service.UpdateIngredientAsync(ingredient);

            return Ok(ingredient);

        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteIngredient(int id)
        {
            var ingredient = await _service.GetIngredientAsync(id);
            if(ingredient == null) return NotFound();
            await  _service.DeleteIngredientAsync(id);

            return Ok(ingredient);
        }

        [HttpGet]
        [Route("/api/ingredients/{Iid}/recipie")]


        public async Task <IActionResult> GetRecipie(int Iid)
        {
            var recipie =await _service.GetRecipieOfIngredientAsync(Iid);

            return Ok(recipie);

        }

    }
}
