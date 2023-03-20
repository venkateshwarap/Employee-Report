using Employee.DataModel.Models;
using Microsoft.AspNetCore.Components.Web;

namespace Employee_Report.Pages
{
    public partial class EmployeePage
    {
        Repository.Services.EmployeesService employeesService = new Repository.Services.EmployeesService();
        public IEnumerable<Employees> employees { get; set; }
        public Employees emp = new Employees();
        
        protected override async Task OnInitializedAsync()
        {
            employees = (await employeesService.GetEmployeeDetails()).ToList();
        }
        public void Clicked(string id,string name)
        {
            HttpContext.HttpContext.Session.SetString("EmployeeId", id);
            HttpContext.HttpContext.Session.SetString("Name", name);
            navManager.NavigateTo("/EmployeeReport");
        }
    }
}
