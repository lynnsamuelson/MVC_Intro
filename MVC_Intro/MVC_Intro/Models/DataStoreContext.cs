using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Intro.Models
{
    public class DataStoreContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // this incorporates the tables you need
            //can configure more than this but could do everything you want in LINQ
            modelBuilder.Entity<Employee>()
                .ToTable("Employee")
                .HasKey(c => c.EmployeeId);

            modelBuilder.Entity<Department>()
                .ToTable("Department")
                .HasKey(c => c.DepartmentId);
        }
       }
    }