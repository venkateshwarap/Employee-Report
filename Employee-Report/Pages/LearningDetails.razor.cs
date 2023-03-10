using Employee.DataModel.Models;
using Employee_Report.Model.Models;

namespace Employee_Report.Pages
{
    public partial class LearningDetails
    {
        public bool HideLearningControls = true;
        public bool HideAdd = false;
        public bool HideGeid = false;
        public Learning learning { get; set; }
        public Learning[] learningList { get; set; }
        HttpClient client = new HttpClient();

        protected override async Task OnInitializedAsync()
        {
            learning = new Learning();
            var responseMessage = await client.GetAsync(AppSettings.Config.GetlearningURl);
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadFromJsonAsync<Learning[]>();
                learningList = data;
            }
            base.OnInitialized();
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
