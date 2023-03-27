using System;
using System.Collections.Generic;

namespace Employee.DataModel.Models
{
    public partial class Certification
    {
        public int Id { get; set; }

        public string? EmpId { get; set; }

        public string? Name { get; set; }


        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidTill { get; set; }

        public int Eacid { get; set; }
    }
}
