using Employee.DataModel.Models;
using Employee_Report.API.Service;
using Employee_Report.Model.Models;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.FileManager;

namespace Employee_Report.Pages.Employee
{
    public partial class EmployeeIntellectualPropertyPage
    {
        [Inject]
        public Repository.IServices.IIntellectualPropertyService service { get; set; }

        public IEnumerable<IntellectualProperty>? intellectualList { get; set; }
        public IntellectualProperty intelleactualProperty = new();
        Repository.Services.GetRoleService roleService = new(); 
        private bool IsHidden { get; set; } = false;
        List<Role> roleDetails = new List<Role>();
        protected override async Task OnInitializedAsync()
        {
            var response = await service.GetIntelleactualProperty();
            intellectualList = Utility.GetResponseData<List<IntellectualProperty>>(response.response);
            var roleResponse = await roleService.GetRoleDetails();
            roleDetails = roleResponse.ToList();
        }
        private async void AddIP()
        {
            if (intellectualList != null)
            {
                var response = await service.CreateIntelleactualProperty(intelleactualProperty);
                if (response.status)
                {
                    navManager.NavigateTo("/intellectual", forceLoad: true);
                    IsHidden = false;
                }
            }
        }
        private void CancelIP()
        {
            navManager.NavigateTo("/intellectual", forceLoad: true);
        }
        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
    }
}
