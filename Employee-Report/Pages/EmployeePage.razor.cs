using Employee.DataModel.Models;
using Microsoft.AspNetCore.Components.Web;

namespace Employee_Report.Pages
{
    public partial class EmployeePage
    {
        Repository.Services.EmployeesService employeesService = new Repository.Services.EmployeesService();
        public IEnumerable<Employees> employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            employees = (await employeesService.GetEmployeeDetails()).ToList();
        }
        public void Clicked(MouseEventArgs Args)
        {

            navManager.NavigateTo("/EmployeeReport");
        }
    }
}
