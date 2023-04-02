using System;
using System.Collections.Generic;

namespace Employee_Report.Model.Models
{
    public partial class Poc
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<EmployeePoc> EmployeePocs { get; } = new List<EmployeePoc>();
    }
}
