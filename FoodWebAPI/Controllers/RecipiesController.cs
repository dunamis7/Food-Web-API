using FoodWebAPI.DTOs;
using FoodWebAPI.Models.Data;
using FoodWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace FoodWebAPI.Controllers
{
    [ApiController]
    [Route("api/recipies")]
    public class RecipiesController : ControllerBase
    {
        private readonly IRecipieService _service;

        public RecipiesController(IRecipieService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipie()
        {
            var recipies = await _service.GetAllRecipieAsync();

            return Ok(recipies);
        }

        [HttpGet("{id}")]
    
        public async Task<IActionResult> GetARecipie(int id)
        {
            var recepie = await _service.GetRecipieAsync(id);
            if (recepie == null)
            {
                return NotFound();
            }
            return Ok(recepie);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipie([FromBody] Recipie recipie)
        {
            await _service.AddRecipieAsync(recipie);

            return Ok(recipie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipie(Recipie recipie, int id)
        {
            if (id != recipie.RecipieId) return BadRequest();
            await _service.UpdateRecipieAsync(recipie);
            return Ok(recipie);
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteRecipie(int id)
        {
           var recipie = await _service.GetRecipieAsync(id);
           if(recipie == null) return NotFound();
           await _service.DeleteRecipieAsync(id); 
           return Ok(recipie);
        }


        [HttpGet]
        [Route("/api/recipies/{rid}/ingredients")]
        public async Task <IActionResult> GetRecipieIngredients(int rid)
        {
            var ingredients = await _service.GetIngredientsForRecipie(rid);
            if(ingredients == null) return NotFound();
            return Ok(ingredients);
        }





    }
}
