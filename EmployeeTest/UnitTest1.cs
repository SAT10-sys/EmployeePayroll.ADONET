using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrol.ADONET;
using System;
using System.Collections.Generic;

namespace EmployeeTest
{
    [TestClass]
    public class UnitTest1
    {
        EmployeeRepo employeeRepo = new EmployeeRepo();
        /**
        [TestMethod]
        public void TestMethod1()
        {
            //given name and salary should update salary and return true
            string name = "John";
            decimal salary = 44000;
            bool result = employeeRepo.UpdateSalary(name,salary);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            //test method for checking data added is synced with DB
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.EmployeeFirstName = "Kirk";
            employeeModel.Department = "HR";
            employeeModel.PhoneNumber = "8888888888";
            employeeModel.Address = "Chennai";
            employeeModel.Gender = Convert.ToChar("M");
            employeeModel.StartDate = DateTime.Today;
            employeeModel.BasicPay = Convert.ToDecimal(200000);
            employeeModel.Deductions = 0.2M * employeeModel.BasicPay;
            employeeModel.TaxablePay = employeeModel.BasicPay - employeeModel.Deductions;
            employeeModel.Tax = 0.1M * employeeModel.TaxablePay;
            employeeModel.NetPay = employeeModel.BasicPay - employeeModel.Tax;
            bool result = employeeRepo.AddEmployeeUsingProcedures(employeeModel);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestMethod3()
        {
            //test method to check employee removed            
            bool result=employeeRepo.RemoveEmployee(2);
            Assert.AreEqual(true, result);
        }*/
        [TestMethod]
        public void TestMethod4()
        {
            // when added multiple employees should return true
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            EmployeeModel employee1 = new EmployeeModel();
            EmployeeModel employee2 = new EmployeeModel();
            employee1.EmployeeName = "Sachin";
            employee1.Department = "Sales";
            employee1.PhoneNumber = "3456789012";
            employee1.Address = "Delhi";
            employee1.Gender = Convert.ToChar("M");
            employee1.StartDate = DateTime.Today;
            employee1.BasicPay = Convert.ToDecimal(75000);
            employee1.Deductions = 0.2M * employee1.BasicPay;
            employee1.TaxablePay = employee1.BasicPay - employee1.Deductions;
            employee1.Tax = 0.1M * employee1.TaxablePay;
            employee1.NetPay = employee1.BasicPay - employee1.Tax;
            employeeList.Add(employee1);

            employee2.EmployeeName = "Shreya";
            employee2.Department = "Marketing";
            employee2.PhoneNumber = "9876543210";
            employee2.Address = "Mumbai";
            employee2.Gender = Convert.ToChar("F");
            employee2.StartDate = DateTime.Today;
            employee2.BasicPay = Convert.ToDecimal(80000);
            employee2.Deductions = 0.2M * employee2.BasicPay;
            employee2.TaxablePay = employee2.BasicPay - employee2.Deductions;
            employee2.Tax = 0.1M * employee2.TaxablePay;
            employee2.NetPay = employee2.BasicPay - employee2.Tax;
            employeeList.Add(employee2);
            DateTime startTime = DateTime.Now;
            employeeRepo.AddMultipleEmployees(employeeList);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Duration without thread: "+(endTime-startTime));
        }
    }
}
