Create database EATracking
use EATracking

CREATE TABLE LEARNINGS
(ID INT PRIMARY KEY IDENTITY(1,1),
SkillID int,
Name VARCHAR(30),
Path VARCHAR(500),
StartDate datetime,
EndDate datetime )




CREATE TABLE EmployeeLearning
(ID INT PRIMARY KEY IDENTITY(1,1),
LearningID INT,
EmpID INT,
StartDate DATETIME,
EndDate DATETIME,
BenchID INT)



CREATE TABLE  Traning
(ID INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR (30),
 HoursOfLearning int ,
 StartDate datetime,
 EndDate datetime
)

select * from traning


CREATE TABLE EmployeeTrainng
(ID INT PRIMARY KEY IDENTITY(1,1),
EmpID INT,
TraningID INT,
StartDate DATETIME,
EndDate DATETIME,
BenchID INT)

SELECT * FROM EmployeeTrainng



