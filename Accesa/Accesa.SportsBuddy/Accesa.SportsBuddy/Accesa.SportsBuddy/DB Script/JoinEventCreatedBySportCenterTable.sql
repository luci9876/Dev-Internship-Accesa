USE [SportsBuddyDB]
GO

/****** Object:  Table [dbo].[JoinEventCreatedBySportCenter]    Script Date: 9/3/2021 12:54:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JoinEventCreatedBySportCenter](
	[EventId] [int] NOT NULL,
	[UserID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EventId] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[JoinEventCreatedBySportCenter]  WITH CHECK ADD FOREIGN KEY([EventId])
REFERENCES [dbo].[EventCreatedBySportCenter] ([ID])
GO

ALTER TABLE [dbo].[JoinEventCreatedBySportCenter]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([Id])
GO


