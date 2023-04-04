using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Microsoft.AspNetCore.Mvc;
using Employee_Report.API.Utilities;

namespace Employee_Report.API.Controllers
{
    [Route(Constants.RT_ROLE)]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet(Constants.GET)]
        public async Task<IActionResult> GetRole()
        {
            try
            {
                var result = await _roleService.GetRoleDetails();
                if (!result.status)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost(Constants.CREATE)]
        public async Task<IActionResult> AddRole(Role role)
        {
                try
                {
                    var result = await _roleService.CreateRole(role);
                    if (result.status)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound(result);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
        }


    }
}
