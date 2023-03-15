using Employee_Report.Model.Models;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components;

namespace Employee_Report.Pages
{
    public partial class IntellectualPropertyPage
    {
        [Inject]
        public Repository.IServices.IIntellectualPropertyService service { get; set; }
        
        public IEnumerable<IntellectualProperty>? intelleactuallist { get; set; }
        public IntellectualProperty intelleactualProperty = new();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            var response = await service.GetIntelleactualProperty();
            intelleactuallist = Utility.GetResponseData<List<IntellectualProperty>>(response.response);
        }
        private async void AddIntelleactual()
        {
            if (intelleactuallist != null)
            {
                var response = await service.CreateIntelleactualProperty(intelleactualProperty);
                if (response.status)
                {
                    navManager.NavigateTo("/intellectual", forceLoad: true);
                    IsHidden = false;
                }
            }
        }
        private void CancelIntelleactual()
        {
            navManager.NavigateTo("/intellectual", forceLoad: true);
        }
        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
    }
}
