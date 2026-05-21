using System;
using MPSPDotNetTraining.EFCoreExample.DataAccess;
using MPSPDotNetTraining.EFCoreExample.Models;

namespace MPSPDotNetTraining.EFCoreExample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            EfCoreService efcoreservice = new EfCoreService();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== Employee Management System (EF Core) ===");

                Console.WriteLine("1. Read");
                Console.WriteLine("2. Create");
                Console.WriteLine("3. Edit");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Delete");
                Console.WriteLine("6. Exit");

                Console.Write("Choose option: ");

                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Please enter valid number.");
                    continue;
                }

                switch (option)
                {
                    // Read
                    case 1:
                        efcoreservice.Read();
                        break;

                    // Create
                    case 2:
                        TblEmployee employee = new TblEmployee();

                        Console.Write("Enter Employee No: ");
                        employee.EmployeeNo = Console.ReadLine();

                        Console.Write("Enter Employee Name: ");
                        employee.EmployeeName = Console.ReadLine();

                        Console.Write("Enter Father Name: ");
                        employee.FatherName = Console.ReadLine();

                        Console.Write("Enter Address: ");
                        employee.Address = Console.ReadLine();

                        Console.Write("Enter DOB (yyyy-MM-dd): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime dob))
                        {
                            employee.DateOfBirth = dob;
                        }

                        efcoreservice.Create(employee);
                        break;

                    // Edit
                    case 3:
                        Console.Write("Enter Employee ID: ");

                        if (int.TryParse(Console.ReadLine(), out int editId))
                        {
                            TblEmployee editEmployee = efcoreservice.Edit(editId);

                            if (editEmployee != null)
                            {
                                Console.WriteLine($"ID : {editEmployee.EmployeeId}");
                                Console.WriteLine($"No : {editEmployee.EmployeeNo}");
                                Console.WriteLine($"Name : {editEmployee.EmployeeName}");
                                Console.WriteLine($"Father : {editEmployee.FatherName}");
                                Console.WriteLine($"Address : {editEmployee.Address}");
                            }
                        }
                        break;

                    // Update
                    case 4:
                        Console.Write("Enter Employee ID: ");

                        if (!int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Console.WriteLine("Invalid ID");
                            break;
                        }

                        TblEmployee updateEmployee = efcoreservice.Edit(updateId);

                        if (updateEmployee == null)
                            break;

                        Console.Write($"Employee No [{updateEmployee.EmployeeNo}] : ");
                        string no = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(no))
                            updateEmployee.EmployeeNo = no;

                        Console.Write($"Employee Name [{updateEmployee.EmployeeName}] : ");
                        string name = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(name))
                            updateEmployee.EmployeeName = name;

                        Console.Write($"Father Name [{updateEmployee.FatherName}] : ");
                        string father = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(father))
                            updateEmployee.FatherName = father;

                        Console.Write($"Address [{updateEmployee.Address}] : ");
                        string address = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(address))
                            updateEmployee.Address = address;

                        efcoreservice.Update(updateEmployee);
                        break;

                    // Delete
                    case 5:
                        Console.Write("Enter Employee ID: ");

                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            efcoreservice.Delete(deleteId);
                        }
                        break;

                    case 6:
                        return;
                }
            }
        }
    }
}