CREATE TABLE FlashCards (
    Id INT PRIMARY KEY IDENTITY(1, 1),
    Question NVARCHAR(max) not null,
    Answer NVARCHAR(max) not null,
    WasCorrect BIT DEFAULT 0
);

INSERT INTO FlashCards (Question, Answer)
VALUES 
('Difference between git and github', 'git is version control system whereas github is cloud hosting of git repositories'),
('what is an interface', 'it is type where you define a contract with public method signatures where implementing concrete classes must provide implementations for those methods'),
('what is a database', 'is an structure to store organized data'),
('difference between overloading and overriding', 'overloading is the same method name with different parameters where each provides different impls where overriding is between any two classes that are connected by inheritance where they share the method name and parameters but the child class "extends" the parent''s impl. Must use virtual and override modifiers');

SELECT * FROM FlashCards;

UPDATE FlashCards SET WasCorrect = 1, Question = 'What does SQL stand for?', Answer = 'Standard Query Language' WHERE Id = 6;

INSERT INTO FlashCards (Question, Answer) OUTPUT INSERTED.Id VALUES ('sample q', 'sample a');