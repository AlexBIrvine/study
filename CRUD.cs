using System;
using EntityFramework.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    public class CRUD
    {
        public static void CreateEmployee(Employee employee)
        {
            try
            {
                using (var context = new ExampleDBContext())
                {
                    int employeeID = context.Employees.Any() ? context.Employees.Max(e => e.EmployeeID) + 1 : 1;
                    employee.EmployeeID = employeeID;
                    context.Employees.Add(employee);
                    context.SaveChanges();

                    Console.WriteLine($"Successfully saved {employee.Name}");
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static Employee ReadEmployee(int employeeID)
        {
            using (var context = new ExampleDBContext())
            {
                return context.Employees.Include(e => e.Department).Include(e => e.Position).Single(e => e.EmployeeID == employeeID);
            }
        }

        public static List<Employee> ReadEmployees()
        {
            using (var context = new ExampleDBContext())
            {
                return context.Employees.Include(e => e.Department).Include(e => e.Position).ToList();
            }
        }

        public static List<Employee> ReadEmployeesFromDepartment(int departmentID)
        {
            using (var context = new ExampleDBContext())
            {
                return context.Departments.Include(d => d.Employees).ThenInclude(e => e.Position).Single(d => d.DepartmentID == departmentID)?.Employees?.ToList() ?? new List<Employee>();
            }
        }

        public static List<Department> ReadAllDepartmentsWithEmployees()
        {
            using (var context = new ExampleDBContext())
            {
                return context.Departments.Include(d => d.Employees).ThenInclude(e => e.Position).Where(e => e.Employees.Any()).ToList();
            }
        }

        public static void UpdateEmployee(Employee sourceEmployee)
        {
            using (var context = new ExampleDBContext())
            {
                context.Employees.Update(sourceEmployee);
                context.SaveChanges();
            }
        }

        public static void DeleteEmployee(int employeeID)
        {
            using (var context = new ExampleDBContext())
            {
                context.Employees.Remove(ReadEmployee(employeeID));
                context.SaveChanges();
            }
        }

        public static void CreateDepartment(Department department)
        {
            using (var context = new ExampleDBContext())
            {
                int departmentID = context.Departments.Any() ? context.Departments.Max(e => e.DepartmentID) + 1 : 1;
                department.DepartmentID = departmentID;
                context.Departments.Add(department);
                context.SaveChanges();

                Console.WriteLine($"Successfully saved {department.Name}");
            }
        }
    }
}