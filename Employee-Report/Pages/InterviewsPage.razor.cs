using Employee.DataModel.Models;
using Employee_Report.Utilities;

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

        public async void AddInterview()
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
        public void CancelInterview()
        {
            navManager.NavigateTo("/Interviews", forceLoad: true);
        }
        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
    }
}
