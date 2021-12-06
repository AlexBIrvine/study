using System;
using EntityFramework.Data;



namespace EntityFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CRUD.CreateEmployee(new Employee()
            // {
            //     Name = "Alex Irvine",
            //     HireDate = DateTime.Now,
            //     DepartmentID = Departments.BOSSES,
            //     PositionID = Positions.BOSS
            // });

            // CRUD.CreateDepartment(new Department()
            // {
            //     Name = "Others"
            // });

            foreach (var department in CRUD.ReadAllDepartmentsWithEmployees())
            {
                Console.WriteLine($"Department {department.Name}");

                foreach (var employee in department.Employees)
                {
                    Console.WriteLine($"\t{employee.Name} works in {employee.Department.Name} and has position of {employee.Position.Name}!");
                }
            }
        }
    }
}