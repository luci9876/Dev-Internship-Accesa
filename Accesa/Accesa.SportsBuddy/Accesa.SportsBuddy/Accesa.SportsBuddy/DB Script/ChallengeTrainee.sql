USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[TraineeChallenge]    Script Date: 8/27/2021 12:32:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TraineeChallenge](
	[ChallengeID] [int] NOT NULL,
	[TraineeID] [int] NOT NULL,
	[IsFinished] [bit] NOT NULL,
	[Proof] [varchar](250) NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[ChallengeID] ASC,
	[TraineeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TraineeChallenge]  WITH CHECK ADD  CONSTRAINT [FK__TraineeCh__Chall__607251E5] FOREIGN KEY([ChallengeID])
REFERENCES [dbo].[Challenge] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[TraineeChallenge] CHECK CONSTRAINT [FK__TraineeCh__Chall__607251E5]
GO

ALTER TABLE [dbo].[TraineeChallenge]  WITH CHECK ADD FOREIGN KEY([TraineeID])
REFERENCES [dbo].[User] ([Id])
GO

