using Employee_Report.API.Service;
using Employee_Report.Model.Models;
using Employee_Report.Repository.Services;
using Microsoft.AspNetCore.Components;

namespace Employee_Report.Pages
{
    public partial class GetRoles
    {
        [Inject]
        public GetRoleService roleService { get; set; }
        public IEnumerable<Role> role { get; set; }
        private bool IsHidden { get; set; } = false;

        public Role roleModel = new();

        private void AddClass()
        {
            IsHidden = !IsHidden;
        }

        protected override async Task OnInitializedAsync()
        {
            role = (await roleService.GetRoleDetails()).ToList();
        }
        private async void addRole()
        {
            if (roleModel != null)
            {
                var response = await roleService.AddRole(roleModel);
                if (response.IsSuccessStatusCode)
                {
                    navManager.NavigateTo("/role", forceLoad: true);
                    IsHidden = false;
                }
            }
        }
    }
}
