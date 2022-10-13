
select * from employee

-- creating procedure
-- create procedure sp_getemployee
-- alter
alter procedure sp_getemployee
with encryption   -- encrypting procedure statements
AS 
BEGIN
select firstname,salary
from employee
end

-- execute the procedure
exec sp_getemployee

-- description of the procedure
sp_helptext sp_getemployee


-- deleting the procedure
drop procedure sp_getemployee

-- insert the values

create procedure sp_insertemployee
(@empid int ,
@fname varchar(20),
@lname varchar(20),
@email varchar(20),
@phoneno varchar(20),
@hdate date,
@salary money)
AS
BEGIN
insert into employee
(employeeid,firstname,lastname,email,phoneno,hiredate,salary)
VALUES
(@empid,@fname,@lname,@email,@phoneno,@hdate,@salary)
end


exec sp_insertemployee
@empid=201,
@fname='sara',
@lname='connor',
@email='sara@gmail.com',
@phoneno='123456',
@hdate='13-oct-2022',
@salary=45000

select * from employee

-- if - else in stored procedure

select * from product
select * from productdescription


create procedure sp_insertproduct
(@pid int,
@pname varchar(20),
@qty int,
@price float)
AS
BEGIN
declare @cnt INT
declare @p float

select @cnt=count(productid) from product where productname=@pname
if (@cnt>0)
BEGIN
update product set productqty=productqty+@qty where productname=@pname
select @p=productprice from product where productname=@pname
if(@p<@price)
BEGIN
update product set productprice=@price where productname=@pname
END
end

ELSE

BEGIN
insert product values(@pid,@pname,@qty,@price)
END
end

exec sp_insertproduct @pid=2,@pname='scanner',@qty=10,@price=12000.34

select * from product

exec sp_insertproduct @pid=5,@pname='laptop',@qty=20,@price=12345

-- case statements in stored procedure

create procedure sp_casestatements
AS
BEGIN

select case product.productname 
when 'printer' then 'printer(100)'
when 'scanner' then 'scanner(30)'
else 'unknown' 
end as "your contribution counts"
from product
end

exec sp_casestatements

-- joins in procedure

alter procedure sp_joinproduct
(@pid int = 1)
AS
BEGIN
select p.productid,p.productname,pd.productdescription from 
product p
INNER JOIN
productdescription pd
on p.productid=pd.productid
where p.productid=@pid
END

exec sp_joinproduct 

-- procedure with scalar variables

ALTER procedure sp_divide(
    @a int,
    @b int,
    @c int output
)
AS
BEGIN
begin try
set @c=@a/@b;
end try
begin catch
select ERROR_LINE() as ERRORNUMBER,ERROR_MESSAGE() as ERRORMESSAGE
END CATCH
end

declare @result int
exec sp_divide 10,0,@result output
print @result










