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
        public async Task<ActionResult> GetAllUsers()
        {
            var function = new DUserAccounts();

            var list = await function.GetUserAccountsAsync();

            return Ok(list);
        }


        [HttpPost]
        public async Task<HttpStatusCode> InsertUser([FromBody] MUserAccounts parameters)
        {
            var function = new DUserAccounts();

            await function.InsertUserAccountsAsync(parameters);

            return HttpStatusCode.Created;
        }

    }
}
