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

