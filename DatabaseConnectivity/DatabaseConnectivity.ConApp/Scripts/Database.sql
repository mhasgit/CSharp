-- SELECT * FROM Employees;

SELECT *
FROM sys.tables


-- INSERT INTO Employees (FirstName, LastName, Email, Phone)
-- VALUES ('John', 'Doe', 'johndoe@example.com', '123-456-7890')

SELECT * FROM Employees

SELECT EmployeeId, FirstName, LastName, Phone, Email FROM Employees



-- CREATE TABLE [dbo].[Locations](
-- 	[LocationID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
-- 	[Name] [varchar](50) NOT NULL,
-- 	[Address] [varchar](100) NOT NULL,
-- 	[Phone] [varchar](20) NOT NULL
-- )

-- INSERT INTO [dbo].[Locations] ([Name], [Address], [Phone])
-- VALUES ('Location 1', '123 Main St', '555-1234'),
--        ('Location 2', '456 Elm St', '555-5678'),
--        ('Location 3', '789 Oak St', '555-9101'),
--        ('Location 4', '321 Pine St', '555-1212'),
--        ('Location 5', '654 Maple St', '555-3434');