CREATE DATABASE StudentDB

Create Table Students (
StudentID INT PRIMARY KEY IDENTITY(1,1),
FirstName VARCHAR(50),
LastName VARCHAR(50),
Age int,
Course VARCHAR(50)
)

INSERT INTO Students (FirstName, LastName, Age, Course) VALUES
(
'John Marven', 'Quidato', 20, 'BSIT'
)

select * from Students