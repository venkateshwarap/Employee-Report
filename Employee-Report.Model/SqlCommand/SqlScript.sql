Create database EATracking
use EATracking

--EmployeePOC:

CREATE TABLE [dbo].[EmployeePOC](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [POCId] [int] NOT NULL,
    [EmpId] [nvarchar](10) NOT NULL,
    [BenchId] [int] NOT NULL,
    [StartDate] [datetime] NULL,
    [EndDate] [datetime] NULL,
    [ReportingTo] [nvarchar](25) NULL,
    [RoleId] [int] NOT NULL,
CONSTRAINT [PK_EmployeePOC] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO ALTER TABLE [dbo].[EmployeePOC]  WITH CHECK ADD  CONSTRAINT [FK_EmployeePOC_POC] FOREIGN KEY([POCId])
REFERENCES [dbo].[POC] ([Id])
GO ALTER TABLE [dbo].[EmployeePOC] CHECK CONSTRAINT [FK_EmployeePOC_POC]
GO ALTER TABLE [dbo].[EmployeePOC]  WITH CHECK ADD  CONSTRAINT [FK_EmployeePOC_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO ALTER TABLE [dbo].[EmployeePOC] CHECK CONSTRAINT [FK_EmployeePOC_Role]
GO






--POC: 

CREATE TABLE [dbo].[POC](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](50) NULL,
CONSTRAINT [PK_POC] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO






--Project:

CREATE TABLE [dbo].[Project](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [ProjectName] [varchar](50) NULL,
CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO






--EmployeeProject:

CREATE TABLE [dbo].[EmployeeProject](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [ProjectId] [int] NOT NULL,
    [EmpId] [nvarchar](10) NULL,
    [StartDate] [datetime] NULL,
    [EndDate] [datetime] NULL,
    [ReportingTo] [varchar](50) NULL,
    [RoleId] [int] NOT NULL,
    [Achivements] [varchar](200) NULL,
CONSTRAINT [PK_EmployeeProject] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO ALTER TABLE [dbo].[EmployeeProject]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeProject_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO ALTER TABLE [dbo].[EmployeeProject] CHECK CONSTRAINT [FK_EmployeeProject_Project]
GO ALTER TABLE [dbo].[EmployeeProject]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeProject_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO ALTER TABLE [dbo].[EmployeeProject] CHECK CONSTRAINT [FK_EmployeeProject_Role]
GO






--Role

CREATE TABLE [dbo].[Role](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [RoleName] [varchar](32) NULL,
CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO






--Skills

CREATE TABLE [dbo].[Skills](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SkillName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EmpSkills] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO






--Interview

CREATE TABLE [dbo].[Interviews](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Skill][nvarchar](100) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
	[Date] [datetime] NOT NULL,
	[ReportingTo] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Interviews] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO






--EACouncilEntryExit

CREATE TABLE [dbo].[EACouncilEntryExit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpId] [varchar](10) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Role] [nvarchar](50) NULL,
	[ReportingTo] [varchar](10) NULL
) ON [PRIMARY]
GO






--Certifications

CREATE TABLE [dbo].[Certifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpId] [varchar](10) NULL,
	[Name] [varchar](250) NULL,
	[ValidFrom] [datetime] NULL,
	[ValidTill] [datetime] NULL,
	[EACId] [int] NULL
) ON [PRIMARY]
GO






--LEARNINGS

CREATE TABLE LEARNINGS
(ID INT PRIMARY KEY IDENTITY(1,1),
SkillID int,
HoursOfLearning int,
Name VARCHAR(30),
Path VARCHAR(500),
StartDate datetime,
EndDate datetime )






--EmployeeLearning

CREATE TABLE EmployeeLearning
(ID INT PRIMARY KEY IDENTITY(1,1),
LearningID INT,
EmpID INT,
StartDate DATETIME,
EndDate DATETIME,
BenchID INT)






--Training

CREATE TABLE  Training
(ID INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR (30),
HoursOfLearning int,
StartDate datetime,
EndDate datetime
)






--EmployeeTraining

CREATE TABLE EmployeeTraining
(ID INT PRIMARY KEY IDENTITY(1,1),
EmpID INT,
TraningID INT,
StartDate DATETIME,
EndDate DATETIME,
BenchID INT)

