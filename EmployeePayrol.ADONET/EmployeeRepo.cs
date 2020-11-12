using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace EmployeePayrol.ADONET
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=.;Initial Catalog=EmployeePayrollService2;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEmployees()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select * from EmployeePayrollTable;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeFirstName = dr.GetString(1);
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
                            Console.WriteLine(employeeModel.EmployeeID + " " + employeeModel.EmployeeFirstName + " " + employeeModel.BasicPay + " " + employeeModel.StartDate + " " + employeeModel.Gender + " " + employeeModel.PhoneNumber + " " + employeeModel.Address + " " + employeeModel.Department + " " + employeeModel.Deductions + " " + employeeModel.TaxablePay + " " + employeeModel.Tax + " " + employeeModel.NetPay);
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
                    cmd.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeFirstName);
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
        public bool UpdateSalary(string name, decimal salary)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("UpdateSalary", this.connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeName", name);
                    cmd.Parameters.AddWithValue("@BasicPay", salary);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                        return true;
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
    }
}
