using System;
using System.Collections.Generic;

namespace Employee.DataModel.Models
{
    public partial class Training
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? HoursOfLearning { get; set; }
    }
}
