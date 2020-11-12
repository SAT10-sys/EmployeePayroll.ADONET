using System;

namespace EmployeePayrol.ADONET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Program using .ADONET");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.GetAllEmployees();
        }
    }
}
