-- CREATE TABLE Books(
--     Title VARCHAR(250) NOT NULL,
--     Author VARCHAR(100) NOT NULL,
--     Pages INT NOT NULL,
--     Thickness VARCHAR(10) NOT NULL,
--     GenreID INT NOT NULL,
--     PublisherID INT NOT NULL
-- );

-- --Create an Authors Table
-- CREATE TABLE Authors(
--     Author VARCHAR(100) PRIMARY KEY,
--     AuthorNationality VARCHAR(100) NOT NULL
-- );

-- --Create a Genres Table
-- CREATE TABLE Genres
-- (
-- 	ID INT PRIMARY KEY
-- );

-- --Introducing ALTER - change something about a table that is already in the db.
-- --VERB NOUN <NAME>, VERB <NAME> <TYPE> <Mods>
-- ALTER TABLE Genres ADD Genre VARCHAR(100) NOT NULL;

-- DROP TABLE Genres;

-- CREATE TABLE Genres(
--     ID INT PRIMARY KEY,
--     Genre VARCHAR(100) NOT NULL
-- );

-- --Modify a table to REMOVE the NOT NULL property from a field
-- ALTER TABLE Books ALTER COLUMN Pages INT NOT NULL;

-- --Create the Format-Price Table *Composite KEY!*
-- CREATE TABLE FormatPrice (
--     Title VARCHAR(250) NOT NULL,
--     PrintFormat VARCHAR(50) NOT NULL,
--     Price MONEY NOT NULL,
--     PRIMARY KEY (Title, PrintFormat)
-- );

-- --Create A Foreign Key As An Alteration
-- ALTER TABLE FormatPrice ADD PRIMARY KEY (Title, PrintFormat);

-- --Rename A Table
-- -- ALTER TABLE Genres CHANGE COLUMN Genre TO Genre2;

-- --Create A Foreign Key As An Alteration
-- ALTER TABLE Books ADD FOREIGN KEY (Author) REFERENCES Authors(Author);
-- --Verb Noun <TableName> VERB NOUN <ColumnNAME> "REFERENCES" <FTABLE>(<FColumn>)

-- ALTER TABLE Books ADD FOREIGN KEY (GenreID) REFERENCES Genres(ID);
-- --                                                     ^^ references a certain table by id

-- --DML Data Manipulation Language
-- --Insert  - place data in a table

-- --when inserting, order matters
-- INSERT Genres 
-- (ID, Genre) 
-- Values 
-- (1, 'Tutorial'),
-- (2, 'Popular Science')
-- INSERT Authors 
-- (Author, AuthorNationality) 
-- Values 
-- ('Chad Russell', 'American'),
-- ('E.F.Codd', 'British');

-- /*The INNER JOIN keyword selects all rows from both tables as long as there is a match between the columns. 
-- If there are records in the "Orders" table that do not have matches in "Customers", these orders will not be shown! 
-- */

-- Chinook queries
SELECT Customer.FirstName, Customer.LastName, Customer.CustomerId, Customer.Country
FROM Customer WHERE NOT Customer.Country = 'USA';

SELECT Customer.FirstName, Customer.LastName, Customer.CustomerId, Customer.Country
FROM Customer WHERE Customer.Country = 'Brazil';

CREATE TABLE Marketing(
    ID INT NOT NULL,
    Name VARCHAR(250) NOT NULL,
    Location VARCHAR(100) ,
    PRIMARY KEY (ID, Name)
);

ALTER TABLE Employee
ADD SSN INT NULL;

update  Employee
set     SSN = 389-129-1922
where   FirstName = 'Andrew' and LastName = 'Adams';

update  Employee
set     SSN = 478-101-2922
where   FirstName = 'Nancy' and LastName = 'Edwards';

update  Employee
set     SSN = 188-151-2522
where   FirstName = 'Jane' and LastName = 'Peacock';

update  Employee
set     SSN = 448-151-1622
where   FirstName = 'Margaret' and LastName = 'Park';

update  Employee
set     SSN = 488-811-2922
where   FirstName = 'Steve' and LastName = 'Johnson';

update  Employee
set     SSN = 111-151-2922
where   FirstName = 'Michael' and LastName = 'Mitchell';

update  Employee
set     SSN = 408-991-2922
where   FirstName = 'Robert' and LastName = 'King';

update  Employee
set     SSN = 498-151-2965
where   FirstName = 'Laura' and LastName = 'Callahan';

