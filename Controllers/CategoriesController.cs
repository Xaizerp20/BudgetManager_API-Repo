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
        public async Task<ActionResult> GetAllCategories()
        {
            var function = new DCategories();

            var list = await function.GetCategoriesAsync();

            return Ok(list);
        }


        [HttpPost]
        public async Task<HttpStatusCode> InsertCategories([FromBody] MCategories parameters)
        {
            var function = new DCategories();

            await function.InsertCategoriesAsync(parameters);

            return HttpStatusCode.Created;
        }

    }
}
