using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace EmployeePayrol.ADONET
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=.;Initial Catalog=EmployeePayrollService2;Integrated Security=True";
        SqlConnection connection;
        List<EmployeeModel> employeeList = new List<EmployeeModel>();
        public void GetAllEmployees()
        {
            connection = new SqlConnection(connectionString);
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select Employee.EId ,EName,BasicPay,StartDate,Gender,PhoneNumber,Address,DeptName,Deductions,TaxablePay,Tax,NetPay from Employee 
                                     INNER JOIN Employee_Department ON Employee.EId = Employee_Department.EmpId
                                     INNER JOIN  EmpPay ON Employee.EId = EmpPay.EId
                                     INNER JOIN Department ON Department.DeptId = Employee_Department.DeptId;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.BasicPay = dr.GetDecimal(2);
                            employeeModel.StartDate = dr.GetDateTime(3);
                            employeeModel.Gender = Convert.ToChar(dr.GetString(4));
                            employeeModel.PhoneNumber = dr.GetString(5);
                            employeeModel.Address = dr.GetString(7);
                            employeeModel.Department = dr.GetString(6);
                            employeeModel.Deductions = dr.GetDecimal(8);
                            employeeModel.TaxablePay = dr.GetDecimal(9);
                            employeeModel.Tax = dr.GetDecimal(10);
                            employeeModel.NetPay = dr.GetDecimal(11);
                            Console.WriteLine(employeeModel.EmployeeID + " " + employeeModel.EmployeeName + " " + employeeModel.BasicPay + " " + employeeModel.StartDate + " " + employeeModel.Gender + " " + employeeModel.PhoneNumber + " " + employeeModel.Address + " " + employeeModel.Department + " " + employeeModel.Deductions + " " + employeeModel.TaxablePay + " " + employeeModel.Tax + " " + employeeModel.NetPay);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }        
        public bool AddEmployeeUsingProcedures(EmployeeModel employeeModel)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("AddEmployeeDetails", this.connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", employeeModel.EmployeeID);
                    cmd.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", employeeModel.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", employeeModel.Address);
                    cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                    cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@BasicPay", employeeModel.BasicPay);
                    cmd.Parameters.AddWithValue("@Deductions", employeeModel.Deductions);
                    cmd.Parameters.AddWithValue("@TaxablePay", employeeModel.TaxablePay);
                    cmd.Parameters.AddWithValue("@Tax", employeeModel.Tax);
                    cmd.Parameters.AddWithValue("@NetPay", employeeModel.NetPay);
                    cmd.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                        return true;
                    return false;                            
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
        public bool UpdateSalary(int id, decimal salary)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("UpdateSalary", this.connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", id);
                    cmd.Parameters.AddWithValue("@BasicPay", salary);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        foreach (var employee in employeeList)
                        {
                            if (employee.EmployeeID.Equals(id))
                                employee.BasicPay = salary;
                        }
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
        public void GetEmployeesInDateRange(DateTime startDate1, DateTime startDate2)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                SqlCommand cmd = new SqlCommand("GetEmployeesInStartDateRange", this.connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StartDate1", startDate1);
                cmd.Parameters.AddWithValue("@StartDate2", startDate2);
                this.connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        employeeModel.EmployeeID = dr.GetInt32(0);
                        employeeModel.EmployeeName = dr.GetString(1);
                        employeeModel.BasicPay = dr.GetDecimal(2);
                        employeeModel.StartDate = dr.GetDateTime(3);
                        employeeModel.Gender = Convert.ToChar(dr.GetString(4));
                        employeeModel.PhoneNumber = dr.GetString(5);
                        employeeModel.Address = dr.GetString(7);
                        employeeModel.Department = dr.GetString(6);
                        employeeModel.Deductions = dr.GetDecimal(8);
                        employeeModel.TaxablePay = dr.GetDecimal(9);
                        employeeModel.Tax = dr.GetDecimal(10);
                        employeeModel.NetPay = dr.GetDecimal(11);
                        Console.WriteLine(employeeModel.EmployeeID + " " + employeeModel.EmployeeName + " " + employeeModel.BasicPay + " " + employeeModel.StartDate + " " + employeeModel.Gender + " " + employeeModel.PhoneNumber + " " + employeeModel.Address + " " + employeeModel.Department + " " + employeeModel.Deductions + " " + employeeModel.TaxablePay + " " + employeeModel.Tax + " " + employeeModel.NetPay);
                        Console.WriteLine("\n");
                    }
                }
                else
                    Console.WriteLine("No such records found");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public void GetAggregateSalaryDetails()
        {
            connection = new SqlConnection(connectionString);
            try
            {
                string query = @"select Gender,SUM(BasicPay) as SUM,
                                 AVG(BasicPay) as AVG, MIN(BasicPay) as MIN,
                                 MAX(BasicPay) as MAX from Employee INNER JOIN EmpPay 
                                 ON Employee.EId = EmpPay.EId GROUP BY Gender;";
                SqlCommand cmd = new SqlCommand(query, this.connection);
                this.connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    Console.WriteLine("GENDER\tSUM\tAVG\tMAX\tMIN");
                    while(dr.Read())
                    {
                        string gender = dr.GetString(0);
                        decimal sum = dr.GetDecimal(1);
                        decimal avg = dr.GetDecimal(2);
                        decimal max = dr.GetDecimal(3);
                        decimal min = dr.GetDecimal(4);                        
                        Console.WriteLine(gender+"\t"+sum+"\t"+avg+"\t"+max+"\t"+min);
                        Console.WriteLine("\n");
                    }
                }
                else
                    Console.WriteLine("No such records found");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public bool RemoveEmployee(int id)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("RemoveEmployeeData", this.connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", id);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    if(result!=0)
                    {
                        employeeList.RemoveAll(x => x.EmployeeID == id);
                        return true;
                    }
                    return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
        public int AddMultipleEmployees(List<EmployeeModel> employeeList)
        {
            int count = 0;
            employeeList.ForEach(employee =>
            {
                count++;
                Task task = new Task(() =>
                  {
                      AddEmployeeUsingProcedures(employee);
                  }
                );
                task.Start();
                task.Wait();
            }
            );
            return count;
        }
    }
}
