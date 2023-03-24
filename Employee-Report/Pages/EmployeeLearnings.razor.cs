using Employee.DataModel.Models;

namespace Employee_Report.Pages
{
    public partial class EmployeeLearnings
    {
        Repository.Services.EmployeeLearningService employeeLearningService = new Repository.Services.EmployeeLearningService();
        public IEnumerable<EmployeeLearning> employeeLearning { get; set; }
        public EmployeeLearning employeeLearningData = new();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            employeeLearning = (await employeeLearningService.GetEmployeeLearnings()).ToList();
        }
        public async void AddProject()
        {
            if (employeeLearning != null)
            {
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
