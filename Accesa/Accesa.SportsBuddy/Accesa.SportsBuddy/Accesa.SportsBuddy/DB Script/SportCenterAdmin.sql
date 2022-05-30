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

