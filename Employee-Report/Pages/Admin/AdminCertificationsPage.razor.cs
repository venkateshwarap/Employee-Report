using Employee.DataModel.Models;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components;

namespace Employee_Report.Pages.Admin
{
    public partial class AdminCertificationsPage
    {
        [Inject]
        public Repository.IServices.ICertificationsService service { get; set; }
        public IEnumerable<Certification> certificationslist { get; set; }
        public Certification certifications = new();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            var response = await service.GetCertificationDetails();
            certificationslist = Utility.GetResponseData<List<Certification>>(response.response);
        }
        private async void AddCertification()
        {
            if (certifications != null)
            {
                var response = await service.CreateCertificationDetails(certifications);
                if (response.status)
                {
                    navManager.NavigateTo("/certifications", forceLoad: true);
                    IsHidden = false;
                }
            }
        }

        private void CancelCertification()
        {
            navManager.NavigateTo("/certifications", forceLoad: true);
        }
        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
    }
}
