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

