# SQL Hackerrank challenges

## Weather Observation Station 4
- Duncan's
    ```sql
    select (
    (select count(city) from station) -
    (select count(distinct city) from station)
    ) as difference;
    ```

- Alejandro's
    ```sql
    select (count(City) - count(distinct City)) from station
    ```

## Weather Observation Station 6
- Jacob's
```sql 
SELECT DISTINCT CITY FROM STATION WHERE CITY LIKE '[aeiou]%';
```

## [SQL RegEx Cheatsheet](https://learn.microsoft.com/en-us/sql/ssms/scripting/search-text-with-regular-expressions?view=sql-server-ver16)

## Top Earners
- Jacob's
```sql
SELECT TOP 1 earnings, COUNT(earnings) FROM (SELECT months * salary AS earnings FROM Employee) t GROUP BY earnings ORDER BY earnings DESC;

```
- Ilgaz's
    ```sql
    SELECT TOP 1(MONTHS*SALARY), count(employee_id) FROM EMPLOYEE GROUP BY months*salary ORDER BY months*salary desc ;
    ```

- SubQueries
    -Haizhen's
    ```sql
    select max(salary * months), count(*) from Employee where (salary * months) = (select max(salary * months) from Employee);
    ```


- Variables

    -Gregory's, Denis's
    ```sql
    declare @maxearnings int;
    set @maxearnings = (select max(salary*months) from employee);
    select @maxearnings, count(*)
    from employee
    where salary*months=@maxearnings;
    ------ 
    DECLARE @MTE INT;
    SET @MTE = (SELECT Max(Salary * Months) FROM Employee);
    SELECT @MTE, COUNT(Name) FROM Employee WHERE (months * salary) = @MTE;
    ```