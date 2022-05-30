USE [SportsBuddyDB]
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

