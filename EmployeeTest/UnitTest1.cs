using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrol.ADONET;
using System;

namespace EmployeeTest
{
    [TestClass]
    public class UnitTest1
    {
        EmployeeRepo employeeRepo = new EmployeeRepo();
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
        }
    }
}
