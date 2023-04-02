using System;
using System.Collections.Generic;

namespace Employee_Report.Model.Models
{
    public partial class Learning
    {
        public int Id { get; set; }

        public int? SkillId { get; set; }

        public int? HoursOfLearning { get; set; }

        public string? Name { get; set; }

        public string? Path { get; set; }
    }
}
