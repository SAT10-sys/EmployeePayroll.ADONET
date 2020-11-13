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
            Regstart:
            Console.WriteLine("Enter Choice Of Operation:-");
            Console.WriteLine("1.GET EMPLOYEES IN THE TABLE\n2.ADD NEW EMPLOYEE(S) TO THE TABLE\n3.UPDATE SALARY OF PRE-EXISTING EMPLOYEE IN THE TABLE\n4.RETRIEVE LIST OF EMPLOYEES STARTED WORKING WITHIN A GIVEN DATE RANGE\n5.GET AGGREGATE SALARY DETAILS OF EMPLOYEES BY GENDER\n6.DELETE DETAILS OF EMPLOYEE FROM THE TABLE");
            int choiceOfOperation = Convert.ToInt32(Console.ReadLine());
            switch(choiceOfOperation)
            {
                case 1:
                    Console.WriteLine("Retrieving list of employees");
                    employeeRepo.GetAllEmployees();
                    break;
                case 2:
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
                    break;
                case 3:
                    Console.WriteLine("Enter employee ID of Employee whose salary is to be updated");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the new salary");
                    decimal salary = Convert.ToDecimal(Console.ReadLine());
                    bool result = employeeRepo.UpdateSalary(id, salary);
                    if(result==false)
                    {
                        Console.WriteLine("Failed to update");
                        break;
                    }
                    Console.WriteLine("Salary updation successfull");
                    break;
                case 4:
                    Console.WriteLine("Enter Starting and Ending Dates in the format dd/mm/yyyy");
                    string startDate = Console.ReadLine();
                    string endDate = Console.ReadLine();
                    Console.WriteLine("Retrieving details of employees joined in the given date range");
                    employeeRepo.GetEmployeesInDateRange(Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));
                    break;
                case 5:
                    Console.WriteLine("Retrieving aggregate salary details by gender");
                    employeeRepo.GetAggregateSalaryDetails();
                    break;
                case 6:
                    Console.WriteLine("Enter the id of the employee whose details are to be removed from the table");
                    int empId = Convert.ToInt32(Console.ReadLine());
                    employeeRepo.RemoveEmployee(empId);
                    break;
                default:
                    Console.WriteLine("Please enter correct choice(between 1 to 6)");
                    goto Regstart;
            }                      
        }
    }
}