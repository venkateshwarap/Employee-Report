using Employee.DataModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Employee_Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly EmployeeInfoContext _context;
        public AuthenticateController(EmployeeInfoContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                var employee = _context.Employees.ToList().Find(x => x.Email == loginModel.UserName && x.Key == loginModel.security);

                if (employee == null)
                {
                    return BadRequest("User not found.");
                }
                else
                {
                   
                return Ok("User successfully");
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
