﻿using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;

namespace Employee_Report.Pages.Employee
{
    public partial class IntellectualPropertyPage
    {
        private readonly IIntellectualPropertyService _intellectualservice;
        private readonly IGetRoleService _roleService;
        public IntellectualPropertyPage(IIntellectualPropertyService intellectualservice, IGetRoleService roleService)
        {
            _intellectualservice = intellectualservice;
            _roleService = roleService;
        }
        public IEnumerable<IntellectualProperty> intellectualList { get; set; }
        public IntellectualProperty intelleactualProperty = new();
        private bool IsHidden { get; set; } = false;
        IEnumerable<Role> roleDetails { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var response = await _intellectualservice.GetIntelleactualProperty();
            intellectualList = Utility.GetResponseData<List<IntellectualProperty>>(response.response);
            var roleResponse = await _roleService.GetRoleDetails();
            if(roleResponse.status)
            {
                roleDetails = Utility.GetResponseData<IEnumerable<Role>>(roleResponse.response);
            }
        }
        private async void AddIP()
        {
            if (intellectualList != null)
            {
                var response = await _intellectualservice.CreateIntelleactualProperty(intelleactualProperty);
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
