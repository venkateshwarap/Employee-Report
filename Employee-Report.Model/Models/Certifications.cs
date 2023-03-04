using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Report.Model.Models
{
    public class Certifications
    {
        public int Id { get; set; }
        public string? EmpId { get; set; }
        public string? Name { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTill { get; set; }
        public int EACId { get; set; }
    }
}
