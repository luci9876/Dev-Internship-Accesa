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

