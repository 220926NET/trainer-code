Create Table [Order] 
(
    OrderId int PRIMARY KEY IDENTITY,
    DatePlaced DATETIME DEFAULT GETDATE(),
    Deleted bit default 0
)

Create Table OrderItem
(
    OrderId int FOREIGN KEY REFERENCES [Order](OrderId) on delete cascade,
    Item NVARCHAR(50) NOT NULL,
    Quantity int check (Quantity > 0)
)

Insert into [Order] Values (GETDATE());

Select * from [OrderItem]

INSERT INTO [OrderItem] (OrderId, Item, Quantity) VALUES (2, 'Lettuce', 1), (2, 'Coffee Beans', 32)

DELETE FROM [Order] WHERE OrderId = 1