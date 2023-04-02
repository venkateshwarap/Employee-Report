using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Report.Model.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter {0}.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Please enter {0}.")]
        public string? security { get; set; }
        public bool IsValidLogin { get; set; } = true;
    }
}
