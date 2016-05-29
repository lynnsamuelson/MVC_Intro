using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Intro.ViewModels
{
    public class EmployeeDepartmentDetailViewModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public int DepartmentName { get; set; }
        public List<EmployeeDetailViewModel> Employees { get; set; }
    }
}