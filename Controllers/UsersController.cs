using BudgetManagerAPI.Data;
using BudgetManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection;

namespace BudgetManagerAPI.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UsersController: ControllerBase
    {



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllUsers()
        {
            var function = new DUserAccounts();

            var list = await function.GetUserAccountsAsync();

            return Ok(list);
        }


        [HttpGet("id:int", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetUserById(int id)
        {
            var function = new DUserAccounts();

            MUserAccounts user = await function.GetUserAccountsByIdAsync(id);

            return Ok(user);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<MUserAccounts>> InsertUser([FromBody] MUserAccounts parameters)
        {
            var function = new DUserAccounts();

            MUserAccounts user = await function.InsertUserAccountsAsync(parameters);

            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

    }
}
