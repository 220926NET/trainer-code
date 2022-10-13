

select * from employee

-- creating scalar function

create function avgsalary()
returns INT
as
BEGIN
declare @avg int
select @avg=avg(salary) from employee
return @avg
end

-- function call

select dbo.avgsalary() as AVERAGE


-- using functions inside the procedure
CREATE PROCEDURE sp_salarycalc
as
BEGIN
select dbo.avgsalary()
end

exec sp_salarycalc

-- table valued function(single statement)

alter function getemplist(@sal money)
returns TABLE
as
RETURN
select firstname,email,salary from employee where salary>@sal

-- table valued function(multiple statement)

alter function getsenioremp()
returns @sremp table
(empid int,
fname varchar(20),
salary money)
as
BEGIN
insert into @sremp select employeeid,firstname,salary from employee;
delete from @sremp where empid <= 105
return
end






-- function call

select * from getemplist(19000)

select * from getsenioremp()
