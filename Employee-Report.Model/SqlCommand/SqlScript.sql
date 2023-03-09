Create database EATracking
use EATracking

-----------------------------------------Master-----------------------------------------


CREATE TABLE [dbo].[Employee](
    [EmpId] [nvarchar](10) NOT NULL,
    [Name] [varchar](50) NOT NULL,
    [Email] [nvarchar](50) NOT NULL,
CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
    [EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
 
--POC: 

CREATE TABLE [dbo].[POC](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](50) NULL,
CONSTRAINT [PK_POC] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

--Project:

CREATE TABLE [dbo].[Project](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [ProjectName] [varchar](50) NULL,
CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

--Role

CREATE TABLE [dbo].[Role](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [RoleName] [varchar](32) NULL,
CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

--Skills

CREATE TABLE [dbo].[Skills](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SkillName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EmpSkills] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

--Interview

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

--Certifications

CREATE TABLE [dbo].[Certifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpId] [varchar](10) NULL,
	[Name] [varchar](250) NULL,
	[ValidFrom] [date] NULL,
	[ValidTill] [date] NULL,
	[EACId] [int] NULL
) ON [PRIMARY]

--Learnings

CREATE TABLE Learnings
(ID INT PRIMARY KEY IDENTITY(1,1),
SkillID int,
HoursOfLearning int,
Name VARCHAR(30),
Path VARCHAR(500),
StartDate date,
EndDate date )

--Training

CREATE TABLE  Training
(ID INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR (30),
HoursOfLearning int,
StartDate date,
EndDate date
)

-----------------------------------------Employee-----------------------------------------

--EmployeePOC:

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
REFERENCES [dbo].[Employee] ([EmpId])
ALTER TABLE [dbo].[EmployeePOC] CHECK CONSTRAINT [FK_EmployeePOC_Employee]


--EmployeeProject:

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
REFERENCES [dbo].[Employee] ([EmpId])
ALTER TABLE [dbo].[EmployeeProject] CHECK CONSTRAINT [FK_EmployeeProject_Employee]
 
--EACouncilEntryExit

CREATE TABLE [dbo].[EACouncilEntryExit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpId] [varchar](10) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[Role] [nvarchar](50) NULL,
	[ReportingTo] [varchar](10) NULL
) ON [PRIMARY]
 
--EmployeeLearning

CREATE TABLE EmployeeLearning
(ID INT PRIMARY KEY IDENTITY(1,1),
LearningID INT,
EmpID INT,
StartDate date,
EndDate date,
BenchID INT)

--EmployeeTraining

CREATE TABLE EmployeeTraining
(ID INT PRIMARY KEY IDENTITY(1,1),
EmpID INT,
TraningID INT,
StartDate date,
EndDate date,
BenchID INT)