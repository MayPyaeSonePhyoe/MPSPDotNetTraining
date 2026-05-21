
using System;

namespace MPSPDotNetTraining.EFCoreExample.Models
{
    public class TblEmployee
    {
        public int EmployeeId { get; set; }

        public string EmployeeNo { get; set; }

        public string EmployeeName { get; set; }

        public string FatherName { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedBy { get; set; }
    }
}