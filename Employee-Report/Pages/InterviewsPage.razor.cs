using Employee_Report.Model.Models;
using EmployeeDetails.Api.Utilities;
using Microsoft.AspNetCore.Components;

namespace Employee_Report.Pages
{
    public partial class InterviewsPage
    {
        [Inject]
        public Services.InterviewService interviewService { get; set; }
        public IEnumerable<Interview> interviewsDetails { get; set; }
        public Interview InterviewModel = new();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            var response = await interviewService.GetInterviews();
            interviewsDetails = Utility.GetResponseData<List<Interview>>(response.response);
        }
        private async void addInterview()
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
