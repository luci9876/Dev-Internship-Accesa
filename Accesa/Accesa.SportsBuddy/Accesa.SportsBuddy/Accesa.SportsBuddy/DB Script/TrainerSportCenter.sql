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

