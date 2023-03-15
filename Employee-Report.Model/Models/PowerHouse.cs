using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.DataModel.Models
{
    public partial class PowerHouse
    {
        public int Id { get; set; }
        public string? EmpId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? RoleId { get; set; }
        public string? ReportingTo { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? modifiedOn { get; set; }
    }
}