using System;
using System.Collections.Generic;

namespace Employee.DataModel.Models
{
    public partial class Interview
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Skill { get; set; } = null!;

        public string Role { get; set; } = null!;

        public string Status { get; set; } = null!;

        public DateTime? Date { get; set; }

        public string ReportingTo { get; set; } = null!;
    }
}
