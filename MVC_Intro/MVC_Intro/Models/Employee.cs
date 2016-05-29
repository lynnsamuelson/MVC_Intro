using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Intro.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}