-- to create tables
CREATE TABLE Pokemons(
    Id INT,
    Name NVARCHAR(100),
    Nickname NVARCHAR(100),
    Level INT,
    TrainerName NVARCHAR(100),
    TrainerBadgeNumber INT,
    BodyShape INT,
    Moves NVARCHAR(MAX),
    Types NVARCHAR(MAX),
    Color NVARCHAR(50),
    TrainerMoney Money
);

-- To delete tables
DROP TABLE Pokemons;

-- Modify/Edit tables
--add specific actions such as adding, removing, and modifying columns
ALTER TABLE Pokemons 
ADD TrainerId int;

-- Get rid of all records but leave the table structure (columns, etc.)
TRUNCATE TABLE Pokemons;

-- To add a row to a table
INSERT INTO 
Pokemons (Id, Name, TrainerName, Types, Color, Level) 
VALUES 
(2, 'IvySaur', 'gregory', 'Poison', 'Blue', 25);

-- To Retrieve Values from a table
SELECT Id, Name, Nickname, Level, TrainerName, TrainerBadgeNumber, Types, Color FROM Pokemons;

-- Normalization
-- Is a design guideline to reduce data inconsistency and redunduncy.
-- 1st Normal Form
-- Unique Key, Atomic Values
    -- Any combination of columns that can uniquely id a row is called a key
    -- Candidate Key: 1 or more columns that "could be a key"
    -- Composite Key: A key that is composed of more than 1 columns
    -- Primary Key: A key that uniquely id's that table
    -- Foreign Key: A primary key that belongs to a different record
    -- Atomic Values mean you can only have 1 value per column

-- 2nd Normal Form
    -- Everything in 1st normal form
    -- No Partial Dependency
        -- You can't have a non-key column that depends on only the part of a key
        -- Easiest way to avoid this... is not to have a composite key

-- 3rd Normal Form
    -- Everything in 2nd normal form
    -- No Transitive Dependency between non-key columns
        -- if a = b and b = c then a = c -> we want to avoid this

-- Trainer, Pokemons (Types, Colors)

-- Relationships
-- 1-1 relationship
    -- (monogamous relationship, Id to Pokemon, Pokemon to Pokeball)
    -- If the data is related, you can most likely store the data as a column directly in the table
    -- Foreign Key reference that is not null, and unique
-- 1-M relationship
    -- Pokemon Trainer and Pokemon, Mother to Children, Sun to planets
    -- Foreign Key reference that is not unique, not null in Many table
-- M-M relationship
    -- Pokemon and Types
    -- Teachers and Students
    -- Friendships
    -- Represent these relationship by using join tables


--Many to Many Relationship
-- shared info between same pokemons
Create Table Pokemon (
    Name NVARCHAR(100) not null,
    Id int primary key
);

Create Table PokemonTrainer (
    Id int PRIMARY KEY Identity,
    Name NVARCHAR(100) not null,
    BadgeNumber int
);

Create Table TrainerPokemons (
    Id int PRIMARY KEY IDENTITY,
    Level int default 1,
    PokemonId int FOREIGN KEY REFERENCES Pokemon(Id),
    TrainerId int FOREIGN KEY REFERENCES PokemonTrainer(Id)
);

INSERT INTO Pokemon VALUES ('IvySaur', 2);
INSERT INTO PokemonTrainer VALUES ('Gregory', 3);
INSERT INTO TrainerPokemons VALUES (10, 2, 1);

SELECT * FROM TrainerPokemons;
SELECT * FROM PokemonTrainer;
SELECT * FROM Pokemon;

-- One to Many Relationship
CREATE TABLE Address (
    Id int IDENTITY PRIMARY KEY,
    -- Street to Address would be considered 1-1 relationship
    Street NVARCHAR(200),
    City NVARCHAR(100),
    StateProvince NVARCHAR(50),
    Country NVARCHAR(50),
);

CREATE TABLE Person (
    Id int IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    PrimaryResidence int FOREIGN KEY REFERENCES Address(Id)
);

-- Pokemon to Colors
-- M-M

-- Pokemon to Moves
-- M-M

-- Pokemon to Types
-- M-M
-- Join Table
Create Table Types (
    Name NVARCHAR(100) PRIMARY KEY,
    StrongAgainst NVARCHAR(100) FOREIGN KEY REFERENCES Types(Name),
    WeakAgainst NVARCHAR(100) FOREIGN KEY REFERENCES Types(Name)
)

Create Table PokemonTypes (
    Type NVARCHAR(100) FOREIGN Key References Types(Name),
    PokeDexId int FOREIGN Key REFERENCES Pokemon(Id)
);

--CRUD commands 

-- Create new rows in a table
INSERT INTO Types (Name) VALUES ('Electric'), ('Ground'), ('Flying'), ('Water');

-- Read rows from tables
SELECT * FROM Types 

-- Update existing rows in a table
UPDATE Types SET StrongAgainst = 'Flying', WeakAgainst = 'Ground' WHERE Name = 'Electric';

-- Delete rows from a table
DELETE FROM Types WHERE Name = 'Water';

CREATE TABLE StrongAgainst (
    Id int Primary Key IDENTITY,
    OriginType VARCHAR(100) FOREIGN KEY REFERENCES Types(Name),
    StrongAgainstType VARCHAR(100) FOREIGN KEY REFERENCES Types(Name)
)