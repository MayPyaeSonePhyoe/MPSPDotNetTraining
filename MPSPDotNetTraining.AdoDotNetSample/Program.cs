using System;
using MPSPDotNetTraining.AdoDotNetSample;

namespace MPSPDotNetTraining.AdoDotNetSample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AdoDotNetService adoService = new AdoDotNetService();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== Employee Management System ===");

                Console.WriteLine("1. Read");
                Console.WriteLine("2. Create");
                Console.WriteLine("3. Edit");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Delete");
                Console.WriteLine("6. Exit");

                Console.Write("Choose option: ");

                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Please enter a valid numeric option.");
                    continue;
                }

                switch (option)
                {
                    // Read
                    case 1:
                        Console.WriteLine("\n--- Reading Employee Data ---");
                        adoService.Read();
                        break;

                    // Create
                    case 2:
                        Console.WriteLine("\n--- Adding New Employee ---");

                        Employee newEmployee = new Employee();

                        Console.Write("Enter Employee No: ");
                        newEmployee.EmployeeNo = Console.ReadLine();

                        Console.Write("Enter Employee Name: ");
                        newEmployee.EmployeeName = Console.ReadLine();

                        Console.Write("Enter Father Name: ");
                        newEmployee.FatherName = Console.ReadLine();

                        Console.Write("Enter Address: ");
                        newEmployee.Address = Console.ReadLine();

                        Console.Write("Enter Date of Birth (yyyy-MM-dd): ");

                        if (DateTime.TryParse(Console.ReadLine(), out DateTime dob))
                        {
                            newEmployee.DateOfBirth = dob;
                        }
                        else
                        {
                            newEmployee.DateOfBirth = DateTime.Now;
                            Console.WriteLine("Invalid date format.");
                        }

                        adoService.Create(newEmployee);
                        break;

                    // Edit
                    case 3:
                        Console.Write("Enter Employee ID: ");

                        if (int.TryParse(Console.ReadLine(), out int editId))
                        {
                            Employee employee = adoService.Edit(editId);

                            if (employee != null)
                            {
                                Console.WriteLine($"ID : {employee.EmployeeId}");
                                Console.WriteLine($"No : {employee.EmployeeNo}");
                                Console.WriteLine($"Name : {employee.EmployeeName}");
                                Console.WriteLine($"Father : {employee.FatherName}");
                                Console.WriteLine($"Address : {employee.Address}");
                                Console.WriteLine($"DOB : {employee.DateOfBirth:dd MMM yyyy}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }

                        break;

                    // Update
                    case 4:

                        Console.Write("Enter Employee ID to update: ");

                        if (!int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Console.WriteLine("Invalid ID.");
                            break;
                        }

                        Employee targetEmployee = adoService.Edit(updateId);

                        if (targetEmployee == null)
                            break;

                        Console.Write($"Employee No [{targetEmployee.EmployeeNo}] : ");
                        string no = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(no))
                            targetEmployee.EmployeeNo = no;

                        Console.Write($"Employee Name [{targetEmployee.EmployeeName}] : ");
                        string name = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(name))
                            targetEmployee.EmployeeName = name;

                        Console.Write($"Father Name [{targetEmployee.FatherName}] : ");
                        string father = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(father))
                            targetEmployee.FatherName = father;

                        Console.Write($"Address [{targetEmployee.Address}] : ");
                        string address = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(address))
                            targetEmployee.Address = address;

                        Console.Write($"DOB [{targetEmployee.DateOfBirth:yyyy-MM-dd}] : ");
                        string dobInput = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(dobInput)
                            && DateTime.TryParse(dobInput, out DateTime newDob))
                        {
                            targetEmployee.DateOfBirth = newDob;
                        }

                        adoService.Update(targetEmployee);

                        break;

                    // Delete
                    case 5:

                        Console.Write("Enter Employee ID to delete: ");

                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            adoService.Delete(deleteId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }

                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}