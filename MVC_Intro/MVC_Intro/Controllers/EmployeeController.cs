using MVC_Intro.Models;
using MVC_Intro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Intro.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            DataStoreContext _myEmployeeContext = new DataStoreContext();

            var employeeDepartment = (from emp in _myEmployeeContext.Employee
                                      join dept in _myEmployeeContext.Department
                                      on emp.DepartmentId equals dept.DepartmentId
                                      orderby dept.DepartmentName
                                      select new EmployeeDetailViewModel
                                      {
                                          Name = emp.Name,
                                          EmployeeId = emp.EmployeeId,
                                          DepartmentName = dept.DepartmentName
                                      }).ToList();
            EmployeeDepartmentDetailViewModel employeeDetails = new EmployeeDepartmentDetailViewModel
            {
                Employees = employeeDepartment
            };


            return View(employeeDetails);

        }

        //GET
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeDepartmentDetailViewModel employeeDetails)
        {
            using (DataStoreContext _context = new DataStoreContext())
            {
                if (ModelState.IsValid)
                {
                    Employee employee = new Employee
                    {
                        Name = employeeDetails.Name,
                        DepartmentId = employeeDetails.DepartmentId
                    };
                    _context.Employee.Add(employee);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(employeeDetails);
            }

        }

        //this is the HttpGET  method for the edit page
        public ActionResult Edit(int employeeId)
        {
            using (DataStoreContext _context = new DataStoreContext())
            {
                var employeeDetails = (from emp in _context.Employee
                                       where emp.EmployeeId == employeeId
                                       select new EmployeeDetailViewModel
                                       {
                                           Name = emp.Name,
                                           EmployeeId = emp.EmployeeId,
                                           
                                       }).ToList();

                EmployeeDepartmentDetailViewModel employeeModel = new EmployeeDepartmentDetailViewModel
                {
                    Name = employeeDetails.Select(a => a.Name).FirstOrDefault(),
                };

                return View(employeeModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeDepartmentDetailViewModel employeeDetails)
        {
            using (DataStoreContext _context = new DataStoreContext())
            {
                var employee = _context.Employee.Find(employeeDetails.EmployeeId);
                var department = _context.Department;
                if (ModelState.IsValid)
                {
                    employee.Name = employeeDetails.Name;

                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(employeeDetails);
            }
        }

        public ActionResult Delete(int employeeId)
        {
            if (employeeId != 0)
            {
                using (DataStoreContext _context = new DataStoreContext())
                {
                    Employee employee = _context.Employee.Find(employeeId);

                    _context.Employee.Remove(employee);
                    _context.SaveChanges();

                }
            }
            else
            {
                ViewBag.Title = "There was a problem";
            }
            return RedirectToAction("Index");
        }

    }
    
}