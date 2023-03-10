using Employee.DataModel.Models;
using Employee_Report.Model.Models;

namespace Employee_Report.Pages
{
    public partial class TraningDetails
    {

        public bool HideLearningControls = true;
        public bool HideAdd = false;
        public bool HideGeid = false;
        public Training traning { get; set; }
        public Training[] TraningList { get; set; }
        HttpClient client = new HttpClient();
        protected async override Task OnInitializedAsync()
        {
            traning = new Training();
            var responseMessage = await client.GetAsync(AppSettings.Config.GetTrainings);
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadFromJsonAsync<Training[]>();
                TraningList = data;
            }
            await base.OnInitializedAsync();
        }
        public void AddLearning()
        {
            if (HideLearningControls == true)
            {
                HideLearningControls = false;
                HideAdd = true;
            }
        }
    }
}
