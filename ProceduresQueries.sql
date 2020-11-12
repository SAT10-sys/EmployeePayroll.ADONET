use EmployeePayrollService2
go
create procedure AddEmployeeDetails
(
@EmployeeName varchar(30),
@PhoneNumber varchar(15),
@Address varchar(100),
@Department varchar(20),
@Gender char,
@BasicPay float,
@Deductions float,
@TaxablePay float,
@Tax float,
@NetPay float,
@StartDate date
)
as 
begin
insert into EmployeePayrollTable values
(
@EmployeeName, @BasicPay, @StartDate, @Gender, @PhoneNumber, @Address, @Department, @Deductions, @TaxablePay, @Tax, @NetPay
)
end

go
create procedure UpdateSalary
(
@EmployeeName varchar(30),
@BasicPay money
)
as 
begin
update EmployeePayrollTable set basicPay=@BasicPay where name=@EmployeeName;
end
