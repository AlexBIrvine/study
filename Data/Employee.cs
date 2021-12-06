using System;
using System.Collections.Generic;

namespace EntityFramework.Data
{
    public partial class Employee
    {
        public int EmployeeID { get; set; }
        public int DepartmentID { get; set; }
        public string Name { get; set; } = null!;
        public DateTime HireDate { get; set; }
        public int PositionID { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Position Position { get; set; } = null!;
    }
}
