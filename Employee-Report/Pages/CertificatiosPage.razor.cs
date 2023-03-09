using Employee_Report.Model.Models;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components;

namespace Employee_Report.Pages
{
    public partial class CertificatiosPage
    {
        [Inject]
        public Repository.IServices.ICertificationsService service { get; set; }
        public IEnumerable<Certifications>? certificationslist { get; set; }
        public Certifications certifications = new();
        private bool IsHidden { get; set; } = true;
        protected override async Task OnInitializedAsync()
        {
            var response = await service.GetCertificationDetails();
            certificationslist = Utility.GetResponseData<List<Certifications>>(response.response);
        }
        private async void SaveEntry()
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
        private void Save()
        {
            IsHidden = !IsHidden;
        }
        private void Cancel()
        {
            IsHidden = !IsHidden;
        }
    }
}
