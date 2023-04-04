using System;
using System.Collections.Generic;

namespace Employee_Report.Model.Models
{
    public class Employees
    {
        public string? Id { get; set; } = null!;

        public string? FirstName { get; set; } = null!;

        public string? LastName { get; set; } = null!;

        public string? Email { get; set; } = null!;

        public bool Status { get; set; }

        public string? Key { get; set; } 

        public  DateTime JoiningDate { get; set; }

        public DateTime? LastWorkingDate { get; set; }

    }
}