using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Report.Model.Models
{
    public partial class EmployeeSkills
    {
        public int ID { get; set; }
        public string EmpID { get; set; }
        public int SkillID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set;}
        public DateTime ModifiedOn { get; set; }
    }
}
