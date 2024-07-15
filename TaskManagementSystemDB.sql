
CREATE DATABASE TaskManagement
GO

USE [TaskManagement]
GO

CREATE TABLE Employee (
EmpId INT IDENTITY(1000,1), 
EmpName VARCHAR(50),
EmpManager VARCHAR(50),
PRIMARY KEY(EmpId)
)
GO


CREATE TABLE Teams (
TeamId INT IDENTITY(1,1) PRIMARY KEY,
TeamName VARCHAR(50),
EmpManager VARCHAR(50)
)
GO

CREATE TABLE Tasks (
TaskId INT PRIMARY KEY IDENTITY(1,1),
TaskName VARCHAR(MAX),
EmpId INT,
Notes VARCHAR(MAX),
TaskCompletionPercentage INT,
Document VARBINARY(MAX),
DueDate DATETIME,
FOREIGN KEY(EmpId) REFERENCES Employee(EmpId)
)
GO


INSERT INTO Employee VALUES ('John Jacobs', 'Armineh Watson')
INSERT INTO Employee VALUES ('Gary Armstrong', 'Hector Wong')
INSERT INTO Employee VALUES ('John Raghib', 'Hector Wong')
INSERT INTO Employee VALUES ('Peter Zelaya', 'Hector Wong')
INSERT INTO Employee VALUES ('Ana Djance', 'Armineh Watson')
GO

INSERT INTO Tasks (TaskName, EmpId, Notes, TaskCompletionPercentage, DueDate) VALUES ('Complete Development', 1000, '', 10, '07-21-2024')
INSERT INTO Tasks (TaskName, EmpId, Notes, TaskCompletionPercentage, DueDate) VALUES ('Complete Smoke Testing', 1000, '', 10, '07-28-2024')
INSERT INTO Tasks (TaskName, EmpId, Notes, TaskCompletionPercentage, DueDate) VALUES ('Complete Unit Testing', 1000, '', 10, '07-28-2024')
INSERT INTO Tasks (TaskName, EmpId, Notes, TaskCompletionPercentage, DueDate) VALUES ('Complete Regression Testing', 1001, '', 10, '08-04-2024')
INSERT INTO Tasks (TaskName, EmpId, Notes, TaskCompletionPercentage, DueDate) VALUES ('Complete UAT', 1002, '', 10, '08-11-2024')
INSERT INTO Tasks (TaskName, EmpId, Notes, TaskCompletionPercentage, DueDate) VALUES ('Complete Approvals for Go-Live', 1003, '', 10, '08-15-2024')
INSERT INTO Tasks (TaskName, EmpId, Notes, TaskCompletionPercentage, DueDate) VALUES ('Complete Deployment', 1004, '', 10, '08-24-2024')
GO

INSERT INTO Teams VALUES ('Dev', 'Armineh Watson')
INSERT INTO Teams VALUES ('QA', 'Hector Wong')
GO

CREATE PROCEDURE USP_GetTaskDetailsByDueDate(
@DueIn VARCHAR(10)
)
AS

BEGIN

	DECLARE @DueDays INT

	IF(@DueIn = 'week')
	BEGIN
		SET @DueDays = 7
	END

	IF(@DueIn = 'month')
	BEGIN
		SET @DueDays = 30
	END

	SELECT tm.TeamName as TeamName, tm.EmpManager as EmpManager, tsk.TaskName as TaskName, tsk.DueDate as DueDate, tsk.TaskCompletionPercentage as TaskCompletionPercentage
	FROM Tasks tsk
	INNER JOIN Employee emp ON tsk.EmpId = emp.EmpId
	INNER JOIN Teams tm ON tm.EmpManager = emp.EmpManager
	WHERE DATEDIFF(DAY, GETDATE(), DueDate) <= @DueDays

END
GO