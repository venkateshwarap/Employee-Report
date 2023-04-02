using Employee_Report.Model.Models;
using Employee_Report.Utilities;

namespace Employee_Report.Pages.Admin
{
    public partial class GetRoles
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
           var resp = await roleService.GetRoleDetails();
            role = Utility.GetResponseData<IEnumerable<Role>>(resp.response);
        }
        private async void AddRole()
        {
            if (roleModel != null)
            {
                var response = await roleService.AddRole(roleModel);
                if (response.status)
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
