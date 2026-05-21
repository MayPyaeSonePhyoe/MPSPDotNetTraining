using MPSPDotNetTraining.EFCoreExample.DataAccess;
using MPSPDotNetTraining.EFCoreExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MPSPDotNetTraining.EFCoreExample.DataAccess
{
    public class EfCoreService
    {
        private readonly AppDbContext _db = new AppDbContext();

        // Read
        public void Read()
        {
            List<TblEmployee> employees = _db.TblEmployees
                .Where(x => x.IsDelete == false)
                .ToList();

            foreach (TblEmployee employee in employees)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"ID : {employee.EmployeeId}");
                Console.WriteLine($"No : {employee.EmployeeNo}");
                Console.WriteLine($"Name : {employee.EmployeeName}");
                Console.WriteLine($"Father : {employee.FatherName}");
                Console.WriteLine($"Address : {employee.Address}");
            }
        }

        // Edit
        public TblEmployee Edit(int id)
        {
            TblEmployee employee = _db.TblEmployees
                .FirstOrDefault(x => x.EmployeeId == id && x.IsDelete == false);

            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
            }

            return employee;
        }

        // Create
        public void Create(TblEmployee employee)
        {
            employee.CreatedDateTime = DateTime.Now;
            employee.CreatedBy = "admin";
            employee.IsDelete = false;

            _db.TblEmployees.Add(employee);

            int result = _db.SaveChanges();

            Console.WriteLine(result > 0
                ? "Create successful."
                : "Create failed.");
        }

        // Update
        public void Update(TblEmployee employee)
        {
            _db.TblEmployees.Update(employee);

            int result = _db.SaveChanges();

            Console.WriteLine(result > 0
                ? "Update successful."
                : "Update failed.");
        }

        // Delete
        public void Delete(int id)
        {
            TblEmployee employee = _db.TblEmployees
                .FirstOrDefault(x => x.EmployeeId == id);

            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            employee.IsDelete = true;

            int result = _db.SaveChanges();

            Console.WriteLine(result > 0
                ? "Delete successful."
                : "Delete failed.");
        }
    }
}