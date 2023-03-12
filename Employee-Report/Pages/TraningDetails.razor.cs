using Employee.DataModel.Models;
using Employee_Report.Model.Models;
using Employee_Report.Utilities;
using static Employee_Report.Pages.EmployeeReport;

namespace Employee_Report.Pages
{
    public partial class TraningDetails
    {
        Repository.Services.TrainingService TrainingService= new();
        public IEnumerable<Training>? trainingDetails { get; set; }
        public Training trainingModel = new();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            var response = await TrainingService.GetTrainings();
            trainingDetails = Utility.GetResponseData<List<Training>>(response.response);
        }

        public async void AddTraining()
        {
            if (trainingModel != null)
            {
                var response = await TrainingService.AddNewTraining(trainingModel);
                if (response.status)
                {
                    navManager.NavigateTo("/trainings", forceLoad: true);
                    IsHidden = false;
                }
            }
        }
        private void cancelTraining()
        {
            navManager.NavigateTo("/trainings", forceLoad: true);
        }
        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
    }
}
