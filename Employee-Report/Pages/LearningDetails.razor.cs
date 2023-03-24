using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Service;
using Employee_Report.Model.Models;
using Employee_Report.Repository.Services;
using Employee_Report.Utilities;

namespace Employee_Report.Pages
{
    public partial class LearningDetails
    {
        public bool HideLearningControls = true;
        public bool HideAdd = false;
        public bool HideGrid = false;
        public Learning learning { get; set; }
        public List<Learning> learningList { get; set; }
        HttpClient client = new HttpClient();
        Repository.Services.LearningService learningService = new Repository.Services.LearningService();
        protected override async Task OnInitializedAsync()
        {
            learning = new Learning();
            var responseMessage = await learningService.GetLearnings();
           var empId =  Utility.GetSessionClaim("EmployeeId");
            if (responseMessage != null)
            {
                learningList = Utility.GetResponseData<List<Learning>>(responseMessage.response);
            }
            //base.OnInitialized();
        }
        public void AddLearning()
        {
            if (HideLearningControls == true)
            {
                HideLearningControls = false;
                HideAdd = true;
                HideGrid = true;
            }
        }
        public async void PostLearningDetails()
        {

            if (learning != null)
            {
                var response = await learningService.AddNewLearning(learning);
                if (response.status)
                {
                    navManager.NavigateTo("/learnings", forceLoad: true);
                    HideAdd = false;
                    HideLearningControls = true;
                    HideGrid = false;
                }

            }
        }
        public void ClearPostLearningDetails()
        {
            HideLearningControls = true;
            HideAdd = false;
            HideGrid = false;
        }

    }
}
