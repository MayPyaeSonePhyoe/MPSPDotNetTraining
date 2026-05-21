
using System;

namespace MPSPDotNetTraining.AdoDotNetSample
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeNo { get; set; } = null!;

        public string EmployeeName { get; set; } = null!;

        public string FatherName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedBy { get; set; } = null!;
    }
}