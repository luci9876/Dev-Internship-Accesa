
USE [SportsBuddyDB]
GO


/****** Object:  Table [dbo].[Addresses]    Script Date: 8/17/2021 3:11:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Addresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Street] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[State] [nvarchar](max) NOT NULL,
	[PostalCode] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[Latitude] [decimal](8, 6) NULL,
	[Longitude] [decimal](9, 6) NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[Roles]    Script Date: 8/17/2021 3:15:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [SportsBuddyDB]
GO




USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[User]    Script Date: 8/30/2021 11:10:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Gender] [char](1) NOT NULL,
	[PhoneNumber] [varchar](15) NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Address] [int] NOT NULL,
	[CreatedAt] [date] NOT NULL,
	[RoleId] [int] NOT NULL,
	[Score] [int] NOT NULL,
 CONSTRAINT [PK_Trainee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__User__RoleId__73BA3083]  DEFAULT ((0)) FOR [RoleId]
GO

ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Score]  DEFAULT ((0)) FOR [Score]
GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_Trainee_Addresses] FOREIGN KEY([Address])
REFERENCES [dbo].[Addresses] ([Id])
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_Trainee_Addresses]
GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_Trainee_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_Trainee_Roles_RoleId]
GO

USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[Trainers]    Script Date: 8/17/2021 3:43:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Trainers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsAvailable] [bit] NULL,
	[Rating] [decimal](4, 2) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Trainers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Trainers]  WITH CHECK ADD  CONSTRAINT [FK_Trainers_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Trainers] CHECK CONSTRAINT [FK_Trainers_User]
GO

USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[SportCenter]    Script Date: 8/17/2021 3:15:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SportCenter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [int] NOT NULL,
 CONSTRAINT [PK_SportCenter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[SportCenter]  WITH CHECK ADD  CONSTRAINT [FK_SportCenter_Addresses] FOREIGN KEY([Address])
REFERENCES [dbo].[Addresses] ([Id])
GO

ALTER TABLE [dbo].[SportCenter] CHECK CONSTRAINT [FK_SportCenter_Addresses]
GO

USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[SportCenterAdmin]    Script Date: 8/17/2021 3:16:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SportCenterAdmin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Birthdate] [date] NOT NULL,
 CONSTRAINT [PK_SportCenterAdmin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[SportCenterAdmin]  WITH CHECK ADD  CONSTRAINT [FK_SportCenterAdmin_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO

ALTER TABLE [dbo].[SportCenterAdmin] CHECK CONSTRAINT [FK_SportCenterAdmin_Roles]
GO

USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[AdministratedSportCenter]    Script Date: 8/17/2021 3:11:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AdministratedSportCenter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SportCenterAdminId] [int] NOT NULL,
	[SportCenterId] [int] NOT NULL,
 CONSTRAINT [PK_AdministratedSportCenter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AdministratedSportCenter]  WITH CHECK ADD  CONSTRAINT [FK_AdministratedSportCenter_SportCenter] FOREIGN KEY([SportCenterId])
REFERENCES [dbo].[SportCenter] ([Id])
GO

ALTER TABLE [dbo].[AdministratedSportCenter] CHECK CONSTRAINT [FK_AdministratedSportCenter_SportCenter]
GO

ALTER TABLE [dbo].[AdministratedSportCenter]  WITH CHECK ADD  CONSTRAINT [FK_AdministratedSportCenter_SportCenterAdmin] FOREIGN KEY([SportCenterAdminId])
REFERENCES [dbo].[SportCenterAdmin] ([Id])
GO

ALTER TABLE [dbo].[AdministratedSportCenter] CHECK CONSTRAINT [FK_AdministratedSportCenter_SportCenterAdmin]
GO

USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[TrainingProgram]    Script Date: 8/24/2021 1:24:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TrainingProgram](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Difficulty] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[RecommendedSteps] [nvarchar](max) NOT NULL,
	[Location] [nvarchar](max) NOT NULL,
	[SportCenterId] [int] NULL,
	[Duration] [nvarchar](max) NOT NULL,
	[Rating] [decimal](4, 2) NOT NULL,
 CONSTRAINT [PK_TrainingProgram] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[TrainingProgram]  WITH CHECK ADD  CONSTRAINT [FK_TrainingProgram_SportCenter] FOREIGN KEY([SportCenterId])
REFERENCES [dbo].[SportCenter] ([Id])
GO

ALTER TABLE [dbo].[TrainingProgram] CHECK CONSTRAINT [FK_TrainingProgram_SportCenter]
GO


USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[TrainerSportCenter]    Script Date: 8/17/2021 3:19:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TrainerSportCenter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrainerId] [int] NOT NULL,
	[SportCenterId] [int] NOT NULL,
 CONSTRAINT [PK_TrainerSportCenter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TrainerSportCenter]  WITH CHECK ADD  CONSTRAINT [FK_TrainerSportCenter_SportCenter] FOREIGN KEY([SportCenterId])
REFERENCES [dbo].[SportCenter] ([Id])
GO

ALTER TABLE [dbo].[TrainerSportCenter] CHECK CONSTRAINT [FK_TrainerSportCenter_SportCenter]
GO

ALTER TABLE [dbo].[TrainerSportCenter]  WITH CHECK ADD  CONSTRAINT [FK_TrainerSportCenter_Trainers] FOREIGN KEY([TrainerId])
REFERENCES [dbo].[Trainers] ([Id])
GO

ALTER TABLE [dbo].[TrainerSportCenter] CHECK CONSTRAINT [FK_TrainerSportCenter_Trainers]
GO

USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[TraineeTrainingProgram]    Script Date: 8/23/2021 12:23:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TraineeTrainingProgram](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TraineeId] [int] NOT NULL,
	[TrainingProgramId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
 CONSTRAINT [PK_TraineeTrainingProgram] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TraineeTrainingProgram]  WITH CHECK ADD  CONSTRAINT [FK_TraineeTrainingProgram_Trainee] FOREIGN KEY([TraineeId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[TraineeTrainingProgram] CHECK CONSTRAINT [FK_TraineeTrainingProgram_Trainee]
GO

ALTER TABLE [dbo].[TraineeTrainingProgram]  WITH CHECK ADD  CONSTRAINT [FK_TraineeTrainingProgram_TrainingProgram] FOREIGN KEY([TrainingProgramId])
REFERENCES [dbo].[TrainingProgram] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[TraineeTrainingProgram] CHECK CONSTRAINT [FK_TraineeTrainingProgram_TrainingProgram]
GO

USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[TrainerTrainingProgram]    Script Date: 8/27/2021 1:30:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TrainerTrainingProgram](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrainerId] [int] NOT NULL,
	[TrainingProgramId] [int] NOT NULL,
 CONSTRAINT [PK_TrainerTrainingProgram] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TrainerTrainingProgram]  WITH CHECK ADD  CONSTRAINT [FK_TrainerTrainingProgram_Trainers] FOREIGN KEY([TrainerId])
REFERENCES [dbo].[Trainers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[TrainerTrainingProgram] CHECK CONSTRAINT [FK_TrainerTrainingProgram_Trainers]
GO

ALTER TABLE [dbo].[TrainerTrainingProgram]  WITH CHECK ADD  CONSTRAINT [FK_TrainerTrainingProgram_TrainingProgram] FOREIGN KEY([TrainingProgramId])
REFERENCES [dbo].[TrainingProgram] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[TrainerTrainingProgram] CHECK CONSTRAINT [FK_TrainerTrainingProgram_TrainingProgram]
GO



/****** Object:  Table [dbo].[Favorite]    Script Date: 8/23/2021 12:24:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Favorite](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TraineeId] [int] NOT NULL,
	[TrainingId] [int] NOT NULL,
 CONSTRAINT [PK_Favorite] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Favorite]  WITH CHECK ADD  CONSTRAINT [FK_Favorite_Trainee] FOREIGN KEY([TraineeId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Favorite] CHECK CONSTRAINT [FK_Favorite_Trainee]
GO

ALTER TABLE [dbo].[Favorite]  WITH CHECK ADD  CONSTRAINT [FK_Favorite_TrainingProgram] FOREIGN KEY([TrainingId])
REFERENCES [dbo].[TrainingProgram] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Favorite] CHECK CONSTRAINT [FK_Favorite_TrainingProgram]
GO

USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[Review]    Script Date: 8/25/2021 4:17:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Review](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [decimal](4, 2) NULL,
	[Comment] [nvarchar](max) NULL,
	[TraineeId] [int] NOT NULL,
	[TrainingId] [int] NOT NULL,
	[CreatedAt] [date] NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Review] FOREIGN KEY([TraineeId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Review]
GO

ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_TrainingProgram] FOREIGN KEY([TrainingId])
REFERENCES [dbo].[TrainingProgram] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_TrainingProgram]
GO


USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[Challenge]    Script Date: 8/25/2021 2:38:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Challenge](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorID] [int] NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](150) NULL,
	[TrackedOutcome] [varchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Challenge]  WITH CHECK ADD FOREIGN KEY([AuthorID])
REFERENCES [dbo].[User] ([Id])
GO





USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[TraineeChallenge]    Script Date: 8/23/2021 3:47:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TraineeChallenge](
	[ChallengeID] [int] NOT NULL,
	[TraineeID] [int] NOT NULL,
	PRIMARY KEY([ChallengeID], [TraineeID]),
	[IsFinished] [bit] NOT NULL,
	[Proof] [varchar](250) NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TraineeChallenge]  WITH CHECK ADD FOREIGN KEY([ChallengeID])
REFERENCES [dbo].[Challenge] ([ID])
GO

ALTER TABLE [dbo].[TraineeChallenge]  WITH CHECK ADD FOREIGN KEY([TraineeID])
REFERENCES [dbo].[User] ([Id])
GO


USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[Event]    Script Date: 9/1/2021 5:33:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Event](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[Title] [varchar](150) NOT NULL,
	[Description] [varchar](250) NULL,
	[Goal] [varchar](150) NOT NULL,
	[AddressID] [int] NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[Duration] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD FOREIGN KEY([AddressID])
REFERENCES [dbo].[Addresses] ([Id])
GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD FOREIGN KEY([AuthorId])
REFERENCES [dbo].[User] ([Id])
GO

USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[EventCreatedBySportCenter]    Script Date: 9/1/2021 5:32:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventCreatedBySportCenter](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[Title] [varchar](150) NOT NULL,
	[Description] [varchar](250) NULL,
	[Goal] [varchar](150) NOT NULL,
	[AddressID] [int] NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[Duration] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EventCreatedBySportCenter]  WITH CHECK ADD FOREIGN KEY([AddressID])
REFERENCES [dbo].[Addresses] ([Id])
GO

ALTER TABLE [dbo].[EventCreatedBySportCenter]  WITH CHECK ADD FOREIGN KEY([AuthorId])
REFERENCES [dbo].[SportCenterAdmin] ([Id])
GO


USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[JoinEvent]    Script Date: 9/3/2021 12:54:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JoinEvent](
	[EventId] [int] NOT NULL,
	[UserID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EventId] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[JoinEvent]  WITH CHECK ADD FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([ID])
GO

ALTER TABLE [dbo].[JoinEvent]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([Id])
GO


USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[JoinEventCreatedBySportCenter]    Script Date: 9/3/2021 12:54:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JoinEventCreatedBySportCenter](
	[EventId] [int] NOT NULL,
	[UserID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EventId] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[JoinEventCreatedBySportCenter]  WITH CHECK ADD FOREIGN KEY([EventId])
REFERENCES [dbo].[EventCreatedBySportCenter] ([ID])
GO

ALTER TABLE [dbo].[JoinEventCreatedBySportCenter]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([Id])
GO




