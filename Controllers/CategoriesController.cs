using BudgetManagerAPI.Data;
using BudgetManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BudgetManagerAPI.Controllers
{

    [ApiController]
    [Route("api/Categories")]
    public class CategoriesController : ControllerBase
    {



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllCategories()
        {
            var function = new DCategories();

            var list = await function.GetCategoriesAsync();

            return Ok(list);
        }

        [HttpGet("id:int", Name = "GetCategoYById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetCategoYById(int id)
        {
            var function = new DCategories();

            MCategories category = await function.GetCategoryByIdAsync(id);

            return Ok(category);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<MCategories>> InsertCategories([FromBody] MCategories parameters)
        {
            var function = new DCategories();

            MCategories category = await function.InsertCategoriesAsync(parameters);


            return CreatedAtAction(nameof(GetCategoYById), new { id = category.CategoryId }, category);
        }

        [HttpPut("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] MCategories parameters)
        {
            var function = new DCategories();

            parameters.CategoryId = id;

            await function.UpdateCategoriesAsync(parameters);

            return NoContent();
        }



        [HttpDelete("int:id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> deletetExpense(int id)
        {
            var function = new DCategories();

            await function.DeleteExpenseRegisterAsync(id);

            return Ok();
        }


    }
}
