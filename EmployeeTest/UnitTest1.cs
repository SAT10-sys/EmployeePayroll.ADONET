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
            employeeModel.EmployeeFirstName = "Axl";
            employeeModel.Department = "Marketing";
            employeeModel.PhoneNumber = "6666666666";
            employeeModel.Address = "London";
            employeeModel.Gender = Convert.ToChar("M");
            employeeModel.StartDate = DateTime.Today;
            employeeModel.BasicPay = Convert.ToDecimal(60000);
            employeeModel.Deductions= Convert.ToDecimal(15000);
            employeeModel.TaxablePay= Convert.ToDecimal(45000);
            employeeModel.Tax= Convert.ToDecimal(3000);
            employeeModel.NetPay= Convert.ToDecimal(42000);
            bool result = employeeRepo.AddEmployeeUsingProcedures(employeeModel);
            Assert.AreEqual(true, result);
        }
    }
}
