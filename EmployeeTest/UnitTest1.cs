using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrol.ADONET;

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
            bool result = employeeRepo.UpdateSalary();
            Assert.AreEqual(true, result);
        }
    }
}
