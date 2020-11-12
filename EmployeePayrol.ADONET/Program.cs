using System;

namespace EmployeePayrol.ADONET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Program using .ADONET");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            //employeeRepo.GetAllEmployees();
            //employeeRepo.UpdateSalary();
            //Console.WriteLine("Salary updated successfully");
            Console.WriteLine("Enter the following details seperated by comma");
            Console.WriteLine("Enter Name ,Department, Phone no, Address, Gender, BasicPay");
            string[] details = Console.ReadLine().Split(",");
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.EmployeeFirstName = details[0];
            employeeModel.Department = details[1];
            employeeModel.PhoneNumber = details[2];
            employeeModel.Address = details[3];
            employeeModel.Gender = Convert.ToChar(details[4]);
            employeeModel.StartDate = DateTime.Today;
            employeeModel.BasicPay = Convert.ToDecimal(details[5]);
            employeeModel.Deductions = 0.2M * employeeModel.BasicPay;
            employeeModel.TaxablePay = employeeModel.BasicPay - employeeModel.Deductions;
            employeeModel.Tax = 0.1M * employeeModel.TaxablePay;
            employeeModel.NetPay = employeeModel.BasicPay - employeeModel.Tax;
            employeeRepo.AddEmployeeUsingProcedures(employeeModel);
            Console.WriteLine("Records added");
            /**Console.WriteLine("Enter Employee name whose salary is to be updated");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new salary");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            employeeRepo.UpdateSalary(name, salary);
            Console.WriteLine("Salary Updated");
            Console.WriteLine("Enter dates seperated by comma");
            string[] dates = Console.ReadLine().Split(",");
            employeeRepo.GetEmployeesInDateRange(Convert.ToDateTime(dates[0]), Convert.ToDateTime(dates[1]));*/
            //employeeRepo.GetAggregateSalaryDetails();
        }
    }
}
