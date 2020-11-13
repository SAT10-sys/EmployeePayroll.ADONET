using System;
using System.Collections.Generic;

namespace EmployeePayrol.ADONET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Program using .ADONET");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            EmployeeModel employeeModel = new EmployeeModel();
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            //employeeRepo.GetAllEmployees();
            //employeeRepo.UpdateSalary();
            //Console.WriteLine("Salary updated successfully");
            /**Console.WriteLine("Enter the following details seperated by comma");
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
            Console.WriteLine("Enter Employee name whose salary is to be updated");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new salary");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            employeeRepo.UpdateSalary(name, salary);
            Console.WriteLine("Salary Updated");
            Console.WriteLine("Enter dates seperated by comma");
            string[] dates = Console.ReadLine().Split(",");
            employeeRepo.GetEmployeesInDateRange(Convert.ToDateTime(dates[0]), Convert.ToDateTime(dates[1]));
            employeeRepo.GetAggregateSalaryDetails();
            employeeRepo.GetAllEmployees();
            Console.WriteLine("Enter id of the employee whose details you want to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            employeeRepo.RemoveEmployee(id);
            Console.WriteLine("Employee removed");
            employeeRepo.GetAllEmployees();*/
            while (true)
            {
                Console.WriteLine("Enter the following data for the employee");
                Console.WriteLine("NAME\nADDRESS\nPHONE NUMBER\nGENDER\nDEPARTMENT\nSTART DATE\nBASIC PAY\n");
                employeeModel.EmployeeName = Console.ReadLine();
                employeeModel.Address = Console.ReadLine();
                employeeModel.PhoneNumber = Console.ReadLine();
                employeeModel.Gender = Convert.ToChar(Console.ReadLine());
                employeeModel.Department = Console.ReadLine();
                employeeModel.StartDate = Convert.ToDateTime(Console.ReadLine());
                employeeModel.BasicPay = Convert.ToDecimal(Console.ReadLine());
                employeeModel.Deductions = 0.2M * employeeModel.BasicPay;
                employeeModel.TaxablePay = employeeModel.BasicPay - employeeModel.Deductions;
                employeeModel.Tax = 0.1M * employeeModel.TaxablePay;
                employeeModel.NetPay = employeeModel.BasicPay - employeeModel.Tax;
                employeeList.Add(employeeModel);            
                Console.WriteLine("Do you want to add more employees:- Yes/No");
                string choice = Console.ReadLine();
                if (choice.ToUpper() == "NO")                          
                    break;                
            }
            employeeRepo.AddMultipleEmployees(employeeList);
            Console.WriteLine("Employees added successfully");
            //employeeRepo.GetAllEmployees();
        }
    }
}