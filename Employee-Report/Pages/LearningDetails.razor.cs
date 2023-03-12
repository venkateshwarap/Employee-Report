using Employee.DataModel.Models;
using Employee_Report.Model.Models;
using Employee_Report.Utilities;

namespace Employee_Report.Pages
{
    public partial class LearningDetails
    {
        Repository.Services.LearningService LearningService = new();
        public IEnumerable<Learning>? learningDetails { get; set; }
        public Learning learningModel = new();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            var response = await LearningService.GetLearnings();
            learningDetails = Utility.GetResponseData<List<Learning>>(response.response);
        }
        public async void AddLearning()
        {
            if (learningModel != null)
            {
                var response = await LearningService.AddNewLearning(learningModel);
                if (response.status)
                {
                    navManager.NavigateTo("/learnings", forceLoad: true);
                    IsHidden = false;
                }
            }
        }
        private void CancelLearnings()
        {
            navManager.NavigateTo("/learnings", forceLoad: true);
        }

        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
    }
}
