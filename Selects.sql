-- SELECT Statement --
-- SELECT comma separated column names FROM table name (optional) WHERE conditions (ex. Id = 3)

-- SELECT column names
-- FROM table names
-- Optional Clauses: 
-- WHERE conditions (filter rows before Group By)
-- GROUP BY column name 
-- HAVING conditions (filter rows that are contained in Group By or Aggregate Fns)
-- ORDER BY column name ASC, DESC

-- Aggregate Functions
    -- SUM, AVG, COUNT, MIN, MAX
-- Scalar Functions
    -- any sql function that produce one value
    -- aggregate functions are scalar fns
    -- UPPER, LOWER are scalar functions but not aggregate functions

-- SQL is a declarative language : We say Which result we want instead of how we want to get the result
-- C# is imperative language : we have to say how to get the result
    -- LINQ is declarative

-- how many pokemons does gregory have?
select top 2 Count(Level) AS Pokemon_Count FROM pokemons HAVING Count(level) > 0;

SELECT Max(Level) as max_level from Pokemons;
SELECT distinct top 5 level from Pokemons order by level desc;
Select * from Pokemons;

SELECT * FROM Pokemon;
SELECT * FROM PokemonTrainer;
SELECT * FROM PokemonTypes;
SELECT * FROM TrainerPokemons;
SELECT * FROM Types;

INSERT INTO Pokemon (Id, Name) VALUES (25, 'Pikachu')

-- JOINS "denormalizes" table by joining two tables on a common column 
-- you can continue chaining these tables to join multiple tables
-- (INNER) JOIN : only displays rows that exists on both tables
-- LEFT/RIGHT JOIN : displays all rows that exist LEFT/RIGHT table, respectively, regradless of if RIGHT/LEFT tables have data in there or not
-- FULL OUTER JOIN : display all rows from both tables
-- In short, JOINS combine columns in tables together, and is in ONE select statement

SELECT Pokemon.Name, PokemonTypes.Type, Types.Name FROM Pokemon 
RIGHT JOIN PokemonTypes ON Pokemon.Id = PokemonTypes.PokeDexId
FULL OUTER JOIN Types ON PokemonTypes.[Type] = [Types].Name;

-- JOIN TrainerPokemons ON Pokemon.Id = TrainerPokemons.PokemonId 
-- JOIN PokemonTrainer ON TrainerPokemons.TrainerId = PokemonTrainer.Id;

-- Set Operations
-- combines two more more SELECT statements
-- SET Op example: 
-- SELECT * FROM DEC_SALES
-- UNION (only gives you distinct values), UNION ALL (gives you everything, including duplicates), INTERSECT(only common rows in both select statements), EXCEPT (gives you everything on first select that is not in second select)
-- SELECT * FROM NOV_SALES

-- SubQueries
-- A way to nest queries inside another query to further specify 
-- your query without having to memorize bunch of id's

SELECT * FROM Pokemon JOIN TrainerPokemons on Pokemon.Id = TrainerPokemons.PokemonId 
JOIN PokemonTrainer ON TrainerPokemons.TrainerId = PokemonTrainer.Id
WHERE PokemonTrainer.Name = 'Gregory';

SELECT * FROM Pokemon 
WHERE Pokemon.Id = 
(SELECT TrainerPokemons.PokemonId from TrainerPokemons 
JOIN PokemonTrainer ON TrainerPokemons.TrainerId = PokemonTrainer.Id WHERE PokemonTrainer.Name = 'Gregory')

-- Sublanguages of SQL
-- DDL : Data Definition Language
    -- any commands you create tables with
    -- CREATE, ALTER, DROP, TRUNCATE
-- DML : Data Manipulation Language
    -- anything that deals with rows in a table
    -- INSERT, UPDATE, DELETE, and sometimes SELECT also get looped into here
-- DQL : Data Query Language
    -- SELECT (contains joins, subqueries, set ops, etc...)
    -- Query the data
-- (DCL) : Data Control Langauge (access control of data)
-- (TCL) : Transaction Control Language (creating transactions)

-- SQL Dialects
-- MySQL, MSSql (Microsoft SQL Server), Oracle SQL, Postgre SQL 