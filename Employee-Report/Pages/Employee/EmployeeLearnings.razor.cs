using Employee.DataModel.Models;
using Employee_Report.Model.ModelView;
using Employee_Report.Utilities;

namespace Employee_Report.Pages.Employee
{
    public partial class EmployeeLearnings
    {
        Repository.Services.EmployeeLearningService employeeLearningService = new Repository.Services.EmployeeLearningService();
        Repository.Services.LearningService learningService = new Repository.Services.LearningService();
        public IEnumerable<EmployeeLearningView> employeeLearning { get; set; }
        public EmployeeLearning employeeLearningData = new();
        public string _empId { get; set; }
        public IEnumerable<Learning> learninglist { get; set; }
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            _empId = Utility.GetSessionClaim("EmployeeId");
            var result = await employeeLearningService.GetEmployeeLearningById(_empId);
            employeeLearning = Utility.GetResponseData<IEnumerable<EmployeeLearningView>>(result.response);
            var result_learning = await learningService.GetLearnings();
            learninglist = Utility.GetResponseData<List<Learning>>(result_learning.response);
        }
        public async void AddEmployeeLearning()
        {
            if (employeeLearning != null)
            {
                employeeLearningData.EmpId = _empId;
                var response = await employeeLearningService.AddEmployeeLearning(employeeLearningData);
                if (response.IsSuccessStatusCode)
                {
                    navManager.NavigateTo("/employeeLearnings", forceLoad: true);
                    IsHidden = false;
                }
            }
        }
        public void CancelProject()
        {
            navManager.NavigateTo("/employeeLearnings", forceLoad: true);
        }
        private void AddClass()
        {
            IsHidden = !IsHidden;
        }

    }
}
