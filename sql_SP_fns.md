

Agenda :

- Stored procedures
- Function


Stored procedure :

- set of t-sql statements that are executed and stored as objects (procedure) in your database

Advantages :

- more flexible
- Reduces on the application

syntax :

CREATE PROCEDURE <PROcedurename>
as
begin
//sql statements here
end



exec procedurename

- pass input parameters
- return values as out parameter

references :

sqlcommand cmd=new sqlcommand("sp_insertprodcuct",con)
cmd.parameters.addwithvalue("@pname",p.pname)

Functions :

- set of task 
- create a function for complex logic and make a call back

Types

- scalar function - value 
- Table valued function - return a result set
- returns value / table

create function <functionname>(parameters)
returns <value>/<table>
as
begin
//set of function tasks
end

select * from functionname(value)

stored procedures vs functions :
- exec , select
- call a fn from sp , cannot call sp from fn
- accept input and return output parameter , return value / result set
- can manage transactions in stored procedure , cannot manage transaction











