Create database EATracking
use EATracking

-----------------------------------------Master-----------------------------------------

--Employee TABLE

CREATE TABLE [dbo].[Employee](
	[Id] [nvarchar](10) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
 
--Employee DATA:
INSERT INTO [dbo].[Employee] ([Id], [FirstName],[LastName], [Email],[Status])
VALUES ('MLI741', 'Rajeev','Reddy', 'rajeev.reddy@motivitylabs.com',1)

INSERT INTO [dbo].[Employee] ([Id], [FirstName],[LastName], [Email],[Status])
VALUES ('MLI740', 'Nitin','Sharma', 'nitin.sharma@motivitylabs.com',1)

INSERT INTO [dbo].[Employee] ([Id], [FirstName],[LastName], [Email],[Status])
VALUES ('MLI737', 'SriLaxmi','Katla', 'srilaxmi.katla@motivitylabs.com',1)

INSERT INTO [dbo].[Employee] ([Id], [FirstName],[LastName], [Email],[Status])
VALUES ('MLI748', 'Praful','Reddy', 'praful.reddy@motivitylabs.com',1)

INSERT INTO [dbo].[Employee] ([Id], [FirstName],[LastName], [Email],[Status])
VALUES ('MLI719', 'Taj','Ansari', 'taj.ansari@motivitylabs.com',1)

--POC TABLE: 

CREATE TABLE [dbo].[POC](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](50) NULL,
CONSTRAINT [PK_POC] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

--POC DATA:
INSERT INTO [dbo].[POC] ([Name]) VALUES ('Commport')
INSERT INTO [dbo].[POC] ([Name]) VALUES ('EATracking')
INSERT INTO [dbo].[POC] ([Name]) VALUES ('AutoCard')


--Project TABLE:

CREATE TABLE [dbo].[Project](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [ProjectName] [varchar](50) NULL,
CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

--Project DATA:
INSERT INTO [dbo].[Project]([ProjectName]) VALUES('Hoozin')
INSERT INTO [dbo].[Project]([ProjectName]) VALUES('Helix Sense')
INSERT INTO [dbo].[Project]([ProjectName]) VALUES('ALG - Beach Bound')
INSERT INTO [dbo].[Project]([ProjectName]) VALUES('Advent')
INSERT INTO [dbo].[Project]([ProjectName]) VALUES('BlackBerry')


--Role TABLE:

CREATE TABLE [dbo].[Role](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [RoleName] [varchar](32) NULL,
CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

--Role DATA:
INSERT INTO [dbo].[Role]([RoleName]) VALUES('Developer')
INSERT INTO [dbo].[Role]([RoleName]) VALUES('Manager')
INSERT INTO [dbo].[Role]([RoleName]) VALUES('Lead')
INSERT INTO [dbo].[Role]([RoleName]) VALUES('QA')
INSERT INTO [dbo].[Role]([RoleName]) VALUES('DevOPS')

--Skills Table:

CREATE TABLE [dbo].[Skills](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SkillName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EmpSkills] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

--Skills DATA:
INSERT INTO [dbo].[Skills]([SkillName]) VALUES('.NET')
INSERT INTO [dbo].[Skills]([SkillName]) VALUES('C#')
INSERT INTO [dbo].[Skills]([SkillName]) VALUES('Azure')
INSERT INTO [dbo].[Skills]([SkillName]) VALUES('React JS')
INSERT INTO [dbo].[Skills]([SkillName]) VALUES('Angular')


--Interview TABLE:

CREATE TABLE [dbo].[Interviews](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Skill][nvarchar](100) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
	[Date] [date] NOT NULL,
	[ReportingTo] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Interviews] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

--Interview DATA:
INSERT INTO [dbo].[Interviews]([Name], [Skill], [Role], [Status], [Date] ,[ReportingTo])
VALUES ('Rajeev', '.NET', 'Developer', 'Selected', GETDATE(), 'Sandeep Y')

INSERT INTO [dbo].[Interviews]([Name], [Skill], [Role], [Status], [Date] ,[ReportingTo])
VALUES ('Nitin', 'Azure', 'Developer', 'Selected', GETDATE(), 'Sandeep Y')

INSERT INTO [dbo].[Interviews]([Name], [Skill], [Role], [Status], [Date] ,[ReportingTo])
VALUES ('SriLaxmi', 'React JS', 'Developer', 'Selected', GETDATE(), 'Sandeep Y')

INSERT INTO [dbo].[Interviews]([Name], [Skill], [Role], [Status], [Date] ,[ReportingTo])
VALUES ('Praful', 'Angular', 'Developer', 'Selected', GETDATE(), 'Sandeep Y')

INSERT INTO [dbo].[Interviews]([Name], [Skill], [Role], [Status], [Date] ,[ReportingTo])
VALUES ('Taj', 'C#', 'Developer', 'Selected', GETDATE(), 'Sandeep Y')

select * from Interviews



--Certifications TABLE:

CREATE TABLE [dbo].[Certifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpId] [varchar](10) NULL,
	[Name] [varchar](250) NULL,
	[ValidFrom] [date] NULL,
	[ValidTill] [date] NULL,
	[EACId] [int] NULL
) ON [PRIMARY]

--Certifications DATA:
INSERT INTO [dbo].[Certifications]([EmpId], [Name], [ValidFrom], [ValidTill], [EACId])
VALUES('MLI741', 'Rajeev', getdate()-365,GETDATE()+30, 1)

INSERT INTO [dbo].[Certifications]([EmpId], [Name], [ValidFrom], [ValidTill], [EACId])
VALUES('MLI740', 'Nitin', getdate()-365,GETDATE()+30, 1)

INSERT INTO [dbo].[Certifications]([EmpId], [Name], [ValidFrom], [ValidTill], [EACId])
VALUES('MLI737', 'SriLaxmi', getdate()-365,GETDATE()+30, 1)

INSERT INTO [dbo].[Certifications]([EmpId], [Name], [ValidFrom], [ValidTill], [EACId])
VALUES('MLI748', 'Praful', getdate()-365,GETDATE()+30, 1)

INSERT INTO [dbo].[Certifications]([EmpId], [Name], [ValidFrom], [ValidTill], [EACId])
VALUES('MLI719', 'Taj', getdate()-365,GETDATE()+30, 1)

--EACouncilEntryExit TABLE:

CREATE TABLE [dbo].[EACouncilEntryExit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpId] [varchar](10) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[Role] [nvarchar](50) NULL,
	[ReportingTo] [varchar](10) NULL,
    [CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[modifiedOn] [date] NOT NULL,
) ON [PRIMARY]
 
--EACouncilEntryExit DATA:
INSERT INTO [dbo].[EACouncilEntryExit]([EmpId], [StartDate], [EndDate], [Role], [ReportingTo])
VALUES('MLI741', GETDATE()-30, GETDATE()+30, 1, 'Sandeep Y')

INSERT INTO [dbo].[EACouncilEntryExit]([EmpId], [StartDate], [EndDate], [Role], [ReportingTo])
VALUES('MLI740', GETDATE()-30, GETDATE()+30, 1, 'Sandeep Y')

INSERT INTO [dbo].[EACouncilEntryExit]([EmpId], [StartDate], [EndDate], [Role], [ReportingTo])
VALUES('MLI737', GETDATE()-30, GETDATE()+30, 1, 'Sandeep Y')

INSERT INTO [dbo].[EACouncilEntryExit]([EmpId], [StartDate], [EndDate], [Role], [ReportingTo])
VALUES('MLI748', GETDATE()-30, GETDATE()+30, 1, 'Sandeep Y')

INSERT INTO [dbo].[EACouncilEntryExit]([EmpId], [StartDate], [EndDate], [Role], [ReportingTo])
VALUES('MLI719', GETDATE()-30, GETDATE()+30, 1, 'Sandeep Y')



--Learnings TABLE:

CREATE TABLE Learnings
(ID INT PRIMARY KEY IDENTITY(1,1),
SkillID int,
HoursOfLearning int,
Name VARCHAR(30),
Path VARCHAR(500),
StartDate date,
EndDate date )

--Learnings DATA:
INSERT INTO [dbo].[Learnings]([SkillID], [HoursOfLearning], [Name], [Path], [StartDate], [EndDate])
VALUES(1, 16, 'Rajeev', 'https://learn.microsoft.com/en-us/dotnet/', GETDATE()-30, GETDATE()+30)

INSERT INTO [dbo].[Learnings]([SkillID], [HoursOfLearning], [Name], [Path], [StartDate], [EndDate])
VALUES(2,16, 'Nitin', 'https://learn.microsoft.com/en-us/certifications/exams/az-204/', GETDATE()-30, GETDATE()+30)

INSERT INTO [dbo].[Learnings]([SkillID], [HoursOfLearning], [Name], [Path], [StartDate], [EndDate])
VALUES(3, 16, 'SriLaxmi', 'https://developer.mozilla.org/en-US/docs/Learn/Tools_and_testing/Client-side_JavaScript_frameworks/React_getting_started', GETDATE()-30, GETDATE()+30)

INSERT INTO [dbo].[Learnings]([SkillID], [HoursOfLearning], [Name], [Path], [StartDate], [EndDate])
VALUES(4, 16, 'Praful', 'https://learn.microsoft.com/en-us/aspnet/core/client-side/spa/angular?view=aspnetcore-7.0&tabs=visual-studio', GETDATE()-30, GETDATE()+30)

INSERT INTO [dbo].[Learnings]([SkillID], [HoursOfLearning], [Name], [Path], [StartDate], [EndDate])
VALUES(5, 16, 'Taj', 'https://learn.microsoft.com/en-us/dotnet/', GETDATE()-30, GETDATE()+30)

--Training TABLE:

CREATE TABLE  Training
(ID INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR (30),
HoursOfLearning int,
StartDate date,
EndDate date
)

--Training DATA:
INSERT INTO [dbo].[Training]([Name], [HoursOfLearning], [StartDate], [EndDate])
VALUES('Rajeev', 16, GETDATE()-30, GETDATE()+30)

INSERT INTO [dbo].[Training]([Name], [HoursOfLearning], [StartDate], [EndDate])
VALUES('Nitin', 16, GETDATE()-30, GETDATE()+30)

INSERT INTO [dbo].[Training]([Name], [HoursOfLearning], [StartDate], [EndDate])
VALUES('SriLaxmi', 16, GETDATE()-30, GETDATE()+30)

INSERT INTO [dbo].[Training]([Name], [HoursOfLearning], [StartDate], [EndDate])
VALUES('Praful', 16, GETDATE()-30, GETDATE()+30)

INSERT INTO [dbo].[Training]([Name], [HoursOfLearning], [StartDate], [EndDate])
VALUES('Taj', 16, GETDATE()-30, GETDATE()+30)


-----------------------------------------Employee-----------------------------------------

--EmployeePOC TABLE:

CREATE TABLE [dbo].[EmployeePOC](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [POCId] [int] NOT NULL,
    [EmpId] [nvarchar](10) NOT NULL,
    [BenchId] [int] NOT NULL,
    [StartDate] [date] NULL,
    [EndDate] [date] NULL,
    [ReportingTo] [nvarchar](25) NULL,
    [RoleId] [int] NOT NULL,
CONSTRAINT [PK_EmployeePOC] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
  ALTER TABLE [dbo].[EmployeePOC]  WITH CHECK ADD  CONSTRAINT [FK_EmployeePOC_POC] FOREIGN KEY([POCId])
REFERENCES [dbo].[POC] ([Id])
  ALTER TABLE [dbo].[EmployeePOC] CHECK CONSTRAINT [FK_EmployeePOC_POC]
  ALTER TABLE [dbo].[EmployeePOC]  WITH CHECK ADD  CONSTRAINT [FK_EmployeePOC_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ALTER TABLE [dbo].[EmployeePOC] CHECK CONSTRAINT [FK_EmployeePOC_Role]

ALTER TABLE [dbo].[EmployeePOC]  WITH CHECK ADD  CONSTRAINT [FK_EmployeePOC_Employee] FOREIGN KEY([EmpId])
REFERENCES [dbo].[Employee] ([Id])
ALTER TABLE [dbo].[EmployeePOC] CHECK CONSTRAINT [FK_EmployeePOC_Employee]

--EmployeePOC DATA:
INSERT INTO [dbo].[EmployeePOC]([POCId], [EmpId], [BenchId], [StartDate], [EndDate], [ReportingTo], [RoleId])
VALUES(1, 'MLI741', 1, GETDATE()-30, GETDATE()+30, 'Sandeep Y', 1)

INSERT INTO [dbo].[EmployeePOC]([POCId], [EmpId], [BenchId], [StartDate], [EndDate], [ReportingTo], [RoleId])
VALUES(1, 'MLI740', 2, GETDATE()-30, GETDATE()+30, 'Sandeep Y', 1)

INSERT INTO [dbo].[EmployeePOC]([POCId], [EmpId], [BenchId], [StartDate], [EndDate], [ReportingTo], [RoleId])
VALUES(1, 'MLI737', 3, GETDATE()-30, GETDATE()+30, 'Sandeep Y', 1)

INSERT INTO [dbo].[EmployeePOC]([POCId], [EmpId], [BenchId], [StartDate], [EndDate], [ReportingTo], [RoleId])
VALUES(1, 'MLI748', 4, GETDATE()-30, GETDATE()+30, 'Sandeep Y', 1)

INSERT INTO [dbo].[EmployeePOC]([POCId], [EmpId], [BenchId], [StartDate], [EndDate], [ReportingTo], [RoleId])
VALUES(1, 'MLI719', 5, GETDATE()-30, GETDATE()+30, 'Sandeep Y', 1)


--EmployeeProject TABLE:

CREATE TABLE [dbo].[EmployeeProject](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [ProjectId] [int] NOT NULL,
    [EmpId] [nvarchar](10) NULL,
    [StartDate] [date] NULL,
    [EndDate] [date] NULL,
    [ReportingTo] [varchar](50) NULL,
    [RoleId] [int] NOT NULL,
    [Achivements] [varchar](200) NULL,
CONSTRAINT [PK_EmployeeProject] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
ALTER TABLE [dbo].[EmployeeProject]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeProject_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
ALTER TABLE [dbo].[EmployeeProject] CHECK CONSTRAINT [FK_EmployeeProject_Project]
ALTER TABLE [dbo].[EmployeeProject]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeProject_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ALTER TABLE [dbo].[EmployeeProject] CHECK CONSTRAINT [FK_EmployeeProject_Role]

ALTER TABLE [dbo].[EmployeeProject]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeProject_Employee] FOREIGN KEY([EmpId])
REFERENCES [dbo].[Employee] ([Id])
ALTER TABLE [dbo].[EmployeeProject] CHECK CONSTRAINT [FK_EmployeeProject_Employee]
 
--EmployeeProject DATA:
INSERT INTO [dbo].[EmployeeProject]([ProjectId], [EmpId], [StartDate], [EndDate], [ReportingTo], [RoleId], [Achivements])
VALUES(1, 'MLI741', GETDATE()-365, GETDATE(), 'Sandeep Y', 1, 'Best service of the Month')

INSERT INTO [dbo].[EmployeeProject]([ProjectId], [EmpId], [StartDate], [EndDate], [ReportingTo], [RoleId], [Achivements])
VALUES(2, 'MLI740', GETDATE()-365, GETDATE(), 'Sandeep Y', 1, 'Best Employee of the Month')

INSERT INTO [dbo].[EmployeeProject]([ProjectId], [EmpId], [StartDate], [EndDate], [ReportingTo], [RoleId], [Achivements])
VALUES(2, 'MLI737', GETDATE()-365, GETDATE(), 'Sandeep Y', 1, 'Best Shared Service of the Month')

INSERT INTO [dbo].[EmployeeProject]([ProjectId], [EmpId], [StartDate], [EndDate], [ReportingTo], [RoleId], [Achivements])
VALUES(2, 'MLI748', GETDATE()-365, GETDATE(), 'Sandeep Y', 1, 'Best Employee of the Month')

INSERT INTO [dbo].[EmployeeProject]([ProjectId], [EmpId], [StartDate], [EndDate], [ReportingTo], [RoleId], [Achivements])
VALUES(4, 'MLI719', GETDATE()-365, GETDATE(), 'Sandeep Y', 1, 'Best Shared Service of the Month')


--EmployeeLearning TABLE:

CREATE TABLE EmployeeLearning
([ID] [INT] PRIMARY KEY IDENTITY(1,1),
[LearningID] INT,
[EmpId] [nvarchar](10) NULL,
[StartDate] [date],
[EndDate] [date],
[BenchID] [INT])

--EmployeeLearning DATA:
INSERT INTO [dbo].[EmployeeLearning]([LearningID], [EmpID], [StartDate], [EndDate], [BenchID])
VALUES(1, 'MLI741', GETDATE()-30, GETDATE()+30, 1)

INSERT INTO [dbo].[EmployeeLearning]([LearningID], [EmpID], [StartDate], [EndDate], [BenchID])
VALUES(1, 'MLI740', GETDATE()-30, GETDATE()+30, 2)

INSERT INTO [dbo].[EmployeeLearning]([LearningID], [EmpID], [StartDate], [EndDate], [BenchID])
VALUES(1, 'MLI737', GETDATE()-30, GETDATE()+30, 3)

INSERT INTO [dbo].[EmployeeLearning]([LearningID], [EmpID], [StartDate], [EndDate], [BenchID])
VALUES(1, 'MLI748', GETDATE()-30, GETDATE()+30, 4)

INSERT INTO [dbo].[EmployeeLearning]([LearningID], [EmpID], [StartDate], [EndDate], [BenchID])
VALUES(1, 'MLI719', GETDATE()-30, GETDATE()+30, 5)

--EmployeeTraining TABLE:

CREATE TABLE EmployeeTraining
([ID] [INT] PRIMARY KEY IDENTITY(1,1),
[EmpID] [nvarchar] (10),
[TraningID] [INT],
[StartDate] [date],
[EndDate] [date],
[BenchID] [INT])

--EmployeeTraining DATA:
INSERT INTO [dbo].[EmployeeTraining]([EmpID], [TraningID], [StartDate], [EndDate], [BenchID])
VALUES('MLI741', 1, GETDATE()-30, GETDATE()+30, 1)

INSERT INTO [dbo].[EmployeeTraining]([EmpID], [TraningID], [StartDate], [EndDate], [BenchID])
VALUES('MLI740', 2, GETDATE()-30, GETDATE()+30, 2)

INSERT INTO [dbo].[EmployeeTraining]([EmpID], [TraningID], [StartDate], [EndDate], [BenchID])
VALUES('MLI737', 3, GETDATE()-30, GETDATE()+30, 3)

INSERT INTO [dbo].[EmployeeTraining]([EmpID], [TraningID], [StartDate], [EndDate], [BenchID])
VALUES('MLI748', 4, GETDATE()-30, GETDATE()+30, 4)

INSERT INTO [dbo].[EmployeeTraining]([EmpID], [TraningID], [StartDate], [EndDate], [BenchID])
VALUES('MLI719', 5, GETDATE()-30, GETDATE()+30, 5)

--EmployeeSkills TABLE:

CREATE TABLE [dbo].[EmployeeSkills](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmpID] [nvarchar] (10) NOT NULL,
	[SkillID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date](50) NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[modifiedOn] [date] NOT NULL,
 CONSTRAINT [PK_EmployeeSkills] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[EmployeeSkills]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeSkills_Skills] FOREIGN KEY([SkillID])
REFERENCES [dbo].[Skills] ([ID])

ALTER TABLE [dbo].[EmployeeSkills] CHECK CONSTRAINT [FK_EmployeeSkills_Skills]

--EmployeeSkills DATA:
INSERT INTO [dbo].[EmployeeSkills]([EmpID], [SkillID], [StartDate], [EndDate], [CreatedBy], [CreatedOn], [ModifiedBy], [modifiedOn])
VALUES('MLI741', 1, GETDATE()-30, GETDATE(), 'Rajeev', GETDATE(), 'Rajeev', GETDATE()+1)

INSERT INTO [dbo].[EmployeeSkills]([EmpID], [SkillID], [StartDate], [EndDate], [CreatedBy], [CreatedOn], [ModifiedBy], [modifiedOn])
VALUES('MLI740', 2, GETDATE()-30, GETDATE(), 'Nitin', GETDATE(), 'Nitin', GETDATE()+1)

INSERT INTO [dbo].[EmployeeSkills]([EmpID], [SkillID], [StartDate], [EndDate], [CreatedBy], [CreatedOn], [ModifiedBy], [modifiedOn])
VALUES('MLI737', 3, GETDATE()-30, GETDATE(), 'SriLaxmi', GETDATE(), 'SriLaxmi', GETDATE()+1)

INSERT INTO [dbo].[EmployeeSkills]([EmpID], [SkillID], [StartDate], [EndDate], [CreatedBy], [CreatedOn], [ModifiedBy], [modifiedOn])
VALUES('MLI748', 4, GETDATE()-30, GETDATE(), 'Praful', GETDATE(), 'Praful', GETDATE()+1)

INSERT INTO [dbo].[EmployeeSkills]([EmpID], [SkillID], [StartDate], [EndDate], [CreatedBy], [CreatedOn], [ModifiedBy], [modifiedOn])
VALUES('MLI719', 5, GETDATE()-30, GETDATE(), 'Taj', GETDATE(), 'Taj', GETDATE()+1)