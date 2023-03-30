using Employee.DataModel.Models;
using Employee_Report.Model.Models;

namespace Employee_Report.Pages.Admin
{
    public partial class AdminRoles
    {
        Repository.Services.GetRoleService roleService = new Repository.Services.GetRoleService();
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
        private async void AddRole()
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
        private void CancelRole()
        {
            navManager.NavigateTo("/role", forceLoad: true);
        }
    }
}
