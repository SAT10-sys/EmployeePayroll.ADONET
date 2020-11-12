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
            /**Console.WriteLine("Enter the following details seperated by comma");
            Console.WriteLine("Enter Name ,Department, Phone no, Address, Gender, BasicPay, Deduction, Taxable Pay, Tax, NetPay");
            string[] details = Console.ReadLine().Split(",");
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.EmployeeFirstName = details[0];
            employeeModel.Department = details[1];
            employeeModel.PhoneNumber = details[2];
            employeeModel.Address = details[3];
            employeeModel.Gender = Convert.ToChar(details[4]);
            employeeModel.StartDate = DateTime.Today;
            employeeModel.BasicPay = Convert.ToDecimal(details[5]);
            employeeModel.Deductions= Convert.ToDecimal(details[6]);
            employeeModel.TaxablePay= Convert.ToDecimal(details[7]);
            employeeModel.Tax= Convert.ToDecimal(details[8]);
            employeeModel.NetPay= Convert.ToDecimal(details[5]);
            employeeRepo.AddEmployeeUsingProcedures(employeeModel);
            Console.WriteLine("Records added");
            Console.WriteLine("Enter Employee name whose salary is to be updated");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new salary");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            employeeRepo.UpdateSalary(name, salary);
            Console.WriteLine("Salary Updated");
            Console.WriteLine("Enter dates seperated by comma");
            string[] dates = Console.ReadLine().Split(",");
            employeeRepo.GetEmployeesInDateRange(Convert.ToDateTime(dates[0]), Convert.ToDateTime(dates[1]));*/
            employeeRepo.GetAggregateSalaryDetails();
        }
    }
}
