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

