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