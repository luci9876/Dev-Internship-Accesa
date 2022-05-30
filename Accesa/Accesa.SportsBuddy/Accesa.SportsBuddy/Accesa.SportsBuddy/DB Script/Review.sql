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

