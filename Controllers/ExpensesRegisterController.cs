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

        [HttpGet("int:id", Name = "GetExpenseById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetExpenseById(int id)
        {
            var function = new DExpensesRegister();

            MExpensesRegister expense = await function.GetExpensesRegistersByIdAsync(id);

            return Ok(expense);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<MExpensesRegister>> InsertExpense([FromBody] MExpensesRegister parameters)
        {
            var function = new DExpensesRegister();

            MExpensesRegister expense =  await function.InsertExpensesRegistersAsync(parameters);

            return CreatedAtAction(nameof(GetExpenseById), new { id = expense.UserId }, expense);
        }



        [HttpPut("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateExpenseAmount(int id, [FromBody] MExpensesRegister parameters)
        {
            var function = new DExpensesRegister();

            parameters.ExpenseId = id;

            await function.UpdateExpensesRegistersAsync(parameters);

            return NoContent();
        }


        [HttpDelete("int:id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> deletetExpense(int id)
        {
            var function = new DExpensesRegister();

            await function.DeleteExpensesRegistersAsync(id);

            return Ok();
        }

    }
}
