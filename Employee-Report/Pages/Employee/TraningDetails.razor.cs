using Employee_Report.Model.Models;
using Employee_Report.Utilities;

namespace Employee_Report.Pages.Employee
{
    public partial class TraningDetails
    {

        public bool HideLearningControls = true;
        public bool HideAdd = false;
        public bool HideGrid = false;
        public Training training { get; set; }
        public List<Training> TraningList { get; set; }
        HttpClient client = new HttpClient();
        Repository.Services.TrainingService trainingService = new Repository.Services.TrainingService();
        protected async override Task OnInitializedAsync()
        {
            training = new Training();
            var responseMessage = await trainingService.GetTrainings();
            if (responseMessage != null)
            {
                TraningList = Utility.GetResponseData<List<Training>>(responseMessage.response);
            }
            await base.OnInitializedAsync();
        }
        public void AddTraining()
        {
            if (HideLearningControls == true)
            {
                HideLearningControls = false;
                HideAdd = true;
                HideGrid = true;
            }
        }

        public async void PostTrainingDetails()
        {
            if (training != null)
            {
                var response = await trainingService.CreateTraining(training);
                if (response.status)
                {
                    navManager.NavigateTo("/trainings", forceLoad: true);
                    HideAdd = false;
                    HideGrid = false;
                    HideLearningControls = true;
                }
            }
        }
        public void ClearPostTrainingDetails()
        {
            HideLearningControls = true;
            HideAdd = false;
            HideGrid = false;
        }
    }
}
