use EmployeePayrollService2
go
create or alter procedure AddEmployeeDetails
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
@StartDate date,
@EmpId int out
)
as 
begin
set XACT_ABORT on;
begin try;
begin transaction;
insert into Employee values
(
@EmployeeName,@Gender,@PhoneNumber,@Address,@StartDate
)
set @EmpId=SCOPE_IDENTITY()
insert into EmpPay values
(
@EmpId,@BasicPay,@Deductions,@TaxablePay,@Tax,@NetPay
)
insert into Employee_Department values
(
@EmpId , (select DeptId from Department where DeptName = @Department)
)
COMMIT TRANSACTION;
END TRY
BEGIN CATCH
select ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
IF(XACT_STATE()=-1)
BEGIN
PRINT N'The transaction is in an uncommitable state.'+'Rolling back transaction.'
ROLLBACK TRANSACTION;
END;

IF(XACT_STATE()=1)
BEGIN
PRINT N'The transaction is commitable.'+'Committing transaction.'
COMMIT TRANSACTION;
END;
END CATCH
END

--update salary
go
create or alter procedure UpdateSalary
(
@EmpId int,
@BasicPay money
)
as 
begin
update EmpPay
set BasicPay=@BasicPay from EmpPay inner join Employee on EmpPay.EId=Employee.EId where EmpPay.EId=@EmpId
end

--get employees in start date range
go
create or Alter procedure GetEmployeesInStartDateRange
(
@StartDate1 date,
@StartDate2 date
)
as
begin
select id, name, basicPay, startDate, gender, phoneNumber, address, department, deductions, taxablePay, incomeTax, netPay from EmployeePayrollTable where startDate between @StartDate1 and @StartDate2;
end



--remove employee
go
create or alter procedure RemoveEmployeeData
(
@EmpId int
)
as 
begin
set XACT_ABORT on;
begin try
begin transaction;

Delete from EmpPay where EId=@EmpId;
Delete from Employee_Department where EmpId=@EmpId;
Delete from Employee where EId=@EmpId;

commit transaction;
end try
begin catch
select ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
IF(XACT_STATE())=-1
BEGIN
  PRINT N'The transaction is in an uncommitable state.'+'Rolling back transaction.'
  ROLLBACK TRANSACTION;
  END;
  IF(XACT_STATE())=1
  BEGIN
    PRINT 
	    N'The transaction is committable. '+'Committing transaction.'
       COMMIT TRANSACTION;
	END;
	END CATCH
END