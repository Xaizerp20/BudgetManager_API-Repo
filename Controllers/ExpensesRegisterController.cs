using BudgetManagerAPI.Data;
using BudgetManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection;

namespace BudgetManagerAPI.Controllers
{
    [ApiController]
    [Route("api/ExpensesRegister")]
    public class ExpensesRegisterController : ControllerBase
    {



        [HttpGet]
        public async Task<ActionResult> GetAllExpenses()
        {
            var function = new DExpensesRegister();

            var list = await function.GetExpensesRegistersAsync();

            return Ok(list);
        }


        [HttpPost]
        public async Task<HttpStatusCode> InsertUser([FromBody] MExpensesRegister parameters)
        {
            var function = new DExpensesRegister();

            await function.InsertExpensesRegistersAsync(parameters);

            return HttpStatusCode.Created;
        }

    }
}
