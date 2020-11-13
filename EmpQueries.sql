create database EmployeePayrollService2
select * from sys.databases where name='EmployeePayrollService2';
use EmployeePayrollService2
--database created

create table EmployeePayrollTable
(
id int identity(1,1) not null,
name varchar(30) not null,
basicPay money not null,
startDate date not null,
gender char not null,
phoneNumber varchar(15) not null,
department varchar(20) not null,
address varchar(100) not null,
deductions money not null,
taxablePay money not null,
incomeTax money not null,
netPay money not null
)
insert into EmployeePayrollTable values
('Sam',20000, '2018-01-19', 'M', '1111111111','Sales','Mumbai',5000, 15000, 1000, 14000),
('John',30000, '2018-07-26','M','2222222222','Marketing','Kolkata',6000,24000,3000,21000),
('Terissa',40000, '2019-02-08','F','3333333333','HR','Bangalore',10000,30000,5000,25000);
select * from EmployeePayrollTable

select * from EmployeePayrollTable where startDate between '2018-12-31' and GETDATE();

select gender,SUM(basicPay),AVG(basicPay),MAX(basicPay),MIN(basicPay),COUNT(id) from EmployeePayrollTable group by gender;

insert into EmployeePayrollTable values
('Axl',60000,'2020-11-13','M','6666666666','Marketing','London',15000,45000,3000,42000);
select * from EmployeePayrollTable

insert into EmployeePayrollTable values
('James',200000,'2020-11-13','M','7777777777','Sales','Sydney',40000,160000,16000,144000);
select * from EmployeePayrollTable

/**ER DIAGRAM*/
/**CREATING EMPLOYEE TABLE*/
--Employee Table creation
create table Employee
(
EId int identity(1,1) primary key not null,
EName varchar(30) not null,
Gender char not null,
PhoneNumber varchar(15) not null,
Address varchar(100) not null,
StartDate date not null
)
--inserting values in table
insert into Employee values
('Bill','M','9999999999','Mumbai','2018-01-03'),
('Terissa','F','8888888888','Bangalore','2019-05-04'),
('Charlie','M','5555555555','Delhi','2020-02-01');
/*CREATING DEPARTMENT TABLE*/
--Department table creation
create table Department
(
DeptId varchar(5) not null primary key,
DeptName varchar(20) not null
)
--inserting values in table department
insert into Department values
('D01','Marketing'),
('D02','Sales'),
('D03','Finance');

/*CREATING EMPLOYEE-DEPARTMENT TABLE*/
--create Employee-Department table
create table Employee_Department
(
EmpId int foreign key references Employee(EId),
DeptId varchar(5) foreign key references Department(DeptId)
)
--inserting values in Employee-Department table
insert into Employee_Department values
(1,'D01'),
(2,'D01'),
(2,'D02'),
(3,'D03');

/*CREATE EMPPAY TABLE*/
--create table EmpPay
create table EmpPay
(
EId int not null foreign key references Employee(EId),
BasicPay money not null,
Deductions money not null,
TaxablePay money not null,
Tax money not null,
NetPay money not null
)
--inserting values in EmpPay table
insert into EmpPay values
(1,20000,5000,15000,1000,14000),
(2,30000,6000,24000,3000,21000),
(3,40000,10000,30000,5000,25000);

--find aggregate salary details
select Gender,SUM(BasicPay) as SUM,
AVG(BasicPay) as AVG, MIN(BasicPay) as MIN,
MAX(BasicPay) as MAX from Employee INNER JOIN EmpPay 
ON Employee.EId = EmpPay.EId GROUP BY Gender;

select BasicPay from EmpPay INNER JOIN Employee ON EmpPay.EId = Employee.EId where EName = 'Bill';

select Employee.EId ,EName,BasicPay,StartDate,Gender,PhoneNumber,Address,DeptName,Deductions,TaxablePay,Tax,NetPay from Employee 
INNER JOIN Employee_Department ON Employee.EId = Employee_Department.EmpId
INNER JOIN  EmpPay ON Employee.EId = EmpPay.EId
INNER JOIN Department ON Department.DeptId = Employee_Department.DeptId;

