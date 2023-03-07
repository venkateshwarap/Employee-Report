using Employee_Report.API.Service;
using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Repository.Services;
using EmployeeDetails.Api.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.Identity.Client;

namespace Employee_Report.Pages
{
    public partial class InterviewsPage
    {
        Repository.Services.InterviewService interviewService = new Repository.Services.InterviewService();
        public IEnumerable<Interview>? interviewsDetails { get; set; }
        public Interview InterviewModel = new();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            var response = await interviewService.GetInterviews();
            interviewsDetails = Utility.GetResponseData<List<Interview>>(response.response);
        }

        public async void addInterview()
        {
            if (InterviewModel != null)
            {
                var response = await interviewService.AddInterview(InterviewModel);
                if (response.status)
                {
                    navManager.NavigateTo("/Interviews", forceLoad: true);
                    IsHidden = false;
                }

            }
        }
        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
    }
}
