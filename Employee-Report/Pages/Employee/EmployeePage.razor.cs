using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components;

namespace Employee_Report.Pages.Employee
{
    public partial class EmployeePage
    {
        [Inject]
        private IEmployeesService _employeesService { get; set; }
        public IEnumerable<Employees> employees { get; set; }
        public Employees emp = new Employees();
        
        protected override async Task OnInitializedAsync()
        {
            var employee_resp = await _employeesService.GetEmployeeDetails();
            employees = Utility.GetResponseData<IEnumerable<Employees>>(employee_resp.response);
        }
        public void Clicked(string id,string name)
        {
            HttpContext.HttpContext.Session.SetString("EmployeeId", id);
            HttpContext.HttpContext.Session.SetString("Name", name);
            navManager.NavigateTo("/EmployeeReport");
        }
    }
}
