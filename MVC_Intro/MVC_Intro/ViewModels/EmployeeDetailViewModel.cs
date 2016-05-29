using MVC_Intro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Intro.ViewModels
{
    public class EmployeeDetailViewModel
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public string DepartmentName { get; set; }
    }
}