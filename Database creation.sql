CREATE TABLE Modules(
ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
ModuleCode varchar(255),
ModuleName varchar(255),
Description varchar(max),
Resource varchar(255)
)
INSERT INTO Modules
(ModuleCode, ModuleName, Description, Resource)
VALUES
('PRG', 'Programming', 'Learn how to code or build your skills in programming online to gain a better understanding of how websites and apps are designed and developed.', 'https://youtu.be/xk4_1vDrzzo'),
('WPR', 'Web Programming', 'The writing, markup, and coding involved in Web development, which includes Web content, Web client and server scripting, and network security, is referred to as web programming.', 'https://youtu.be/Q33KBiDriJY'),
('PMM', 'Project Management', 'The process of leading a team to achieve goals or complete deliverables within a specified timeframe is referred to as project management.', 'https://youtu.be/uWPIsaYpY7U'),
('MAT', 'Mathematics', 'number, quantity, and space as abstract concepts (pure mathematics) or as applied to other disciplines such as physics and engineering (applied mathematics).', 'https://youtu.be/TMubSggUOVE'),
('STA', 'Statistics', 'Statistics is the study of data collection, analysis, presentation, and interpretation.', 'https://youtu.be/hjZJIVWHnPE'),
('ACW', 'Academic Writing', 'Academic writing is a formal writing style that is commonly used in universities and scholarly publications. It will appear in academic journal articles and books, and you will be expected to write your essays, research papers, and dissertation in academic style.', 'https://youtu.be/rIZ1vuk_c5Y'),
('DBD', 'Database Development', 'In this course, we will be looking at database management basics and SQL using the MySQL RDBMS', 'https://youtu.be/HXV3zeQKqGY')

CREATE TABLE Students(
StudentNumber int IDENTITY(123456,1) PRIMARY KEY,
FirstName varchar(255),
LastName varchar(255),
StudentImage image,
DateOfBirth DATETIME,
Gender varchar(255),
PhoneNumber varchar(10) ,
Address varchar(255)
)
INSERT INTO Students
(FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Address)
VALUES
('Marry', 'Jane', 03/11/1999, 'Female', '0824583636', '5 Cranberry street Rosewood'),
('Harry', 'Styles', 12/08/2000, 'Male', '0782563333', '7 Sesame street Lanemain'),
('John', 'Doe', 23/02/1999, 'Male', '075222123', '5 kambrey street Hyland'),
('Lisa', 'Green', 28/06/2001, 'Female', '0812555666', '5 kings street lainmain'),
('Loren', 'Kale', 14/01/2002, 'Female', '0752366966', '21 George street Rosewood')

CREATE TABLE StudentModules
(
ID int IDENTITY(1,1) PRIMARY KEY,
StudentNumber int  FOREIGN KEY REFERENCES Students(StudentNumber),
ModuleCode varchar(255),
ModuleName varchar(255)
)


CREATE PROCEDURE AddStudent
(
	@FirstName VARCHAR(255),
	@LastName VARCHAR(255),
	@StudentImage image,
	@DateOfBirth date,
	@Gender VARCHAR(255),
	@PhoneNumber VARCHAR(10),
	@Address VARCHAR(255)
)
AS
BEGIN
	INSERT INTO Students
	VALUES (@FirstName, @LastName, @StudentImage, @DateOfBirth, @Gender, @PhoneNumber, @Address)
END


CREATE PROCEDURE UpdateStudent
(
	@Id int,
	@FirstName VARCHAR(255),
	@LastName VARCHAR(255),
	@StudentImage image,
	@DateOfBirth date,
	@Gender VARCHAR(255),
	@PhoneNumber VARCHAR(10),
	@Address VARCHAR(255)
)
AS
BEGIN
	UPDATE Students
	SET FirstName = @FirstName, LastName = @LastName, StudentImage = @StudentImage, DateOfBirth = @DateOfBirth, 
	Gender = @Gender,  PhoneNumber = @PhoneNumber, Address = @Address
	WHERE StudentNumber = @Id 
END



CREATE PROCEDURE DeleteStudent
(
	@Id int
)
AS
BEGIN 
	DELETE FROM Students
	WHERE [StudentNumber] = @Id
END



CREATE PROCEDURE SearchStudent
(
	@Id int
)
AS
BEGIN
	SELECT * FROM Students
	WHERE StudentNumber = @Id
END



CREATE PROCEDURE Display
AS
BEGIN
	SELECT * FROM Students
END

CREATE PROCEDURE spSearchStudent
(
@ID int
)

AS 
BEGIN
SELECT *
FROM Students
WHERE StudentID = @ID
END

Create PROCEDURE spDisplayCourse
AS
BEGIN
SELECT *
FROM Modules
END

Create PROCEDURE spCourse
AS
BEGIN
SELECT ModuleName
FROM Modules
END

CREATE PROCEDURE spAddStudentModules
(
@Number int,
@Code varchar(50),
@Name varchar(225)
)
AS
BEGIN
INSERT INTO StudentModules
(StudentNumber, ModuleCode, ModuleName)
VALUES(@number, @Code, @Name)
END


CREATE PROCEDURE spDeleteStudentModules
(
	@Id int
)
AS
BEGIN 
	DELETE FROM StudentModules
	WHERE StudentNumber = @Id
END


CREATE PROCEDURE spAddModules
(
@Code varchar(50),
@Name varchar(225),
@Description varchar(500),
@Link varchar(500)
)
AS
BEGIN
INSERT INTO Modules
(ModuleCode, ModuleName, Description, Resource)
VALUES(@Code, @Name, @Description, @Link)
END


CREATE PROCEDURE spDeleteModules
(
	@Id int
)
AS
BEGIN 
	DELETE FROM Modules
	WHERE ModuleCode = @Id
END

CREATE PROCEDURE spUpdateModules
(
@Code varchar(50),
@Name varchar(225),
@Description varchar(500),
@Link varchar(500)
)
AS
BEGIN
UPDATE Modules
SET
ModuleName = @Name, Description = @Description, Resource = @Link
WHERE ModuleCode Like @Code
END