USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[Challenge]    Script Date: 8/27/2021 12:17:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Challenge](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorID] [int] NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](150) NULL,
	[TrackedOutcome] [varchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Challenge]  WITH CHECK ADD  CONSTRAINT [FK__Challenge__Autho__5D95E53A] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Challenge] CHECK CONSTRAINT [FK__Challenge__Autho__5D95E53A]
GO

