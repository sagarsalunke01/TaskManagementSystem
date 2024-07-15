Task Management System 
Instructions :
1.	Please execute the script TaskManagementSystemDB.sql before running the application so that all the DB schemas will be in place.
Script is available inside zipped folder.
2.	Change the connection string as per the SQL Server to be connected in which the above script is executed in appsettings.json file.
File Path : ~TaskManagementSystem\TaskManagementSystem.ServiceLayer
File name : appsettings.json
 

Application Configurations :
1.	.Net Core Framework Version : .Net 8.0
2.	Entity Framework Core Version : v8.0.7
3.	SQL Server Management Studio : v18.12.1

Payloads for the Methods:
NOTE : empId available between 1000 to 1004
1.	Employees Controller :
a.	GetAllTasksByEmpId :
i.	empId = 1000
b.	AddNotes :
i.	taskId = 1
ii.	empId = 1000
iii.	notes = Completed Development
c.	UpdateCompleionPercentage :
i.	taskId = 1
ii.	percentage = 100

2.	EmpManagerTeamLead Controller :
a.	GetTasksByEmpManager :
i.	empManager = Armineh Watson		 TestCase 1
ii.	empManager = Hector Wong			 TestCase 2

3.	CompanyAdmin Controller :
a.	GetTaskDetailsByDueDate :
i.	tasksDueIn = month       	 TestCase 1
ii.	tasksDueIn = week		 TestCase 2
