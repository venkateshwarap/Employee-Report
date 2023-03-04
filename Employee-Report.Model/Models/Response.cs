using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DataModel.Models
{
    public class Response
    {
        public Object? response { get; set; }
        public string? message { get; set; }
        public bool status { get; set; }
    }
}
