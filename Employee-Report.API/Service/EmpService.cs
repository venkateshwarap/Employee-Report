using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class EmpService : IEmpService
    {
        private EmployeeInfoContext _dBContext;

        public EmpService(EmployeeInfoContext context)
        {
            this._dBContext = context;
        }
        public async Task<IEnumerable<Employees>> GetEmployee()
        {
            if (_dBContext != null)
            {
                return await _dBContext.Employees.ToListAsync();
            }
            return null;

        }

        public EMP GetEmployeeById(string Id)
        {
            if (_dBContext != null)
            {
                var result = _dBContext.Employees.ToList().Find(x => x.Id == Id);

                var skill = (from empskills in _dBContext.EmployeeSkills
                             join skills in _dBContext.Skills on empskills.SkillId equals skills.Id
                             join employees in _dBContext.Employees on empskills.EmpId equals employees.Id
                             where employees.Id == Id
                             select new { skills.SkillName }).ToList();
                var empskill = string.Join(", ", skill);


                EMP employee = new EMP();
                employee.Id = result.Id;
                employee.EmpFullName = result.FirstName + " " + result.LastName;
                employee.EmpEmployeeSkill = empskill;

                return employee;
            }
            return null;
        }
    }
}
