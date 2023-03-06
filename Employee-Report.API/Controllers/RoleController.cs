using Employee_Report.API.IService;
using Employee_Report.API.Service;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            this._roleService = roleService;
        }
        [HttpGet("GetRole")]
        public async Task<IActionResult> GetRole()
        {
            try
            {
                var r = await _roleService.GetRoleDetails();
                if (r == null)
                {
                    return NotFound();
                }
                return Ok(r);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] Role role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var r = await _roleService.PostRole(role);
                    if (r > 0)
                    {
                        return Ok(r);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


    }
}
