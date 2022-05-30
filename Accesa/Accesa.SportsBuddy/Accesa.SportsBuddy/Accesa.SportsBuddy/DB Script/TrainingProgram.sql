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

